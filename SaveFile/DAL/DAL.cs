﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace DAL
{
    public class MyDAL : IDAL
    {

        static private string _connectionString ="null";

        public MyDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        UserDAL userDAL = new UserDAL(_connectionString);

        private int GetGrade(int id)
        {
            int grade = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                var trueRateCommand = new SqlCommand("SELECT COUNT(UserId) FROM dbo.GradeTable WHERE FileId = @FileId AND CheckGrade = @CheckGrade", connection);
                trueRateCommand.Parameters.AddWithValue("@FileId", id);
                trueRateCommand.Parameters.AddWithValue("@CheckGrade", "True");

                var falseRateCommand = new SqlCommand("SELECT COUNT(UserId) FROM dbo.GradeTable WHERE FileId = @FileId AND CheckGrade = @CheckGrade ", connection);
                falseRateCommand.Parameters.AddWithValue("@FileId", id);
                falseRateCommand.Parameters.AddWithValue("@CheckGrade", "False");

                connection.Open();
                int a = (int)trueRateCommand.ExecuteScalar();
                int b = (int)falseRateCommand.ExecuteScalar();
                grade = a - b;
            }
            return grade;
        }

        public bool GradeFile(bool gradeBool, int fileId, string userName)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                int userId = userDAL.GetUserId(userName);

                var checkExistGrade = new SqlCommand("SELECT COUNT(UserId) FROM dbo.GradeTable WHERE FileId = @FileId AND UserId = @UserId", connection);
                checkExistGrade.Parameters.AddWithValue("@FileId", fileId);
                checkExistGrade.Parameters.AddWithValue("@UserId", userId);

                var checkExistSameGrade = new SqlCommand("SELECT CheckGrade FROM dbo.GradeTable WHERE FileId = @FileId AND UserId=@UserId", connection);
                checkExistSameGrade.Parameters.AddWithValue("@FileId", fileId);
                checkExistSameGrade.Parameters.AddWithValue("@UserId", userId);

                var insertNewGradeTable = new SqlCommand("INSERT INTO dbo.GradeTable (FileId,UserId,CheckGrade) VALUES (@FileId,@UserId,@CheckGrade)", connection);
                insertNewGradeTable.Parameters.AddWithValue("@FileId", fileId);
                insertNewGradeTable.Parameters.AddWithValue("@UserId", userId);
                insertNewGradeTable.Parameters.AddWithValue("@CheckGrade", gradeBool);

                var updateGradeTable = new SqlCommand("UPDATE dbo.GradeTable SET CheckGrade = @CheckGrade WHERE FileId = @FileId AND UserId=@UserId", connection);
                updateGradeTable.Parameters.AddWithValue("@FileId", fileId);
                updateGradeTable.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                if ((int)checkExistGrade.ExecuteScalar() == 0)
                {
                    insertNewGradeTable.ExecuteNonQuery();
                    return true;
                }
                else if (checkExistSameGrade.ExecuteScalar().GetType() == typeof(DBNull))
                {
                    updateGradeTable.Parameters.AddWithValue("@CheckGrade", gradeBool);
                    updateGradeTable.ExecuteNonQuery();
                    return true;
                }
                else if ((bool)checkExistSameGrade.ExecuteScalar() != gradeBool)
                {
                    updateGradeTable.Parameters.AddWithValue("@CheckGrade", DBNull.Value);
                    updateGradeTable.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool AddTag(string tags, int fileId)
        {
            List<string> tagList = SeparateString(tags);
            using (var connection = new SqlConnection(_connectionString))
            {
                var checkExistTagRow = new SqlCommand("SELECT COUNT(FileId) FROM TagTable WHERE FileId=@FileId AND Tag=@Tag ", connection);
                checkExistTagRow.Parameters.AddWithValue("@FileId", fileId);

                var insertCommand = new SqlCommand("INSERT INTO dbo.TagTable (FileId,Tag) VALUES (@FileId,@Tag)", connection);
                insertCommand.Parameters.AddWithValue("@FileId", fileId);

                connection.Open();
                foreach (string elm in tagList)
                {
                    checkExistTagRow.Parameters.AddWithValue("@Tag", elm);
                    if ((int)checkExistTagRow.ExecuteScalar() == 0)
                    {
                        insertCommand.Parameters.AddWithValue("@Tag", elm);
                        insertCommand.ExecuteNonQuery();
                        insertCommand.Parameters.RemoveAt("@Tag");
                    }
                    checkExistTagRow.Parameters.RemoveAt("@Tag");
                }
                return true;
            }
        }

        public bool DelTag(string tag, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.TagTable WHERE Tag = @Tag AND FileId = @FileId", connection);
                command.Parameters.AddWithValue("@FileId", id);
                command.Parameters.AddWithValue("@Tag", tag);

                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public List<string> GetTags(int fileId)
        {
            List<string> result = new List<string>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT Tag FROM TagTable WHERE FileId = @FileId", connection);
                command.Parameters.AddWithValue("@FileId", fileId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
                return result;
            }
        }

        public List<FileModel> SearchFile(string tags)
        {
            List<string> tagList = SeparateString(tags);
            using (var connection = new SqlConnection(_connectionString))
            {
                List<FileModel> result = new List<FileModel>();
                List<int> idList = new List<int>();
                var tagSearch = new SqlCommand("SELECT FileId,Tag FROM dbo.TagTable", connection);
                var nameSearch = new SqlCommand("SELECT FileId,FileName FROM dbo.FileTable", connection);
                connection.Open();
                using (var reader = tagSearch.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (string el in tagList)
                        {
                            var tag = reader.GetString(1).Replace(" ", string.Empty);
                            if (tag == el)
                                idList.Add(reader.GetInt32(0));
                        }
                    }
                }
                using (var reader = nameSearch.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (string el in tagList)
                        {
                            var name = reader.GetString(1).Replace(" ", string.Empty);
                            if (name == el)
                                idList.Add(reader.GetInt32(0));
                        }
                    }
                }
                idList = idList.Distinct().ToList();
                foreach(int el in idList)
                {
                    result.Add(GetFile(el));
                }
                return result;
            }
        }

        public int UploadFile(byte[] file, string fileName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO dbo.FileTable ([File],UploadTime,FileName) OUTPUT INSERTED.FileId VALUES (@File,@UploadTime,@FileName)", connection);
                command.Parameters.AddWithValue("@File", file);
                command.Parameters.AddWithValue("@UploadTime", DateTime.Now);
                command.Parameters.AddWithValue("@FileName", fileName);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public bool DeleteFile(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM dbo.FileTable WHERE FileId = @FileId", connection);
                command.Parameters.AddWithValue("@FileId", id);
                connection.Open();

                return command.ExecuteNonQuery() == 1;
            }
        }

        public string ReadFile(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT [File] FROM dbo.FileTable WHERE FileId = @FileId", connection);
                command.Parameters.AddWithValue("@FileId", id);
                connection.Open();

                var buffer = (byte[])command.ExecuteScalar();
                string result = Encoding.UTF8.GetString(buffer);
                return result;
            }
        }

        public FileModel GetFile(int id)
        {
            FileModel result = new FileModel();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT FileId,[File],UploadTime,FileName FROM dbo.FileTable WHERE FileId = @FileId", connection);
                command.Parameters.AddWithValue("@FileId", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.FileID = reader.GetInt32(0);
                        result.File = (byte[])reader.GetValue(1);
                        result.UploadTime = reader.GetDateTime(2);
                        result.FileName = reader.GetString(3);
                    }
                }
                result.Grade = GetGrade(result.FileID);
                result.Tags = GetTags(id);
                return result;
            }
        }

        public List<FileModel> ViewFiles()
        {
            List<FileModel> result = new List<FileModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT FileId,[File],UploadTime,FileName FROM dbo.FileTable", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FileModel readFile = new FileModel();
                        readFile.FileID = reader.GetInt32(0);
                        readFile.File = (byte[])reader.GetValue(1);
                        readFile.UploadTime = reader.GetDateTime(2);
                        readFile.FileName = reader.GetString(3);
                        readFile.Grade = GetGrade(readFile.FileID);
                        result.Add(readFile);
                    }
                }
                return result;
            }
        }

        private List<string> SeparateString(string str)
        {
            string[] separator = { " ","\t", "\r\n", ",", ":", "?", "!", "[", "]", "(", ")", "{", "}", "’", "\'", "\"" };
            string[] WordsArr = str.Split(separator, StringSplitOptions.None);
            return WordsArr.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDAL
    {
        int UploadFile(byte[] file, string fileName);
        FileModel GetFile(int id);
        bool DeleteFile(int id);
        string ReadFile(int id);
        bool AddTag(string tags, int id); 
        bool DelTag(string tag, int id);
        List<FileModel> SearchFile(string tags); 
        bool GradeFile(bool grade, int id, string userName);
        List<FileModel> ViewFiles();
    }
}

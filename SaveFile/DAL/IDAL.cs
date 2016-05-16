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
        bool AddTag(List<string> tag, int id); 
        bool DelTag(string tag, int id);
        List<int> SearchFile(List<string> tagList); 
        bool GradeFile(bool grade, int id, string userName);
        List<FileModel> ViewFiles();
    }
}

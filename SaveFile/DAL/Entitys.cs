using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileModel
    {
        public byte[] File { get; set; }
        public DateTime UploadTime { get; set; }
        public string FileName { get; set; }
        public int FileID { get; set; }
        public int Grade { get; set; }
        public List<string> Tags { get; set; }
    }
}

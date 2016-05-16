using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoteSave.Models
{
    public class FileViewModel
    {
        [Required(ErrorMessage = "select the download file")]
        public HttpPostedFileBase File { get; set; }
        [StringLength(20)]
        public string FileName { get; set; }
        public int FileID { get; set; }
        public DateTime UploadTime { get; set; }
        public int Grade { get; set; }
    }
}
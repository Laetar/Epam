using DAL;
using NoteSave.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteSave.Controllers
{
    public class FileController : Controller
    {
        MyDAL myDal = new MyDAL(ConnectionString.GetConnectionString());

        public ActionResult UploadFile()
        {
            var model = new FileViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult UploadFile(FileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string extension = Path.GetExtension(model.File.FileName);

            if (!(extension == ".txt")&&!(extension == ".doc") && !(extension == ".docx"))
            {
                ModelState.AddModelError("File", "Only .txt, .doc or .docx extension ");
                return View(model);
            }

            string fileName = model.File.FileName;

            byte[] data;
            using (Stream inputStream = model.File.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }

            var FileID = myDal.UploadFile(data, fileName);

            return RedirectToAction("Index","Home");
        }

        public FileResult DownloadFile(int id)
        {
            var contents = myDal.GetFile(id);
            string fileName = myDal.GetFile(id).FileName.Trim();
            return File(contents.File, "txt", fileName);
        }
    }
}
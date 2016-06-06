using System.Web.Mvc;
using NoteSave.Models;
using DAL;
using System.Collections.Generic;
using System.IO;
using System.Web.Security;

namespace NoteSave.Controllers
{
    public class HomeController : Controller
    {
        MyDAL myDal = new MyDAL(ConnectionString.GetConnectionString());

        [HttpGet]
        public ActionResult Index()
        {
            var model = myDal.ViewFiles();
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Index(List<FileModel> model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult FileDetail(int id)
        {
            var model = myDal.GetFile(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult FileDetail(string type,int id)
        {
            myDal.GradeFile(bool.Parse(type), id ,User.Identity.Name);
            var model = myDal.GetFile(id);
            return View(model);
        }

        public ActionResult AddTag(string tags, int id)
        {
            
            myDal.AddTag(tags,id);
            return RedirectToAction("FileDetail",new { id = id });
        }

        public ActionResult FileSearch(string tags)
        {
            var fileList = myDal.SearchFile(tags);
            
            return View("Index", fileList);
        }

  

        
    }
}
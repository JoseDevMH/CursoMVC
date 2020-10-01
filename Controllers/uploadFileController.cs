using CursoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class uploadFileController : Controller
    {
        // GET: uploadFile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(FileViewModel model)
        {
            return View();
        }
    }
}
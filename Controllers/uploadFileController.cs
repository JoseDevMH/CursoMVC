using CursoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Save(FileViewModel model)
        {
            string PathSite = Server.MapPath("~/");
            string PathFile1 = Path.Combine(PathSite + "/Files/archivo1.pdf");
            string PathFile2 = Path.Combine(PathSite + "/Files/archivo2.pdf");

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            model.File1.SaveAs(PathFile1);
            model.File2.SaveAs(PathFile2);

            @TempData["Message"] = "Se cargaron los Archivos";
            return RedirectToAction("Index");
        }
    }
}
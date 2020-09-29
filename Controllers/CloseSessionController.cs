using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class CloseSessionController : Controller
    {
        // GET: CloseSession
        public ActionResult LogOff()
        {
            Session["User"] = null;
            return RedirectToAction ("Index", "Access");
        }
    }
}
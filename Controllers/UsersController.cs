using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TablesViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    public class UsersController : Controller
    {
        public object[] Id { get; private set; }

        // GET: Users
        public ActionResult Index()
        {
            List<UsersTableViewModel> lst = null;
            using (cursoMvcEntities db = new cursoMvcEntities())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.email
                       select new UsersTableViewModel
                       {
                           Id = d.id,
                           Email = d.email,
                           Edad = d.edad
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (cursoMvcEntities db = new cursoMvcEntities())
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Users/"));
        }

        public ActionResult Edit(int Id)
        {
            EditUserViewModels model = new EditUserViewModels();

            using(var db = new cursoMvcEntities())
            {
                var oUser = db.user.Find(Id);
                model.Id = oUser.id;
                model.Email = oUser.email;
                model.Edad = (int)oUser.edad;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursoMvcEntities())
            {
                var oUser = db.user.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if(model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Users/"));
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new cursoMvcEntities())
            {
                var oUser = db.user.Find(Id);
                oUser.idState = 3; //Borrado logico, eliminaremos
                

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}
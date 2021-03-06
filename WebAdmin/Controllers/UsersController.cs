﻿using Common;
using Common.MyExtensions;
using Model.Auth;
using Service;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Filters;

namespace WebAdmin.Controllers
{
    //[Autenticado]

    public class UsersController : Controller
    {
        private readonly IUsuarioService _userService = DependecyFactory.GetInstance<IUsuarioService>();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewUser()
        {
            return View(new Usuarios());
        }


        [HttpPost]
        public JsonResult SaveNewUser(Usuarios model, HttpPostedFileBase picture)
        {
            var rh = new ResponseHelper();

            if (picture != null && !picture.IsImage())
            {
                ModelState.AddModelError("Picture", "El archivo adjuntado no es una imagen válida");
            }

            if (!ModelState.IsValid)
            {
                rh.Message = "Ingrese una imagen valida";
            }
            else
            {
                rh = _userService.InsertOrUpdate(model, picture);

                if (rh.Response)
                {
                    rh.Href = "self";
                }
            }

            return Json(rh);
        }
    }
}
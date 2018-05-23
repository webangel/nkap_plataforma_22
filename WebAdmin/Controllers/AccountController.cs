using Common;
using Model.Custom;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Filters;

namespace WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioService _userService 
            = DependecyFactory.GetInstance<IUsuarioService>();


        [NoLogin]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Acceder(LoginViewModel model)
        {
            var response = new ResponseHelper();
            if (ModelState.IsValid)
            {
                response = _userService.Acceder(model, true);
                if (response.Response)
                {
                    response.Message = "Bienvenido al Sistema usuario: " + response.Result;
                   
                    response.Href = Url.Content("~/Home/Index");
                }
                return Json(response);
            }
            response.Message = "Ocurrio un error, ingrese sus credenciales";
            return Json(response);
        }





        public ActionResult Logout()
        {
            UserSessionHelper.DestroyUserSession();
            return Redirect("~/");
        }

    }
}
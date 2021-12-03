using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Ingresar(string correo, string password)
        {
            try
            {

                using (Models.AguacateEntities db = new Models.AguacateEntities())
                {
                    var User = (from persona in db.Personas
                                where persona.Correo == correo && persona.Password == password.Trim()
                                select persona).FirstOrDefault();
                    if (User != null)
                    {
                        Session["User"] = User;
                        return RedirectToAction("Index", "Personas");

                        

                    }

                    else {
                        ViewBag.Error = "Cedula o Contraseña Invalido";
                        return RedirectToAction("Login");

                    }
                    
                }

            }
            catch {
                return RedirectToAction("Index", "home");
            }
        }
    }

}
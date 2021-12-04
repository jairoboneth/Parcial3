using Parcial3.Controllers;
using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial3.FiltroRol
{
    public class Filtro : ActionFilterAttribute
    {
        private Personas persona;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                persona = (Personas)HttpContext.Current.Session["Us"];
                if (persona == null)
                {
                    if (filterContext.Controller is PersonasController == true || filterContext.Controller is MensajeController == true || filterContext.Controller is DatosBController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("Login/Login");
                    }
                }
                else {
                    if (filterContext.Controller is LoginController == true || filterContext.Controller is HomeController == true) {
                        filterContext.HttpContext.Response.Redirect("HomeAd/Index");
                    }

                }

            }
            catch { }

        }

    }

}
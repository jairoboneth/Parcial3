using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial3.Controllers
{
    public class HomeAdController : Controller
    {
        // GET: HomeAd
        public ActionResult Index()
        {
            Personas personas; 
            if (short.Parse(System.Web.HttpContext.Current.Session["Rol"].ToString()) != 1)
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutUser.cshtml";
                personas = (Personas) System.Web.HttpContext.Current.Session["Us"];
                ViewBag.uso = personas.Nombre;
            }
            else
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAd.cshtml";
                personas = (Personas)System.Web.HttpContext.Current.Session["Us"];
                ViewBag.uso = personas.Nombre;
            }
            return View();
        }
    }
}
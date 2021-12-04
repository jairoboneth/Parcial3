using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial3.Controllers
{
    public class DatosBController : Controller
    {
        Models.AguacateEntities db = new Models.AguacateEntities();

        // GET: DatosB
        public ActionResult Index()
        {
            var id = System.Web.HttpContext.Current.Session["User"].ToString();
            var cedula = long.Parse(id);
            
            
            return View();
        }

        public ActionResult guradarD(int norCuenta, int saldo) {

            var id = System.Web.HttpContext.Current.Session["User"].ToString();
            var cedula = long.Parse(id);
            Banco banco = new Banco();
            banco.NroCuenta = norCuenta;

            var anco = (from op in db.Banco
                       where (op.Cedula == cedula)
                       select op).FirstOrDefault();

            if (anco == null)
            {

                banco.Saldo = saldo + "";
                banco.Cedula = cedula;
                db.Banco.Add(banco);
                db.SaveChanges();
                return RedirectToAction("Index", "home");
            }
            else {
                return RedirectToAction("Index", "home");
            }


            return RedirectToAction("Index", "home");



        }
    }
}
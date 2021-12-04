using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Parcial3.Controllers
{
   
    public class MensajeController : Controller
    {

        private AguacateEntities db = new AguacateEntities();

        // GET: Mensaje
        public ActionResult Index()
        {
            List<SelectList> lst = new List<SelectList>();
            var  id = System.Web.HttpContext.Current.Session["User"].ToString();
            var cedula = long.Parse(id);
            using (Models.AguacateEntities db = new Models.AguacateEntities()) {

                var tel = (from telefono in db.Telefono
                            where telefono.Cedula == cedula
                           select telefono).ToList<Telefono>();
                SelectList TelSelectList = new SelectList(tel, "Telefono1", "Telefono1");
                
                ViewBag.Origen = TelSelectList;
              
            }
            using (Models.AguacateEntities db = new Models.AguacateEntities())
            {

                var tel2 = (from telefono in db.Telefono
                           where telefono.Cedula != cedula
                           select telefono).ToList<Telefono>();
                SelectList TelSelectList2 = new SelectList(tel2, "Telefono1", "Telefono1");

                ViewBag.Origen2 = TelSelectList2;

            }
            ViewBag.msg = System.Web.HttpContext.Current.Session["msgD"];
            return View();
        }

        [HttpPost]
         public ActionResult guardarMsg(int origen,int destino, string mensaje) {

       
            try
            {
                var msg = (from op in db.Mensaje
                                where (op.NroOrigen == origen && op.NroDestino == destino) || (op.NroDestino == destino && op.NroOrigen == origen)
                                select op).FirstOrDefault();


                if (msg == null)
                {

                    Mensaje sdf = new Mensaje();
                    sdf.NroOrigen = origen;
                    sdf.NroDestino = destino;

                    db.Mensaje.Add(sdf);
                    db.SaveChanges();
                    var id = db.Mensaje.Max(e => e.Id);
                    Session["msg"] = mensaje;
                    return RedirectToAction("DetalleM");
                }
                else {

                    Session["msg"] = mensaje;
                    Session["msgId"] = msg.Id;
                    return RedirectToAction("DetalleM");


                }

            }
            catch
            {
                return RedirectToAction("Index", "home");
            }

        }

        public ActionResult DetalleM() {



            var agua = System.Web.HttpContext.Current.Session["msgId"].ToString();
            var idMSg = long.Parse(agua);

            var msg = (from op in db.DetalleMsg
                       where (op.Mensaje == idMSg)
                       select op).ToList<DetalleMsg>();

            if (msg != null)
            {

                DetalleMsg Dm = new DetalleMsg();
                Dm.Mensaje = idMSg;
                Dm.MensajeDescripcion = Session["msg"].ToString();
                Dm.CostoId = 1;
                db.DetalleMsg.Add(Dm);
                db.SaveChanges();
               

                System.Web.HttpContext.Current.Session.Add("msgD", msg);
                return RedirectToAction("Index");

            }
            
            return RedirectToAction("Index");

        }
        public ActionResult actulizar() {

         

            var msg = (from op in db.DetalleMsg
                      
                       select op).ToList<DetalleMsg>();
            if(msg == null)
            {
                System.Web.HttpContext.Current.Session.Add("msgD", msg);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
using MySql.Data.MySqlClient;
using SysAgropec.Class;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SysAgropec.Controllers
{
    public class RacaController : Controller
    {
        public ActionResult Add()
        {
            if (Session["loginuser"] != null)
            {

                return View();

            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        public ActionResult Edit(int ID)
        {

            if (Session["loginuser"] != null)
            {
                RacaViewModel r = new RacaViewModel();

                return PartialView("PartialView", r.BuscaRaca(ID));

            } else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        public ActionResult Update(Models.Raca r)
        {
            if (Session["loginuser"] != null)
            {

                RacaViewModel raca = new RacaViewModel();

                r.Usuario_IDAlteracao = 1; Convert.ToInt16(Session["iduser"]);
                r.Datalteracao = DateTime.Now;

                raca.AtualizaRaca(r);

                return RedirectToAction("List");

            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        [HttpPost]
        public ActionResult Insert()
        {

            if (Session["iduser"] != null)
            {
                RacaViewModel r = new RacaViewModel();

                r.Datacadastro = DateTime.Now;
                r.Datalteracao = null;
                r.Descricao = Request.Form["descricao"];
                r.Excluido = 0;
                r.Usuario_IDCcadastro = Convert.ToInt16(Session["iduser"]);
                r.Usuario_IDAlteracao = null;
                r.AdicionaRaca(r);

                return RedirectToAction("List");

            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }
        [HttpGet]
        public ActionResult List()
        {
            if(Session["loginuser"]!=null){

                RacaViewModel r = new RacaViewModel();

                return View(r.CarregaRaca());
            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            if(Session["loginuser"]!=null){
                string descricao = Request.Form["descricao"];
                
                    RacaViewModel r = new RacaViewModel();

                    return View("List", r.CarregaRaca(descricao));
                
            } else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }


        public JsonResult Delete(int idRaca)
        {
            bool result = false;

            if (idRaca > 0)
            {

                RacaViewModel r = new RacaViewModel();
                r.ExcluiRaca(idRaca);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


    }
}
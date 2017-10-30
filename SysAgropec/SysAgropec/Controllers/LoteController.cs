using MySql.Data.MySqlClient;
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
    public class LoteController : Controller
    {
   
        public ActionResult Add()

        {
            if(Session["loginuser"] != null)
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

                LoteViewModel l = new LoteViewModel();

                return PartialView("PartialView", l.BuscaLote(ID));
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

        public ActionResult Update(Models.Lote l)
        {

            if (Session["loginuser"] != null)
            {

                LoteViewModel lote = new LoteViewModel();

                l.Usuario_IDAlteracao = Convert.ToInt16(Session["iduser"]);
                l.Dataalteracao = DateTime.Now;

                lote.AtualizaLote(l);

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
            if (Session["loginuser"] != null)
            {
                LoteViewModel l = new LoteViewModel();

                l.Datacadastro = DateTime.Now;
                l.Dataalteracao = null;
                l.Numerolote = Request.Form["numerolote"];
                l.Usuario_IDCadastro = Convert.ToInt16(Session["iduser"]);
                l.Usuario_IDAlteracao = null;
                l.Observacao = Request.Form["observacao"];
                l.Datafabricacao = Convert.ToDateTime(Request.Form["datafabricacao"]);
                l.Datavalidade = Convert.ToDateTime(Request.Form["datavalidade"]);
                l.Propriedade_ID = Convert.ToInt16(Session["idfazenda"]);
                l.AdicionaLote(l);

                return RedirectToAction("List");

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
        [HttpGet]
        public ActionResult List()
        {
            if(Session["loginuser"] !=null){

                LoteViewModel l = new LoteViewModel();

                return View(l.CarregaLote());
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
                string descricao = Request.Form["numerolote"];

                if (!descricao.Equals(""))
                {

                    LoteViewModel l = new LoteViewModel();


                    return View("List", l.CarregaLote(descricao));
                }


                return View("List");
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


        public JsonResult Delete(int idLote)
        {
            if (Session["iduser"] != null)
            {

                bool result = false;

                if (idLote > 0)
                {

                    LoteViewModel l = new LoteViewModel();
                    l.ExcluiLote(idLote);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            return null;
        }
        
    }
}
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
    public class ProducaoController : Controller
    {

        public JsonResult Delete(int idProducao)
        {
            if (Session["loginuser"] != null)
            {
                bool result = false;

                if (idProducao > 0)
                {

                    ProducaoViewModel l = new ProducaoViewModel();

                   
                    l.ExcluiProducao(idProducao);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        public ActionResult Add()
        {
            if (Session["loginuser"] != null)
            {
                AnimalViewModel a = new AnimalViewModel();

                ViewData["animais"] = a.CarregaMatrizes(Convert.ToInt16(Session["idfazenda"]));

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

        public ActionResult List()
        {
            if (Session["loginuser"] != null)
            {

                ProducaoViewModel p = new ProducaoViewModel();

                return View(p.CarregaProducoes(null, null));

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
            if (Session["loginuser"] != null)
            {
                ProducaoViewModel p = new ProducaoViewModel();

                if (Request.Form["datIni"] != "" && Request.Form["datFin"] != "")
                {

                    DateTime dataInicial = Convert.ToDateTime(Request.Form["datIni"]);
                    DateTime dataFinal = Convert.ToDateTime(Request.Form["datFin"]);
                    
                    return View("List", p.CarregaProducoes(dataInicial, dataFinal));
                }
                else
                {
                    return View("List", p.CarregaProducoes(null,null));
                }
                
            }
            else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        public ActionResult Insert(ProducaoViewModel p)
        {
            if (Session["loginuser"] != null)
            {
                try
                {
                    sysagropecEntities db = new sysagropecEntities();

                    Producao prod = new Producao();
                    
                    prod.Usuario_IDAlteracao = null;
                    prod.Datalteracao = null;
                    prod.Datacadastro = DateTime.Now;
                    prod.Usuario_IDCadastro = Convert.ToInt16(Session["iduser"]);
                    prod.Observacao = p.Observacao;
                    prod.Quantidade = p.Quantidade;
                    prod.Animail_ID = p.Animail_ID;
                    prod.Datarealizada = p.Datarealizada;
                    prod.Usuario_IDProducao = Convert.ToInt16(Session["iduser"]);
                    prod.Excluido = 0;

                    db.Producao.Add(prod);
                    db.SaveChanges();

                    int latestEmpId = prod.ID;

                    return RedirectToAction("List");
                }

                catch (Exception ex)
                {
                    throw ex;

                }

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

    }
}
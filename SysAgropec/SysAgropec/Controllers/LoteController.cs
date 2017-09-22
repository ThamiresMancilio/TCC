using MySql.Data.MySqlClient;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysAgropec.Controllers
{
    public class LoteController : Controller
    {
        // GET: Lote
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Add()

        {
            return View();
        }

        public ActionResult Edit(int ID)
        {

            LoteViewModel l = new LoteViewModel();

            
            return PartialView("PartialView", l.BuscaLote(ID));
        }

        public ActionResult Update(Models.Lote l)
        {

            LoteViewModel lote = new LoteViewModel();
            
            l.Usuario_IDAlteracao = 1;  //Session["iduser"];
            l.Dataalteracao = DateTime.Now;

            lote.AtualizaLote(l);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Insert()
        {

            LoteViewModel l = new LoteViewModel();

            l.Datacadastro = DateTime.Now;
            l.Dataalteracao = null;
            l.Numerolote = Request.Form["numerolote"];
            l.Usuario_IDCadastro = 1;
            l.Usuario_IDAlteracao = null;
            l.Observacao = Request.Form["observacao"];
            l.Datafabricacao = Convert.ToDateTime(Request.Form["datafabricacao"]);
            l.Datavalidade = Convert.ToDateTime(Request.Form["datavalidade"]);
            l.Propriedade_ID = 1;
            l.AdicionaLote(l);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            {

                LoteViewModel l = new LoteViewModel();

                return View(l.CarregaLote());
            }
        }

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            {
                string descricao = Request.Form["numerolote"];

                if (!descricao.Equals(""))
                {

                    LoteViewModel l = new LoteViewModel();


                    return View("List", l.CarregaLote(descricao));
                }


                return View("List");
            }
        }


        public JsonResult Delete(int idLote)
        {
            bool result = false;

            if (idLote > 0)
            {

                LoteViewModel l = new LoteViewModel();
                l.ExcluiLote(idLote);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }




    }
}
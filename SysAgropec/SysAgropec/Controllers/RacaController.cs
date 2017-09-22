using MySql.Data.MySqlClient;
using SysAgropec.Class;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysAgropec.Controllers
{
    public class RacaController : Controller
    {
        // GET: Raca
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

            RacaViewModel r = new RacaViewModel();

            return PartialView("PartialView", r.BuscaRaca(ID));
        }

        public ActionResult Update(Models.Raca r)
        {

            RacaViewModel raca = new RacaViewModel();

            r.Usuario_IDAlteracao = 1;  //Session["iduser"];
            r.Datalteracao = DateTime.Now;

            raca.AtualizaRaca(r);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Insert()
        {

            RacaViewModel r = new RacaViewModel();

            r.Datacadastro = DateTime.Now;
            r.Datalteracao = null;
            r.Descricao = Request.Form["descricao"];
            r.Excluido = 0;
            r.Usuario_IDCcadastro = 1;
            r.Usuario_IDAlteracao = null;
            r.AdicionaRaca(r);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            {

                RacaViewModel r = new RacaViewModel();

                return View(r.CarregaRaca());
            }
        }

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            {
                string descricao = Request.Form["descricao"];

                if (!descricao.Equals(""))
                {

                    RacaViewModel r = new RacaViewModel();


                    return View("List", r.CarregaRaca(descricao));
                }


                return View("List");
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
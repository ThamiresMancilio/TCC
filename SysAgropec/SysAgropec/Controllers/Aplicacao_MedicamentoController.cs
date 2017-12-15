using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SysAgropec.Controllers
{
    public class Aplicacao_MedicamentoController : Controller
    {

        public JsonResult Delete(int idAplicacao)
        {
            if (Session["loginuser"] != null)
            {
                bool result = false;

                if (idAplicacao > 0)
                {

                    AplicacaoMedicamentoViewModel l = new AplicacaoMedicamentoViewModel();


                    l.ExcluiAplicacao(idAplicacao);

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

                ViewData["animais"] = a.CarregaGado(Convert.ToInt16(Session["idfazenda"]));

                Estoque_MedicamentoViewModel e = new Estoque_MedicamentoViewModel();

                ViewData["estoque"] = e.CarregaEstoque();

                return View();
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

        public ActionResult List()
        {
            if(Session["loginuser"] != null)
            {

                AplicacaoMedicamentoViewModel a = new AplicacaoMedicamentoViewModel();
                
                return View(a.CarregaAplicacoes(null,null));
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

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            if (Session["loginuser"] != null)
            {
                AplicacaoMedicamentoViewModel p = new AplicacaoMedicamentoViewModel();

                if (Request.Form["datIni"] != "" && Request.Form["datFin"] !="")
                {

                    DateTime dataInicial = Convert.ToDateTime(Request.Form["datIni"]);
                    DateTime dataFinal = Convert.ToDateTime(Request.Form["datFin"]);

                    return View("List", p.CarregaAplicacoes(dataInicial, dataFinal));

                }
                else
                {
                    return View("List", p.CarregaAplicacoes(null, null));

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

        public ActionResult Insert(AplicacaoMedicamentoViewModel a)
        {
            if (Session["loginuser"] != null)
            {
                try
                {
                    AplicacaoMedicamentoViewModel ap = new AplicacaoMedicamentoViewModel();
                    
                    ap.Usuario_IDAlteracao = null;
                    ap.Datalteracao = null;
                    ap.Datacadastro = DateTime.Now;
                    ap.Usuario_IDCadastro = Convert.ToInt16(Session["iduser"]);
                    ap.Observacao = a.Observacao;
                    ap.Quantidade = a.Quantidade;
                    ap.Dataplicacao = a.Dataplicacao;
                    ap.Medicamento_ID = a.Medicamento_ID;
                    ap.Animal_ID = a.Animal_ID;

                    ap.AdicionaAplicacao(ap);

                    Estoque_MedicamentoViewModel e = new Estoque_MedicamentoViewModel();

                    e.AtualizaQuantidadeEstoque(a.Medicamento_ID, a.Quantidade);
                    
                    return RedirectToAction("List");
                }

                catch (Exception ex)
                {
                    throw ex;

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
    }
}
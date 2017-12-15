using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysAgropec.Models;
using System.Web.Routing;

namespace SysAgropec.Controllers
{
    public class MedicamentoController : Controller
    {
        public ActionResult Add()
        {
            if (Session["iduser"] != null)
            {
                sysagropecEntities db = new sysagropecEntities();

                List<Lote> list = db.Lote.ToList();
                ViewBag.LoteList = new SelectList(list, "ID", "Numerolote");

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
                sysagropecEntities db = new sysagropecEntities();

                List<Lote> list = db.Lote.ToList();
                ViewBag.LoteList = new SelectList(list, "ID", "Numerolote");

                MedicamentoViewModel l = new MedicamentoViewModel();

                return PartialView("PartialView", l.BuscaMedicamento(ID));

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

        public ActionResult Update(Models.Medicamento m)
        {
            if (Session["loginuser"] != null)
            {

                MedicamentoViewModel medicamento = new MedicamentoViewModel();

                m.Usuario_IDAlteracao = Convert.ToInt16(Session["iduser"]);
                m.Datalteracao = DateTime.Now;

                medicamento.AtualizaMedicamento(m);

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



        public ActionResult AddDadosEstoque(Estoque_MedicamentoViewModel e) {

            if (Session["loginuser"] != null)
            {

                try
                {
                    sysagropecEntities db = new sysagropecEntities();

                    Estoque_Medicamento eM = new Estoque_Medicamento();


                    eM.Usuario_IDAlteracao = null;
                    eM.Medicamento_ID = e.Medicamento_ID;
                    eM.Quantidadeatual = e.Quantidadeatual;
                    eM.Quantidademinima = e.Quantidademinima;
                    eM.Quantidademaxima = e.Quantidademaxima;
                    eM.Data_Estocado = DateTime.Now.Date;

                    db.Estoque_Medicamento.Add(eM);
                    db.SaveChanges();


                    MedicamentoViewModel est = new MedicamentoViewModel();

                    est.EstocaMedicamento(e.Medicamento_ID);

                    List<Estoque_MedicamentoViewModel> lista;

                    Estoque_MedicamentoViewModel es = new Estoque_MedicamentoViewModel();

                    lista = es.CarregaEstoque();

                    return RedirectToAction("Stock", new RouteValueDictionary(
                new
                {
                    controller = "Estoque",
                    action = "Stock",
                    lista
                }));
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

        [HttpPost]
        public ActionResult Insert(MedicamentoViewModel model)
        {

            if (Session["loginuser"] != null)
            {

                try
                {
                    sysagropecEntities db = new sysagropecEntities();

                    List<Lote> list = db.Lote.ToList();

                    ViewBag.LoteList = new SelectList(list, "ID", "Numerolote");

                    Medicamento emp = new Medicamento();


                    emp.Usuario_IDAlteracao = null;
                    emp.Datalteracao = null;
                    emp.Carencialeite = model.Carencialeite;
                    emp.Datacadastro = DateTime.Now;
                    emp.Descricao = model.Descricao;
                    emp.Lote_ID = model.Lote_ID;
                    emp.Nome = model.Nome;
                    emp.Usuario_IDCadastro = Convert.ToInt16(Session["iduser"]);
                    
                    db.Medicamento.Add(emp);
                    db.SaveChanges();

                    int latestEmpId = emp.ID;

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
        [HttpGet]
        public ActionResult List()
        {
            if(Session["loginuser"]!=null){

                MedicamentoViewModel m = new MedicamentoViewModel();

                return View(m.CarregaMedicamento());

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

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            if(Session["loginuser"]!=null){

                string descricao = Request.Form["descricao"];
   
                MedicamentoViewModel l = new MedicamentoViewModel();

                return View("List", l.CarregaMedicamento(descricao));
                
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


        public JsonResult Delete(int idMedicamento)
        {
            bool result = false;

            if (idMedicamento > 0)
            {

                MedicamentoViewModel m = new MedicamentoViewModel();

                m.ExcluiMedicamento(idMedicamento);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysAgropec.Models;

namespace SysAgropec.Controllers
{
    public class MedicamentoController : Controller
    {
        // GET: Medicamento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            sysagropecConnection db = new sysagropecConnection();
            List<Lote> list = db.Lote.ToList();
            ViewBag.LoteList = new SelectList(list, "ID", "Numerolote");
            
            return View();
        }

        public ActionResult Edit(int ID)
        {
            sysagropecConnection db = new sysagropecConnection();
            List<Lote> list = db.Lote.ToList();
            ViewBag.LoteList = new SelectList(list, "ID", "Numerolote");

            MedicamentoViewModel l = new MedicamentoViewModel();

            return PartialView("PartialView", l.BuscaMedicamento(ID));
        }

        public ActionResult Update(Models.Medicamento m)
        {

            MedicamentoViewModel medicamento = new MedicamentoViewModel();

            m.Usuario_IDAlteracao = 1;  //Session["iduser"];
            m.Datalteracao = DateTime.Now;
            
            medicamento.AtualizaMedicamento(m);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Insert(MedicamentoViewModel model)
        {

            try
            {
                sysagropecConnection db = new sysagropecConnection();

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
                emp.Usuario_IDCadastro = 1;

                db.Medicamento.Add(emp);
                db.SaveChanges();

                int latestEmpId = emp.ID;

                return RedirectToAction("List");
            }

            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        [HttpGet]
        public ActionResult List()
        {
            {

                MedicamentoViewModel m = new MedicamentoViewModel();

                return View(m.CarregaMedicamento());
            }
        }

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            {
                string descricao = Request.Form["descricao"];

                
                    if (!descricao.Equals(""))
                    {

                        MedicamentoViewModel l = new MedicamentoViewModel();


                        return View("List", l.CarregaMedicamento(descricao));
                    }

                
                return View("List");
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
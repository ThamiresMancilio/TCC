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
    public class LivroController : Controller
    {
        // GET: Livro
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

            LivroViewModel l = new LivroViewModel();
       
            return PartialView("PartialView", l.BuscaLivro(ID));
        }

        public ActionResult Update(Models.Livro l)
        {

            LivroViewModel livro = new LivroViewModel();

            l.Usuario_IDAlteracao = 1;  //Session["iduser"];
            l.Datalteracao = DateTime.Now;

            livro.AtualizaLivro(l);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Insert()
        {
            
            LivroViewModel l = new LivroViewModel();

            l.Datacadastro = DateTime.Now;
            l.Datalteracao = null;
            l.Descricao = Request.Form["descricao"];
            l.Excluido = 0;
            l.Usuario_IDCadastro = 1;
            l.Usuario_IDAlteracao = null;
            l.AdicionaLivro(l);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            {
               
                LivroViewModel l = new LivroViewModel();

                return View(l.CarregaLivro());
            }
        }

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            {
                string descricao = Request.Form["descricao"];

                if (!descricao.Equals("")) {

                    LivroViewModel l = new LivroViewModel();
                    

                    return View("List", l.CarregaLivro(descricao));
                }


                return View("List");
            }
        }


        public JsonResult Delete(int idLivro)
        {
            bool result = false;

            if (idLivro > 0) {

               LivroViewModel l = new LivroViewModel();
               l.ExcluiLivro(idLivro);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

    }
}
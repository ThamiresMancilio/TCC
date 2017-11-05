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
    public class LivroController : Controller
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
                LivroViewModel l = new LivroViewModel();

                return PartialView("PartialView", l.BuscaLivro(ID));

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

        public ActionResult Update(Models.Livro l)
        {
            if (Session["loginuser"] !=null)
            {
                LivroViewModel livro = new LivroViewModel();

                l.Usuario_IDAlteracao = Convert.ToInt16(Session["iduser"]);
                l.Datalteracao = DateTime.Now;

                livro.AtualizaLivro(l);

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
                LivroViewModel l = new LivroViewModel();

                l.Datacadastro = DateTime.Now;
                l.Datalteracao = null;
                l.Descricao = Request.Form["descricao"];
                l.Excluido = 0;
                l.Usuario_IDCadastro = Convert.ToInt16(Session["loginuser"]);
                l.Usuario_IDAlteracao = null;
                l.AdicionaLivro(l);

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
            if (Session["loginuser"] != null){
               
                LivroViewModel l = new LivroViewModel();

                return View(l.CarregaLivro());
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
           if(Session["loginuser"]!=null) {

                string descricao = Request.Form["descricao"];

                
                LivroViewModel l = new LivroViewModel();

                return View("List", l.CarregaLivro(descricao));
               
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


        public JsonResult Delete(int idLivro)
        {
            if (Session["loginuser"] != null)
            {
                bool result = false;

                if (idLivro > 0)
                {

                    LivroViewModel l = new LivroViewModel();
                    l.ExcluiLivro(idLivro);

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
            else
            {
                return null;
            }
            
        }

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
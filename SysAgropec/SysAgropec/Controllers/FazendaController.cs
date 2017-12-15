using MySql.Data.MySqlClient;
using SysAgropec.Class;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SysAgropec.Controllers
{
    public class FazendaController : Controller
    {


        [System.Web.Mvc.HttpGet]
        public ActionResult Manipular()
        {
            if (Session["loginuser"] != null)
            {
                FazendaViewModel f = new FazendaViewModel();


                if (Convert.ToInt16(Session["admin"]) == 0)
                {
                    Usuario_Propriedade u = new Usuario_Propriedade();

                    List<Usuario_Propriedade> userprolist = u.getUserPropriedadeByID(Convert.ToInt16(Session["iduser"]));

                    ViewData["fazendas"] = f.CarregaFazendasUsuariosParticipantes(userprolist);

                }
                else
                {
                    ViewData["fazendas"] = f.CarregaFazendas();
                }

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

        public ActionResult Add()
        {
            if (Session["loginuser"] != null)
            {
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


        public ActionResult Edit(int ID)
        {
            if (Session["loginuser"] != null)
            {
                FazendaViewModel f = new FazendaViewModel();

                return PartialView("PartialView", f.CarregaFazenda());
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

        public ActionResult Update(Models.Propriedade p)
        {
            if (Session["loginuser"] != null)
            {

                FazendaViewModel f = new FazendaViewModel();

                p.Usuario_IDAlteracao = Convert.ToInt16(Session["iduser"]);
                p.Dataalteracao = DateTime.Now;

                f.AtualizaFazenda(p);

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
        public ActionResult Insert(FazendaViewModel f)
        {
            if (Session["loginuser"] != null) {
                
                FazendaViewModel fazenda = new FazendaViewModel();
                
                fazenda.Datacadastro = DateTime.Now;
                fazenda.Dataalteracao = null;
                fazenda.Usuario_IDCadastro = Convert.ToInt16(Session["iduser"]);
                fazenda.Usuario_IDAlteracao = null;
                fazenda.Bairro = f.Bairro;
                fazenda.Cep = String.Join("", System.Text.RegularExpressions.Regex.Split(f.Cep, @"[^\d]"));
                fazenda.Cidade = f.Cidade;
                fazenda.Cnpj = f.Cnpj;
                fazenda.Complemento = f.Complemento;
                fazenda.Estado = f.Estado;
                fazenda.Inscricaoestadual = f.Inscricaoestadual;
                fazenda.Inscricaomunicipal = f.Inscricaomunicipal;
                fazenda.Logradouro = f.Logradouro;
                fazenda.Nomefantasia = f.Nomefantasia;
                fazenda.Numero = f.Numero;
                fazenda.Razaosocial = f.Razaosocial;

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        file.SaveAs(path);
                        
                        fazenda.Logo = fileName;
                    }
                }

                
                fazenda.AdicionaFazenda(fazenda);

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
            if(Session["loginuser"] != null){

                FazendaViewModel f = new FazendaViewModel();

                return View(f.CarregaFazenda());
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

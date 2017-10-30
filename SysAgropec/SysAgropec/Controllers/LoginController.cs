using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SysAgropec.Models;

namespace SysAgropec.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Logar()
        {
          return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Logar", new RouteValueDictionary(
                            new
                            {
                                controller = "Login",
                                action = "Logar"
                            }));
        }

        [HttpPost]
        public ActionResult Valida()
        {


            string name = Request.Form["usuario"];
            string password = Request.Form["senha"];

            if (!name.Equals("") && !password.Equals(""))
            {
                UsuarioViewModel u = new UsuarioViewModel();

                if (u.ValidaUsuario(name, password) != null)
                {

                    Session["iduser"] = u.ID;
                    Session["loginuser"] = u.Login;
                    Session["nome"] = u.Nome;
                    Session["sobrenome"] = u.Sobrenome;
                    Session["admin"] = u.Admin;
                    Session["ultimoAcesso"] = Convert.ToDateTime(u.Dataultimoacesso).ToString("dd/MM/yyyy");
                    
                    u.AtualizaDataUltimoAcesso(u.ID, DateTime.Now);
                    
                    return RedirectToAction("Manipular", new RouteValueDictionary(
                            new
                            {
                                controller = "Fazenda",
                                action = "Manipular"
                            }));

                }
                else
                {

                    ViewData["msg"] = "Usuário não cadastrado";
                    return View("Logar");
                }

            }
            else
            {
                
                ViewData["msg"] = "Preencha os campos";
                return View("Logar");
            }

        }
            
    }
}

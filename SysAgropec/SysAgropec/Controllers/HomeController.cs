using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SysAgropec.Models;
namespace SysAgropec.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["loginuser"] !=null)
            {
                int id = Convert.ToInt16(Request.Form["fazenda"]);
                Session["idfazenda"] = id;

                FazendaViewModel f = new FazendaViewModel();

                Propriedade p = f.BuscaFazenda(id);

                Session["fazenda"] = p.Razaosocial;
                Session["email"] = p.Email;

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

        public ActionResult Inicio()
        {
            return View();
        }

    }
}
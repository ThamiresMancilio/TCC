using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SysAgropec.Controllers
{
    public class EstoqueController : Controller
    {
    

        // GET: Estoque
        public ActionResult Stock()
        {
            if (Session["loginuser"] != null)
            {
                Estoque_MedicamentoViewModel e = new Estoque_MedicamentoViewModel();

                return View(e.CarregaEstoque());
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
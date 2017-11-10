using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysAgropec.Controllers
{
    public class GraficoController : Controller
    {
        // GET: Grafico
        public ActionResult Show()
        {
            return View();
        }

        public ActionResult ProducaoAnual()
        {
            return View();
        }

    }
}
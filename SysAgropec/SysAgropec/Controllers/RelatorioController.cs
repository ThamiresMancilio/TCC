using SysAgropec.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SysAgropec.Controllers
{
    public class RelatorioController : Controller
    {
        private string titulo{get;set;}
        private string filtros { get; set; }
        private DateTime datIni { get; set; }
        private DateTime datFim { get; set; }
        private Relatorio getRelatorio(int tipo)
        {
            var rpt = new Relatorio();
            //ver aqui depois
            rpt.BasePath = Server.MapPath("/");
            
            rpt.PageTitle = titulo;
            rpt.PageTitle = titulo;
            rpt.ImprimirCabecalhoPadrao = true;
            rpt.ImprimirRodapePadrao = true;
            rpt.TipoRelatorio = tipo;
            rpt.Filtros = filtros;
            rpt.datIni = datIni;
            rpt.datFin = datFim;
            return rpt;
        }

        [HttpPost]
        public ActionResult GerarRelatorioAnimais()
        {
            if(Request.Form["datCadastro"] != null)
            {
                filtros = Environment.NewLine +  "Data de cadastro superior à " + Convert.ToDateTime(Request.Form["datCadastro"]).ToString("dd/MM/yyyy");
                datIni = Convert.ToDateTime(Request.Form["datCadastro"]);
            }

            if (Request.Form["datCadastroF"] != null)
            {
                filtros = filtros + Environment.NewLine + "Data de cadastro inferior à " + Convert.ToDateTime(Request.Form["datCadastroF"]).ToString("dd/MM/yyyy");
                datFim = Convert.ToDateTime(Request.Form["datCadastroF"]);
            }

            titulo = "Relatório de Animais por Raça";

            var rpt = getRelatorio(0);

            return File(rpt.GetOutput().GetBuffer(), "application/pdf");

        }

        [HttpPost]
        public ActionResult GerarRelatorioEstoque()
        {

            if (Request.Form["datEntrada"] != null)
            {
                filtros = Environment.NewLine + "Data de entrada no estoque superior à " + Convert.ToDateTime(Request.Form["datEntrada"]).ToString("dd/MM/yyyy");
                datIni = Convert.ToDateTime(Request.Form["datEntrada"]);
            }

            if (Request.Form["datEntradaf"] != null)
            {
                filtros = filtros + Environment.NewLine + "Data de entrada no estoque inferior à " + Convert.ToDateTime(Request.Form["datEntradaf"]).ToString("dd/MM/yyyy");
                datFim = Convert.ToDateTime(Request.Form["datEntradaf"]);
            }


            titulo = "Relatório de Estoque de Medicamentos";

            var rpt = getRelatorio(1);

            return File(rpt.GetOutput().GetBuffer(), "application/pdf");

        }


        [HttpPost]
        public ActionResult GerarRelatorioTOP()
        {
          
            if (Request.Form["datProducao"] != null)
            {
                filtros = Environment.NewLine + "Data de produção superior à " + Convert.ToDateTime(Request.Form["datProducao"]).ToString("dd/MM/yyyy");
                datIni = Convert.ToDateTime(Request.Form["datProducao"]);
            }

            if (Request.Form["datProducaof"] != null)
            {
                filtros = filtros + Environment.NewLine + "Data de produção inferior à " + Convert.ToDateTime(Request.Form["datProducaof"]).ToString("dd/MM/yyyy");
                datFim = Convert.ToDateTime(Request.Form["datProducaof"]);
            }
            titulo = "Relatório TOP Produção";

            var rpt = getRelatorio(2);

            return File(rpt.GetOutput().GetBuffer(), "application/pdf");

        }

        public ActionResult Animais()
        {
            return View();
        }

        public ActionResult Estoque()
        {


            return View();
        }

        public ActionResult ProducaoTOP()
        {


            return View();
        }
    }
}
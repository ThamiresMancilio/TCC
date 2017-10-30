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
    public class UsuarioController : Controller
    {
        // GET: Rebanho
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert()
        {
            string descricao = Request.Form["descricao"];

            //UsuarioModel m = new UsuarioModel();
            ////m.descricao = descricao;
            //m.insert();
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

    

        public ActionResult My_User()
        {
            return View();
        }
        
    }
}
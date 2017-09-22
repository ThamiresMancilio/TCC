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
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

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
            {
                string query = "Select * from livro order by descricao ";

                DataTable dtLivro = new DataTable();

                try
                {
                    MySqlConnection connection = new MySqlConnection(Banco.getConexao());
                    connection.Open();
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter(query, connection);
                    sqlDa.Fill(dtLivro);

                    return View(dtLivro);

                }
                catch (MySqlException msg)
                {
                    Console.WriteLine(msg.Message);
                }
                return View();
            }
        }

    

        public ActionResult My_USer()
        {
            return View();
        }
        
    }
}
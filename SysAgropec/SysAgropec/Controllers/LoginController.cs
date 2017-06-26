using MySql.Data.MySqlClient;
using SysAgropec.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SysAgropec.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login
        public ActionResult Logar()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Valida()
        {
       
            string coonn = "server=localhost;user id=root; password=thamires;persistsecurityinfo=True;database=sysagropec";


            string name = Request.Form["usuario"];
            string password = Request.Form["senha"];

            string query = "Select * from usuario where usuarios = '" + name + "' and senha = " + password;

            MySqlConnection Conexao = new MySqlConnection(coonn);
            
            MySqlCommand command = Conexao.CreateCommand();
            command.CommandText = query;
            
            try
            {
                Conexao.Open();
            }
            catch (Exception msg )
            {
                Console.WriteLine(msg.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {

                query = "Select * from propriedades inner join usuarios_propriedades on propriedades.id =  ";
                query = query + " usuarios_propriedades.propriedades.id where usuarios_propriedades.usuarios_id = " + reader["id"];

                command = Conexao.CreateCommand();
                command.CommandText = query;

                MySqlDataReader reader2 = command.ExecuteReader();

                if (reader2.HasRows)
                {

                    return View("", reader2);
                }
            }
            else //usuario não localizado
            {

            }

            return View();
        }
    }
}
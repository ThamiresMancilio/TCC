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
    public class RebanhoController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert()
        {

            string descricao = Request.Form["descricao"];
            string registro = Request.Form["registro"];
            string tatuagem = Request.Form["tatuagem"];
            int numerobrinco =Convert.ToInt16(Request.Form["numerobrinco"]);
            DateTime datanascimento = Convert.ToDateTime( Request.Form["datanascimento"]);
            int sexo = Convert.ToInt16(Request.Form["sexo"]);
            int livro = Convert.ToInt16(Request.Form["livro"]);
            int raca = Convert.ToInt16(Request.Form["raca"]);
            bool morto = Convert.ToBoolean(Request.Form["morto"]);
            //bool lactacao = Convert.ToBoolean(Request.Form["lactacao"]);
            int lactacao = 1;
            string observacao = Request.Form["observacao"];
            string descricaopai = Request.Form["descricaopai"];
            string registropai = Request.Form["registropai"];
            string tatuagempai = Request.Form["tatuagempai"];
            string descricaomae = Request.Form["descricaomae"];
            string registromae = Request.Form["registromaes"];
            string tatuagemae = Request.Form["tatuagemae"];


            //RebanhoModel m = new RebanhoModel();

            //m.datacadastro = DateTime.Now;
            //m.datanascimento = datanascimento;
            //m.descricao = descricao;
            //m.descricaomae = descricaomae;
            //m.descricaopai = descricaopai;
            //m.dias_lactacao = 0;
            //m.lactacao = lactacao;
            //m.livro_id = livro;
            //m.morto = morto;
            //m.numerobrinco = numerobrinco;
            //m.observacao = observacao;
            //m.propriedades_id = 1;
            //m.raca_id = 1;
            //m.registro = registro;
            //m.registromae = registromae;
            //m.registropai = registropai;
            //m.sexo = sexo;
            //m.tatuagem = tatuagem;
            //m.tatuagemae = tatuagemae;
            //m.tatuagempai = tatuagempai;
            //m.usuario_idcadastro = 1;
            


            
            //m.insert();
            return RedirectToAction("List");

        }

        [HttpPost]
        public ActionResult ListFiltros()

        {
            string query = "Select * from animais ";

            DataTable dtAnimais = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(Banco.getConexao());
                connection.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(query, connection);
                sqlDa.Fill(dtAnimais);

                return View(dtAnimais);

            }
            catch (MySqlException msg)
            {
                Console.WriteLine(msg.Message);
            }
            return View();
        }
        [HttpGet]
        public ActionResult List()
            
        {
            string query = "Select * from animais ";

            DataTable dtAnimais = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(Banco.getConexao());
                connection.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter(query, connection);
                sqlDa.Fill(dtAnimais);

                return View(dtAnimais);

            }
            catch (MySqlException msg)
            {
                Console.WriteLine(msg.Message);
            }
            return View();
        }
        
    }
}
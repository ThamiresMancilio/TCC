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
            int morto = Convert.ToInt16(Request.Form["morto"]);
            int lactacao = Convert.ToInt16(Request.Form["lactacao"]);
            string observacao = Request.Form["observacao"];
            string descricaopai = Request.Form["descricaopai"];
            string registropai = Request.Form["registropai"];
            string tatuagempai = Request.Form["tatuagempai"];
            string descricaomae = Request.Form["descricaomae"];
            string registromae = Request.Form["registromaes"];
            string tatuagemae = Request.Form["tatuagemae"];

            string query = "INSERT INTO `sysagropec`.`animais`";
            query = query + "(descricao,registro,tatuagem,numerobrinco,datanascimento,morto,observacao,";
            query = query + "datacadastro,datalteracao,registropai,tatuagempai,descricaopai,registromae,";
            query = query + "tatuagemae,descricaomae,sexo,lactacao,dias_lactacao,datalactacao,livro_id,";
            query = query + "raca_id,propriedades_id,usuario_idcadastro,usuario_idalteracao)";
            query = query + " VALUES (@descricao,@registro,@tatuagem,@numerobrinco,@datanascimento,";
            query = query + " @morto,@observacao,@datacadastro,@dataalteracao,@registropai,@tatuagempai,";
            query = query + " @descricaopai,@registromae,@tatuagemae,@descricaomae,@sexo,@lactacao,";
            query = query + "@diaslactacao,@datalactacao,@livroid,@racaid,@propriedadeid,";
            query = query + "@usuariocadastro,@usuarioalteracao);";

            MySqlConnection sqlCon = new MySqlConnection(Banco.getConexao());
                sqlCon.Open();
            MySqlCommand sqlCmd = new MySqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@descricao", descricao);
            sqlCmd.Parameters.AddWithValue("@registro",registro);
            sqlCmd.Parameters.AddWithValue("@tatuagem", tatuagem);
            sqlCmd.Parameters.AddWithValue("@numerobrinco", numerobrinco);
            sqlCmd.Parameters.AddWithValue("@datanascimento", datanascimento);
            sqlCmd.Parameters.AddWithValue("@morto", morto);
            sqlCmd.Parameters.AddWithValue("@observacao", observacao);
            sqlCmd.Parameters.AddWithValue("@datacadastro", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@dataalteracao", null);
            sqlCmd.Parameters.AddWithValue("@registropai", registropai);
            sqlCmd.Parameters.AddWithValue("@tatuagempai", tatuagempai);
            sqlCmd.Parameters.AddWithValue("@descricaopai", descricaopai);
            sqlCmd.Parameters.AddWithValue("@registromae", registromae);
            sqlCmd.Parameters.AddWithValue("@tatuagemae", tatuagemae);
            sqlCmd.Parameters.AddWithValue("@descricaomae", descricaomae);
            sqlCmd.Parameters.AddWithValue("@sexo", sexo);
            sqlCmd.Parameters.AddWithValue("@lactacao", lactacao);
            sqlCmd.Parameters.AddWithValue("@diaslactacao", 0);
            sqlCmd.Parameters.AddWithValue("@datalactacao", null);
            sqlCmd.Parameters.AddWithValue("@livroid", 1);
            sqlCmd.Parameters.AddWithValue("@racaid", 1);
            sqlCmd.Parameters.AddWithValue("@propriedadeid", 1);
            sqlCmd.Parameters.AddWithValue("@usuariocadastro", 1);
            sqlCmd.Parameters.AddWithValue("@usuarioalteracao", null);

            sqlCmd.ExecuteNonQuery();


            return RedirectToAction("List");


            
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
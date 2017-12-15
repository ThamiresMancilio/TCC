using MySql.Data.MySqlClient;
using SysAgropec.Class;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysAgropec.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Rebanho
        public ActionResult Add()
        {

            FazendaViewModel a = new FazendaViewModel();

            ViewData["fazendas"] = a.CarregaFazendas();

            return View();
        }
        public ActionResult My_User_Edit()
        {

            UsuarioViewModel u = new UsuarioViewModel();

            int iduser = Convert.ToInt16(Session["iduser"]);

            return View(u.CarregaUsuario(iduser));
        }

        public ActionResult Alteracao(Models.Usuario user)
        {
            if (Session["loginuser"] != null)
            {
                UsuarioViewModel usernew = new UsuarioViewModel();

                usernew.ID = Convert.ToInt16(Session["iduser"]);
                usernew.Datalteracao = DateTime.Now;
                usernew.Login = user.Login;
                usernew.Senha = user.Senha;
                usernew.Nome = user.Nome;
                usernew.Sobrenome = user.Sobrenome;
                usernew.Admin = user.Admin;
                usernew.Dataultimoacesso = DateTime.Now;

                usernew.AtualizaUsuario();

                Session["loginuser"] = user.Login;
                return RedirectToAction("My_User");

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

        public ActionResult Update(List<Models.Propriedade> propriedades)
        {
            if (Session["loginuser"] != null)
            {

                int iduser =Convert.ToInt16(Request["iduser"]);

                for (int i = 0; i< propriedades.Count; i++)
                {

                    bool isChecked = Convert.ToBoolean(Request["row_"+ propriedades[i].ID]);

                    if (isChecked)
                    {


                    }

                }
                
                return RedirectToAction("List");

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

        [HttpPost]
        public ActionResult Insert(UsuarioViewModel user)
        {
            
            UsuarioViewModel u = new UsuarioViewModel();

            u.Admin = user.Admin;
            u.Datacadastro = DateTime.Now.Date;
            u.Datalteracao = null;
            u.Dataultimoacesso = null;
            u.Excluido = 0;
            u.Login = user.Login;
            u.Nome = user.Nome;
            u.Senha = user.Senha;
            u.Sobrenome = user.Sobrenome;

            int idUser = u.AdicionaUsuario();
            
            if (idUser > 0)
            {

                FazendaViewModel a = new FazendaViewModel();

                List<FazendaViewModel> fazendas = a.CarregaFazendas();

                int value;

                for (int i = 0; i< fazendas.Count; i++)
                {
                    
                    value = Convert.ToInt16(Request["row_" + fazendas[i].ID]);

                    if (value > 0)
                    {


                        string commandText = "Insert into Usuario_Propriedade (Usuario_id,Propriedade_id) VALUES "
                        + " (@Usuario_id, @Propriedade_id)";

                        using (MySqlConnection connection = new MySqlConnection(Banco.getConexao()))
                        {
                            MySqlCommand command = new MySqlCommand(commandText, connection);

                            command.Parameters.AddWithValue("@Usuario_id", idUser);
                            command.Parameters.AddWithValue("@Propriedade_id", value);

                            try
                            {
                                connection.Open();
                                Int32 rowsAffected = command.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }

                }

            }
            
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            
            FazendaViewModel a = new FazendaViewModel();

            ViewData["fazendas"] = a.CarregaFazendas();

            if (Session["loginuser"] != null)
            {

                UsuarioViewModel u = new UsuarioViewModel();
                
                return View(u.CarregaUsuario(0));
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

        public JsonResult Delete(int idUsuario)
        {
            bool result = false;

            if (idUsuario > 0)
            {

                UsuarioViewModel u = new UsuarioViewModel();

                u.ExcluiUsuario(idUsuario);
                
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult Edit(int ID)
        {

            if (Session["loginuser"] != null)
            {
                List<Usuario_Propriedade> usuarios_propriedades = new List<Usuario_Propriedade>();

                string text = "Select * from Usuario_Propriedade where Usuario_ID = " + ID;

                using (MySqlConnection connection = new MySqlConnection(Banco.getConexao()))

                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(text, connection))
                    {

                        command.CommandType = CommandType.Text;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Usuario_Propriedade userpropri = new Usuario_Propriedade();

                                userpropri.Usuario_ID = reader.GetInt16(0);
                                userpropri.Propriedade_ID = reader.GetInt16(1);

                                usuarios_propriedades.Add(userpropri);
                            }
                        }
                    }

                    ViewData["fazendasusuarios"] = usuarios_propriedades;

                }

                FazendaViewModel a = new FazendaViewModel();

                ViewData["fazendasedit"] = a.CarregaFazendas();
                
                ViewData["iduser"] = ID;

                ViewData["numerofazendas"] = a.CarregaFazendas().Count;

                return PartialView("PartialView");

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

        public ActionResult My_User()
        {
            UsuarioViewModel u = new UsuarioViewModel();

            int iduser = Convert.ToInt16(Session["iduser"]);

            return View(u.CarregaUsuario(iduser));
        }
        
    }
}
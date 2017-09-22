using MySql.Data.MySqlClient;
using SysAgropec.Class;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;


namespace SysAgropec.Controllers
{
    public class FazendaController : Controller
    {
        //// GET: Login
        //[System.Web.Mvc.HttpGet]
        //public ActionResult Manipular()
        //{
        //    string query = "Select * from propriedades ";

        //    DataTable dtPropriedades = new DataTable();

        //    try
        //    {
        //        MySqlConnection connection = new MySqlConnection(Banco.getConexao());
        //        connection.Open();
        //        MySqlDataAdapter sqlDa = new MySqlDataAdapter(query, connection);
        //        sqlDa.Fill(dtPropriedades);

        //        return View(dtPropriedades);

        //    }
        //    catch (MySqlException msg)
        //    {
        //        Console.WriteLine(msg.Message);
        //    }
        //    return View();
        //}

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(int ID)
        {

            FazendaViewModel f = new FazendaViewModel();

            return PartialView("PartialView", f.CarregaFazenda());
        }

        public ActionResult Update(Models.Propriedade p)
        {
            FazendaViewModel f = new FazendaViewModel();
            
            p.Usuario_IDAlteracao = 1;  //Session["iduser"];
            p.Dataalteracao = DateTime.Now;

            f.AtualizaFazenda(p);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Insert()
        {

            FazendaViewModel fazenda = new FazendaViewModel();

            
            fazenda.Datacadastro = DateTime.Now;
            fazenda.Dataalteracao = null;
            fazenda.Usuario_IDCadastro = 1;
            fazenda.Usuario_IDAlteracao = null;
            fazenda.Bairro = Request.Form["Bairro"];
            fazenda.Cep = Request.Form["Cep"];
            fazenda.Cidade = Request.Form["Cidade"];
            fazenda.Cnpj = Request.Form["Cnpj"];
            fazenda.Complemento = Request.Form["Complemento"];
            fazenda.Estado = Request.Form["Estado"];
            fazenda.Inscricaoestadual = Request.Form["Inscricaoestadual"];
            fazenda.Inscricaomunicipal = Request.Form["Inscricaomunicipal"];
            fazenda.Logradouro = Request.Form["Logradouro"];
            fazenda.Nomefantasia = Request.Form["Nomefantasia"];
            fazenda.Numero = Request.Form["Numero"];
            fazenda.Razaosocial = Request.Form["Razaosocial"];
            fazenda.Logo = Request.Form["Logo"];

            

            fazenda.AdicionaFazenda(fazenda);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult List()
        {
            {

                LivroViewModel l = new LivroViewModel();

                return View(l.CarregaLivro());
            }
        }

        [HttpPost]
        public ActionResult ListWithParameters()
        {
            {
                string descricao = Request.Form["descricao"];

                if (!descricao.Equals(""))
                {

                    LivroViewModel l = new LivroViewModel();


                    return View("List", l.CarregaLivro(descricao));
                }


                return View("List");
            }
        }

        public JsonResult UploadImage() {

            String filepath = "";
            String caminhoTMP = "C:\\Users\\Acer\\Documents\\SysAgropec\\SysAgropec\\SysAgropec\\upload_images\\";
            String pasta = "upload_images";
            String imagem ="";
            String imagemEnviada = "";
            String content = "";
            for (int i = 0; i <= Request.Files.Count - 1; i++)
            {

                if (!Request.Files[i].FileName.Equals(""))
                {
                    Request.Files[i].SaveAs(caminhoTMP + Request.Files[i].FileName);

                    imagem = "caption:" + Request.Files[i].FileName + " height:120px url:deleteimage.aspx key:" + Request.Files[i].FileName;

                    imagemEnviada = "<img  height='120px' , src='" + pasta + Request.Files[i].FileName + "' class='file-preview-image'>";
                    content = "{file_id:0 , overwriteInitial:" + true + ", initialPreviewConfig" + imagem + " , initialPreview:" + imagemEnviada;
                }
                return Json(filepath, JsonRequestBehavior.AllowGet);

            }
            return null;

        }


        public JsonResult Delete(int idLivro)
        {
            bool result = false;

            if (idLivro > 0)
            {

                LivroViewModel l = new LivroViewModel();
                l.ExcluiLivro(idLivro);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }




    }
}

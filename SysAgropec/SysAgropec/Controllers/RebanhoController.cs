﻿using MySql.Data.MySqlClient;
using SysAgropec.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SysAgropec.Controllers
{
    public class RebanhoController : Controller
    {

        
        [HttpGet]
        public ActionResult Add()
        {

            if (Session["loginuser"] != null)
            {

                sysagropecEntities db = new sysagropecEntities();

                List<Livro> listlivro = db.Livro.ToList();
                ViewBag.LivroLista = new SelectList(listlivro, "ID", "Descricao");
                
                List<Raca> listraca = db.Raca.ToList();
                ViewBag.RacaLista = new SelectList(listraca, "ID", "Descricao");


                return View();

            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            if(Session["loginuser"]!=null){

                AnimalViewModel a = new AnimalViewModel();

                return View(a.CarregaAnimal(-1, "", "",""));

            } else
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
        public ActionResult Insert(AnimalViewModel model)
        {

            if (Session["loginuser"] != null)
            {

                try
                {
                    sysagropecEntities db = new sysagropecEntities();

                    List<Raca> listraca = db.Raca.ToList();

                    ViewBag.RacaList = new SelectList(listraca, "ID", "Descricao");

                    List<Livro> listlivro = db.Livro.ToList();

                    ViewBag.LivroList = new SelectList(listlivro, "ID", "Descricao");

                    Animal a = new Animal();

                    a.Datacadastro = DateTime.Now;

                    var m = Request.Form["Morto"];
                    var l = Request.Form["lactacao"];
                    var s = Request.Form["Sexo"];


                    a.Datalactacao = DateTime.Now;
                    


                    a.Lactacao = 1;

                    if (l == null)
                    {
                        a.Lactacao = 0;
                        a.Dias_lactacao = 0;
                    }
                    else
                    {
                        a.Lactacao = 1;
                        a.Dias_lactacao = 1;
                    }


                    if (m == null)
                    {
                        a.Morto = 0;
                    }
                    else
                    {
                        a.Morto = 1;
                    }
                     
                    
                    a.Datanascimento = model.Datanascimento;
                    a.Descricao = model.Descricao;
                    a.Descricaomae = model.Descricaomae;
                    a.Descricaopai = model.Descricaopai;
                    a.Livro_ID = model.Livro_ID;
                    a.Morto = model.Morto;
                    a.Numerobrinco = model.Numerobrinco;
                    a.Observacao = model.Observacao;
                    a.Propriedade_ID = Convert.ToInt16(Session["idfazenda"]);
                    a.Raca_ID = model.Raca_ID;
                    a.Registro = model.Registro;
                    a.Registromae = model.Registromae;
                    a.Registropai = model.Registropai;
                    a.Sexo = model.Sexo;
                    a.Tatuagem = model.Tatuagem;
                    a.Tatuagemae = model.Tatuagemae;
                    a.Tatuagempai = model.Tatuagempai;
                    a.Usuario_IDCadastro = Convert.ToInt16(Session["iduser"]);
                    

                    db.Animal.Add(a);
                    db.SaveChanges();

                    int latestEmpId = a.ID;


                    return RedirectToAction("List");

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }

        }

        public ActionResult Edit(int ID)
        {

            if (Session["loginuser"] != null)
            {

                sysagropecEntities db = new sysagropecEntities();

                List<Raca> listraca = db.Raca.ToList();
                ViewBag.RacaList = new SelectList(listraca, "ID", "Descricao");

                List<Livro> listlivro = db.Livro.ToList();
                ViewBag.LivroList = new SelectList(listlivro, "ID", "Descricao");

                AnimalViewModel a = new AnimalViewModel();

                return PartialView("PartialView", a.BuscaAnimal(ID));

            }else
            {
                return RedirectToAction("Logar", new RouteValueDictionary(
                new
                {
                    controller = "Login",
                    action = "Logar"
                }));
            }
        }

        public ActionResult Update(Animal a)
        {
            if (Session["loginuser"] != null)
            {

                AnimalViewModel animal = new AnimalViewModel();

                a.Usuario_IDAlteracao = Convert.ToInt16(Session["iduser"]);
                a.Datalteracao = DateTime.Now;

                animal.AtualizaAnimal(a);

                return RedirectToAction("List");

            } else
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
        public ActionResult ListWithParameters()
        {
            if (Session["loginuser"] != null)
            {
                string registro = Request.Form["registro"];
                string registro2 = Request.Form["registro2"];
                string tatuagem = Request.Form["tatuagem"];
                int sexo = Convert.ToInt16(Request.Form["Sexo"]);
           

                AnimalViewModel a = new AnimalViewModel();

                return View("List", a.CarregaAnimal(sexo, registro, registro2, tatuagem));

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


        public JsonResult Delete(int idAnimal)
        {
            bool result = false;

            if (idAnimal > 0)
            {

                AnimalViewModel m = new AnimalViewModel();

                m.ExcluiAnimal(idAnimal);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

    }
}
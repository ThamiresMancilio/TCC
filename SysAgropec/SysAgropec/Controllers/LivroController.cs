﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysAgropec.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}
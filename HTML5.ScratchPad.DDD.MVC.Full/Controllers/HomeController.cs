﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HTML5.ScratchPad.DDD.MVC.Full.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
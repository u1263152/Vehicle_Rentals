﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BC_Rentals.Controllers
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

        public ActionResult StockView()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BookRentalView()
        {
            ViewBag.Message = "Book a Rental.";

            return View();
        }

        public ActionResult ManageRentalView()
        {
            ViewBag.Message = "Manage Rentals.";

            return View();
        }
    }
}
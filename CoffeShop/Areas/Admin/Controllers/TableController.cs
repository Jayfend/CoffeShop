﻿using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeShop.Areas.Admin.Controllers
{
    public class TableController : Controller
    {
        // GET: Admin/Table
        public ActionResult Index()
        {
            BillService billservice = new BillService();
            Login Login = new Login();
            var billlist = billservice.GetBill();
            ViewBag.Table = "active";
            ViewBag.AccountList = Login.getinfo();
            return View(billlist);
        }
    }
}
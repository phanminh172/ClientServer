using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Admin/Statistic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StatisticSalary()
        {
            return View();
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class WorkController : Controller
    {
        // GET: Admin/Work
        public ActionResult Index()
        {
            return View();
        }
    }
}
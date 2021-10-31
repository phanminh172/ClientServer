using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class DiaryController : Controller
    {
        // GET: Admin/Diary
        public ActionResult Index()
        {
            return View();
        }
    }
}
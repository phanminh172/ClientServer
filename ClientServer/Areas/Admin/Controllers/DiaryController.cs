using ClientServer.Models.DAO;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            var diaryDAO = new DiaryDAO();
            var diaryList = diaryDAO.ListAll();
            return View(diaryList);
        }

        public ActionResult Detail(int id)
        {
            dynamic mymodel = new ExpandoObject();
            var diaryDao = new DiaryDAO();
            mymodel = diaryDao.GetById(id);
            return View(mymodel);
        }
    }
}
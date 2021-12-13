using ClientServer.Areas.Admin.Models;
using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        ClientServerDbContext context;
        // GET: Admin/Statistic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StatisticSalaryMonth(int page = 1, int pageSize = 5)
        {
            return View();
        }
        public ActionResult WorkMaxValue(int page = 1, int pageSize = 5)
        {
            var statisticDAO = new StatisticDAO();
            var max = statisticDAO.MaxValue(page, pageSize);
            return View(max);
        }
        public ActionResult WorkMinValue(int page = 1, int pageSize = 5)
        {
            var statisticDAO = new StatisticDAO();
            var max = statisticDAO.MinValue(page, pageSize);
            return View(max);
        }
        public ActionResult HigherAvg(int page = 1, int pageSize = 5)
        {
            var statisticDAO = new StatisticDAO();
            var max = statisticDAO.HigherAvg(page, pageSize);
            return View(max);
        }
        public ActionResult LowerAvg(int page = 1, int pageSize = 5)
        {
            var statisticDAO = new StatisticDAO();
            var max = statisticDAO.LowerAvg(page, pageSize);
            return View(max);
        }
        public ActionResult MaxDiary(int page = 1, int pageSize = 10)
        {
            var statisticDAO = new StatisticDAO();
            var max = statisticDAO.MaxDiary(page, pageSize);
            return View(max);
        }
        
        public ActionResult WeekDiary(string searchString, DateTime? searchDate, int page = 1, int pageSize = 10)
        {
            var statisticDAO = new StatisticDAO();
            var max = statisticDAO.WeekDiary(searchString, searchDate, page, pageSize);
            ViewBag.searchString = searchString;
            ViewBag.searchDate = searchDate;
            return View(max);
        }
    }
}
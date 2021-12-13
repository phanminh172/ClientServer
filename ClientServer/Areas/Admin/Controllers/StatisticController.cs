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
        public ActionResult Index(int? sortOrder, string searchString, DateTime? searchDate, int page = 1, int pageSize = 10)
        {
            var statisticDAO = new StatisticDAO();
            var res = statisticDAO.WeekDiary(sortOrder, searchString, searchDate, page, pageSize);
            ViewBag.searchString = searchString;
            ViewBag.searchDate = searchDate;
            ViewBag.sortOrder = sortOrder;
            return View(res);
        }
        public ActionResult StatisticSalary(int? sortOrder,DateTime? searchDate, int page = 1, int pageSize = 10)
        {
            var statisticDAO = new StatisticDAO();
            var res = statisticDAO.StatisticSalary(sortOrder, searchDate, page, pageSize);
            ViewBag.searchDate = searchDate;
            ViewBag.sortOrder = sortOrder;
            return View(res);
        }
        public ActionResult StatisticEmployee(int? sortOrder,int page = 1, int pageSize = 10)
        {
            var statisticDAO = new StatisticDAO();
            var res = statisticDAO.StatisticEmployee(sortOrder,page, pageSize);
            ViewBag.sortOrder = sortOrder;
            return View(res);
        }
    }
}
using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        ClientServerDbContext context;
        // GET: Admin/Employee
        public ActionResult Index(string searchPhongBan, string searchChucVu,
            string fromAge, string toAge, String searchString, int page = 1, int pageSize = 10)
        {
            var employeeDAO = new EmployeeDAO();
            var res = employeeDAO.ListAll(searchPhongBan, searchChucVu, fromAge, toAge, searchString, page, pageSize);
            ViewBag.searchString = searchString;
            ViewBag.searchPhongBan = searchPhongBan;
            ViewBag.searchChucVu = searchChucVu;
            ViewBag.fromAge = fromAge;
            ViewBag.toAge = toAge;
            return View(res);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThongTinCongNhan employee)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDAO();
                int id = dao.Insert(employee);
                if (id > 0)
                {
                    TempData["thongbao"] = "Thêm mới nhân viên thành công!";
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    TempData["thongbao"] = "Thêm nhân viên thất bại";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new EmployeeDAO();

            //Lấy ra đối tượng sp theo mã
            ThongTinCongNhan employee = dao.GetById(id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ThongTinCongNhan employee)
        {
            //Thêm vào CSDL
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDAO();
                if (dao.Update(employee) == true)
                {
                    TempData["thongbao"] = "Chỉnh sửa thành công!";
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    TempData["thongbao"] = "Chỉnh sửa thất bại!!";
                }
            }
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            var dao = new EmployeeDAO();
            if (dao.Delete(id) == true)
            {
                TempData["thongbao"] = "Xóa thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["thongbao"] = "Xóa thất bại!!";
            }
            return View("Index");
        }
    }
}
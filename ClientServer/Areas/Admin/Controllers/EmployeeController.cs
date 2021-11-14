using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Index(String searchString, int page = 1, int pageSize = 5)
        {
            var employeeDAO = new EmployeeDAO();
            var employeeList = employeeDAO.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(employeeList);
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
                if(dao.Update(employee) == true)
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
            if(dao.Delete(id) == true)
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
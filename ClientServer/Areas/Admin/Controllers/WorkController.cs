﻿using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
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
            var workDAO = new WorkDAO();
            var workList = workDAO.ListAll();
            return View(workList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMucCongViec Work)
        {
            if (ModelState.IsValid)
            {
                var dao = new WorkDAO();
                int id = dao.Insert(Work);
                if (id > 0)
                {
                    TempData["thongbao"] = "Thêm mới Công việc thành công!";
                    return RedirectToAction("Index", "Work");
                }
                else
                {
                    TempData["thongbao"] = "Thêm Công việc thất bại";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new WorkDAO();

            //Lấy ra đối tượng sp theo mã
            DanhMucCongViec Work = dao.GetById(id);
            if (Work == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Work);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(DanhMucCongViec Work)
        {
            //Thêm vào CSDL
            if (ModelState.IsValid)
            {
                var dao = new WorkDAO();
                if (dao.Update(Work) == true)
                {
                    TempData["thongbao"] = "Chỉnh sửa thành công!";
                    return RedirectToAction("Index", "Work");
                }
                else
                {
                    TempData["thongbao"] = "Chỉnh sửa thất bại!!";
                }
            }
            return View(Work);
        }
        public ActionResult Delete(int id)
        {
            var dao = new WorkDAO();
            if (dao.Delete(id) == true)
            {
                TempData["thongbao"] = "Xóa thành công!";
            }
            else
            {
                TempData["thongbao"] = "Xóa thất bại!!";
            }
            return RedirectToAction("Index");
        }
    }
}
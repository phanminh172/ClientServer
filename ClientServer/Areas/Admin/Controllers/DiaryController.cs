using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
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
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var diaryDAO = new DiaryDAO();
            var diaryList = diaryDAO.ListAll(page, pageSize);
            return View(diaryList);
        }

        [HttpPost]
        public ActionResult ListByDate(DateTime search, int page = 1, int pageSize = 10)
        {
            var diaryDAO = new DiaryDAO();
            var diaryList = diaryDAO.ListByDate(search, page, pageSize);
            return View(diaryList);
        } 

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhatKiSanLuongKhoan Diary)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiaryDAO();
                int id = dao.Insert(Diary);
                if (id > 0)
                {
                    TempData["thongbao"] = "Thêm mới nhật ký thành công!";
                    return RedirectToAction("Index", "Diary");
                }
                else
                {
                    TempData["thongbao"] = "Thêm nhật ký thất bại";
                }
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            dynamic mymodel = new ExpandoObject();
            var diaryDao = new DiaryDAO();
            mymodel = diaryDao.GetById(id);
            return View(mymodel);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new DiaryDAO();
            NhatKiSanLuongKhoan Diary = dao.FindById(id);
            if (Diary == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Diary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(NhatKiSanLuongKhoan Diary)
        {
            //Thêm vào CSDL
            if (ModelState.IsValid)
            {
                var dao = new DiaryDAO();
                if (dao.Update(Diary) == true)
                {
                    TempData["thongbao"] = "Chỉnh sửa thành công!";
                    return RedirectToAction("Index", "Diary");
                }
                else
                {
                    TempData["thongbao"] = "Chỉnh sửa thất bại!!";
                }
            }
            return View(Diary);
        }
        public ActionResult Delete(int id)
        {
            var dao = new DiaryDAO();
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

        public void SetEmployeeDropDownList(int? id = null)
        {
            var employeeDAO = new EmployeeDAO();
            ViewBag.DanhSachCongNhan = new SelectList(employeeDAO.DropDownList(), "MaCongNhan", "Hoten",id);
        }

        public ActionResult AddEmployee(int id)
        {
            ViewBag.MaNhatKi = id;
            SetEmployeeDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(DanhMucCongNhanThucHienKhoan employee)
        {
            if(ModelState.IsValid)
            {
                var dao = new EmployeeInDiaryDAO();
                int id = dao.Insert(employee);
                if (id > 0)
                {
                    TempData["thongbao"] = "Thêm nhân viên vào nhật ký thành công!";
                    return RedirectToAction("Detail", new { id = employee.MaNhatKi });
                }
                else
                {
                    TempData["thongbao"] = "Thêm nhân viên thất bại";
                }
            }
            SetEmployeeDropDownList();
            return View();
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int diaryId, int employeeId)
        {
            var dao = new EmployeeInDiaryDAO();
            //Lấy ra đối tượng sp theo mã
            DanhMucCongNhanThucHienKhoan employee = dao.GetById(employeeId);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SetEmployeeDropDownList(employee.MaCongNhan);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(DanhMucCongNhanThucHienKhoan employee)
        {
            //Thêm vào CSDL
            if (ModelState.IsValid)
            {
                var dao = new EmployeeInDiaryDAO();
                if (dao.Update(employee) == true)
                {
                    TempData["thongbao"] = "Chỉnh sửa thành công!";
                    return RedirectToAction("Detail", new { id = employee.MaNhatKi });
                }
                else
                {
                    TempData["thongbao"] = "Chỉnh sửa thất bại!!";
                }
            }
            SetEmployeeDropDownList(employee.MaCongNhan);
            return View(employee);
        }

        public ActionResult DeleteEmployee(int diaryId, int employeeId)
        {
            var dao = new EmployeeInDiaryDAO();
            if (dao.Delete(employeeId) == true)
            {
                TempData["thongbao"] = "Xóa thành công!";
            }
            else
            {
                TempData["thongbao"] = "Xóa thất bại!!";
            }

            return RedirectToAction("Detail", new { id = diaryId });
        }

        public void SetWorkDropDownList(int? id = null)
        {
            var workDAO = new WorkDAO();
            ViewBag.DanhSachCongViec = new SelectList(workDAO.DropDownList(), "MaCongViec", "TenCongViec", id);
        }

        public void SetProductDropDownList(int? id = null)
        {
            var productDAO = new ProductDAO();
            ViewBag.DanhSachSanPham = new SelectList(productDAO.DropDownList(), "MaSanPham", "TenSanPham", id);
        }

        public ActionResult AddWork(int id)
        {
            ViewBag.MaNhatKi = id;
            SetWorkDropDownList();
            SetProductDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult AddWork(DanhMucCongViecDaLam work)
        {
            if (ModelState.IsValid)
            {
                var dao = new WorkInDiaryDAO();
                int id = dao.Insert(work);
                if (id > 0)
                {
                    TempData["thongbao2"] = "Thêm công việc vào nhật ký thành công!";
                    return RedirectToAction("Detail", new { id = work.MaNhatKi });
                }
                else
                {
                    TempData["thongbao2"] = "Thêm công việc thất bại";
                }
            }
            SetWorkDropDownList();
            SetProductDropDownList();
            return View();
        }

        [HttpGet]
        public ActionResult UpdateWork(int diaryId, int workId)
        {
            var dao = new WorkInDiaryDAO();
            //Lấy ra đối tượng sp theo mã
            DanhMucCongViecDaLam work = dao.GetById(workId);
            if (work == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SetWorkDropDownList(work.MaCongViec);
            SetProductDropDownList(work.MaSanPham);
            return View(work);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateWork(DanhMucCongViecDaLam work)
        {
            //Thêm vào CSDL
            if (ModelState.IsValid)
            {
                var dao = new WorkInDiaryDAO();
                if (dao.Update(work) == true)
                {
                    TempData["thongbao2"] = "Chỉnh sửa thành công!";
                    return RedirectToAction("Detail", new { id = work.MaNhatKi });
                }
                else
                {
                    TempData["thongbao2"] = "Chỉnh sửa thất bại!!";
                }
            }
            SetWorkDropDownList(work.MaCongViec);
            SetProductDropDownList(work.MaSanPham);
            return View(work);
        }

        public ActionResult DeleteWork(int diaryId, int workId)
        {
            var dao = new WorkInDiaryDAO();
            if (dao.Delete(workId) == true)
            {
                TempData["thongbao2"] = "Xóa thành công!";
            }
            else
            {
                TempData["thongbao2"] = "Xóa thất bại!!";
            }

            return RedirectToAction("Detail", new { id = diaryId });
        }
    }

}
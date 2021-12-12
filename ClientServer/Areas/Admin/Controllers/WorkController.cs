using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class WorkController : Controller
    {
        ClientServerDbContext context;
        List<DanhMucCongViec> getlstCongViec()
        {
            context = new ClientServerDbContext();
            var lst = context.DanhMucCongViecs.SqlQuery("Select * from DanhMucCongViec").ToList<DanhMucCongViec>();
            return lst;
        }

        //GET: Admin/Work
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pageSize = 5)
        {
            
            var workDAO = new WorkDAO();
            var workList = workDAO.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;

            return View(workList);
        }

        public ActionResult Search(string searchString, int page = 1, int pageSize = 5)
        {
            context = new ClientServerDbContext();
            var query = "Select * from DanhMucCongViec";
            switch (ViewBag.CurrentSort)
            {
                case '2':
                    query = "Select * from DanhMucCongViec WHERE DonGia > (SELECT AVG(DonGia) FROM DanhMucCongViec)";
                    break;
                case 3:

                    break;
                default:
                    query = query + " WHERE TenCongViec LIKE N'%" + searchString + "%'";
                    break;
            }
            var lstLoaiSanPham = context.DanhMucCongViecs.SqlQuery(query);
            return View(lstLoaiSanPham.ToPagedList(page, pageSize));
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
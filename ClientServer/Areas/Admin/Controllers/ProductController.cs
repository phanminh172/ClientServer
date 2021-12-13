using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ClientServerDbContext context;
        List<ThongTinSanPham> getlstSanpham()
        {
            context = new ClientServerDbContext();
            var lst = context.ThongTinSanPhams.SqlQuery("Select * from ThongTinSanPham").ToList<ThongTinSanPham>();
            return lst;
        }
    //    public ActionResult Index(string sortOrder, string currentFilter, string searchString,
    //        int? loaiSanPhamID, int? khoangGiaTu, int? khoangGiaDen, int? page)
    //    {
    //        db = new BanHangEntity();
    //        if (Session["username"] == null)
    //            return RedirectToAction("Index", "Users");
    //        else
    //        {
    //            ViewBag.CurrentSort = sortOrder;
    //            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
    //            ViewBag.GiaBanSortParm = sortOrder == "giaban" ? "giaban_desc" : "giaban";
    //            ViewBag.KyHieuSortParm = sortOrder == "kyhieu" ? "kyhieu_desc" : "kyhieu";
    //            ViewBag.loaiSanPhamID = new SelectList(db.LoaiSanPhams, "LoaiSanPhamID", "TenLoai", loaiSanPhamID);
    //            ViewBag.khoangGiaTu = khoangGiaTu;
    //            ViewBag.khoangGiaDen = khoangGiaDen;
    //            if (searchString != null)
    //            {
    //                page = 1;
    //            }
    //            else
    //            {
    //                searchString = currentFilter;
    //            }

    //            ViewBag.CurrentFilter = searchString;
    //            string query = "Select * from SanPham ";
    //            string qrten = "";
    //            string qrgiatu = "";
    //            string qrgiaden = "";
    //            if (!String.IsNullOrEmpty(searchString))
    //                qrten = "(TenSanPham like N'%" + searchString + "%' or KyHieuSanPham like N'%" + searchString + "%')";

    //            if (khoangGiaTu.HasValue)
    //                qrgiatu = "GiaBan >= " + khoangGiaTu;

    //            if (khoangGiaDen.HasValue)
    //                qrgiaden = "GiaBan <= " + khoangGiaDen;

    //            if (loaiSanPhamID.HasValue)
    //                query = query + ", LoaiSanPham where LoaiSanPham.LoaiSanPhamID = SanPham.LoaiSanPhamID and SanPham.LoaiSanPhamID = " + loaiSanPhamID;
    //            if (!String.IsNullOrEmpty(searchString) || (khoangGiaTu.HasValue) || (khoangGiaDen.HasValue))
    //                query = query + (loaiSanPhamID.HasValue ? " and " : " where ") + qrten + (qrgiatu != "" ? (qrten != "" ? " and " : "") + qrgiatu : "") + (qrgiaden != "" ? (qrgiatu != "" ? " and " : "") + qrgiaden : "");

    //            switch (sortOrder)
    //            {
    //                case "name_desc":
    //                    query = query + " order by TenSanPham desc ";
    //                    break;
    //                case "name":
    //                    query = query + " order by TenSanPham ";
    //                    break;
    //                case "kyhieu":
    //                    query = query + " order by KyHieuSanPham ";
    //                    break;
    //                case "kyhieu_desc":
    //                    query = query + " order by KyHieuSanPham desc ";
    //                    break;
    //                case "giaban":
    //                    query = query + " order by GiaBan ";
    //                    break;
    //                case "giaban_desc":
    //                    query = query + " order by GiaBan desc ";
    //                    break;
    //                default:  // new pro
    //                    query = query + " order by LaSanPhamMoi desc";
    //                    break;
    //            }

    //            int pageSize = 5;
    //            int pageNumber = (page ?? 1);
    //            var lstLoaiSanPham = db.SanPhams.SqlQuery(query);
    //            return View(lstLoaiSanPham.ToPagedList(pageNumber, pageSize));
    //        }
    //    }
    //}
    // GET: Admin/Product
    public ActionResult Index(int? sortOrder, DateTime? searchDate, String searchString,int page = 1, int pageSize = 10)
        {
            var productDAO = new ProductDAO();
            var productList = productDAO.ListAll(sortOrder,searchDate, searchString, page, pageSize);
            ViewBag.searchString = searchString;
            ViewBag.sortOrder = new SelectListItem()
            {
                Selected = sortOrder.HasValue
            };
            ViewBag.searchDate = searchDate;
            return View(productList);
        }
        //public ActionResult maxDiary(String searchString, int page = 1, int pageSize = 5)
        //{
        //    var productDAO = new ProductDAO();
        //    var productList = productDAO.ListAll(searchString, page, pageSize);
        //    ViewBag.searchString = searchString;
        //    return View(productList);
        //}

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThongTinSanPham collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ProductDAO();
                    int res = model.Create(collection.TenSanPham, collection.SoDangKy, collection.HanSuDung, collection.QuyCach, collection.NgayDangKy);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("","Error when add new item");
                    }
                }
                // TODO: Add insert logic here

                return View(collection);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            //var product = new ProductDAO().GetById(id);
            //return View(product);

            var dao = new ProductDAO();

            //Lấy ra đối tượng sp theo mã
            ThongTinSanPham product = dao.GetById(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThongTinSanPham collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
              
                //var result = dao.Update(collection);
                if (dao.Update(collection) == true)
                {

                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm không thành công");
                }
            }
            return View(collection);
        }
        public ActionResult Delete(int id)
        {
            var dao = new ProductDAO();
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
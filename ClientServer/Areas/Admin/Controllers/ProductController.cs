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
        // GET: Admin/Product
        public ActionResult Index(String searchString,int page = 1, int pageSize = 5)
        {
            var productDAO = new ProductDAO();
            var productList = productDAO.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(productList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThongTinSanPham Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                int id = dao.Insert(Product);
                if (id > 0)
                {
                    TempData["thongbao"] = "Thêm mới sản phẩm thành công!";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    TempData["thongbao"] = "Thêm sản phẩm thất bại";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new ProductDAO();

            //Lấy ra đối tượng sp theo mã
            ThongTinSanPham Product = dao.GetById(id);
            if (Product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ThongTinSanPham Product)
        {
            //Thêm vào CSDL
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                if (dao.Update(Product) == true)
                {
                    TempData["thongbao"] = "Chỉnh sửa thành công!";
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    TempData["thongbao"] = "Chỉnh sửa thất bại!!";
                }
            }
            return View(Product);
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
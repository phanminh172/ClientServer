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
        public ActionResult Index()
        {
            var productDAO = new ProductDAO();
            var productList = productDAO.ListAll();
            return View(productList);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
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

        // POST: Admin/Product/Edit/5
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

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
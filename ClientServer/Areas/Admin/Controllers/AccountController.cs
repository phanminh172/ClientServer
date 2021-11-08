using ClientServer.Areas.Admin.Code;
using ClientServer.Models.DAO;
using ClientServer.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Create(Account user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new AccountDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Account user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                }


                var result = dao.Update(user);
                if (result)
                {
                    
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }
    }
}
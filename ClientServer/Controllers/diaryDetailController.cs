using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientServer.Controllers
{
    public class diaryDetailController : Controller
    {
        // GET: diaryDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: diaryDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: diaryDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: diaryDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: diaryDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: diaryDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: diaryDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: diaryDetail/Delete/5
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
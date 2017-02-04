using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CURDOPERATION.Models;
using CURDOPERATION.Repository;

namespace CURDOPERATION.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult GetProducts()
        {
            Repository.PrdRepository prd = new PrdRepository();
            ModelState.Clear();
            return View(prd.GetProducts());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        [HttpGet]
        public ActionResult AddProducts()
        {
            return View();
        }
        // POST: Products/Create
        [HttpPost]
        public ActionResult AddProducts(Models.ProductsModel prod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.PrdRepository PrdtRepo = new Repository.PrdRepository();
                    if (PrdtRepo.AddProducts(prod))
                    {
                        // ViewBag.Message = "Data inserted Succesfully";
                        RedirectToAction("GetProducts", "Products");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CURDOPERATION.Models;
using CURDOPERATION.Repository;
using System.Net;

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
            string retmsg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.PrdRepository PrdtRepo = new Repository.PrdRepository();
                    PrdtRepo.AddProducts(prod, out retmsg);
                  
                        // ViewBag.Message = "Data inserted Succesfully";
                        if (retmsg == "ok")
                        {
                           ViewBag.Message = "Data inserted Succesfully";
                           return RedirectToAction("GetProducts", "Products");
                         }
                         else {
                            ViewBag.Message = retmsg;   
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
        public ActionResult UpdateProduct(int productID )
        {
            PrdRepository rpd = new Repository.PrdRepository();
            return View(rpd.GetProducts().Find (product=>product.productID== productID));
                  
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult UpdateProduct(int product,ProductsModel objupd)
        {
            try
            {
              
                    Repository.PrdRepository PrdtRepo = new Repository.PrdRepository();

                    PrdtRepo.UpdProduct(objupd);
               

                return RedirectToAction("GetProduct");
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

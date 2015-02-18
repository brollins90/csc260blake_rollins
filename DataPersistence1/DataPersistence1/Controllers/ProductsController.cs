using DataPersistence1.DAL;
using DataPersistence1.Interfaces;
using DataPersistence1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace DataPersistence1.Controllers
{
    public class ProductsController : Controller
    {
        private IDAL DAL = new FlatFileDAL(HostingEnvironment.MapPath("~\\Products"));

        // GET: Products
        public ActionResult Index(string sort)
        {
            string sortBy = (string.IsNullOrEmpty(sort)) ? "name" : sort;
            IEnumerable<Product> products = DAL.GetProducts();
            switch(sortBy) 
            {
                case "name":
                    products = products.OrderBy(x => x.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(x => x.Name);
                    break;
                case "price":
                    products = products.OrderBy(x => x.Cost);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(x => x.Cost);
                    break;
            }

            return View("ProductList", products);
        }


        // View one
        public ActionResult Product(int id)
        {
            Product product = DAL.GetProduct(id);
            return View("ProductView", product);
        }

        // Create a new product
        public ActionResult Create()
        {
            return View("ProductForm");
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                DAL.AddProduct(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("ProductForm");
            }
        }


        // Update an existing product
        public ActionResult Edit(int id)
        {
            Product product = DAL.GetProduct(id);
            return View("ProductForm", product);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                DAL.UpdateProduct(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("ProductForm", p);
            }
        }


        // Update an existing product
        public ActionResult Remove(int id)
        {
            DAL.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}
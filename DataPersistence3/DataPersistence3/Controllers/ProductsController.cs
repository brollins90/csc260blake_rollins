using DataPersistence3.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DataPersistence3.Controllers
{
    public class ProductsController : Controller
    {
        public bool Db { get; set; }
        private readonly IDal _dal;

        public ProductsController(IDal dal)
        {
            _dal = dal;
        }

        // GET: Products
        public ActionResult Index(string sort)
        {
            string sortBy = (string.IsNullOrEmpty(sort)) ? "name" : sort;
            IEnumerable<Product> products = _dal.GetProducts();
            switch (sortBy)
            {
                case "name":
                    products = products.OrderBy(x => x.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(x => x.Name);
                    break;
                case "price":
                    products = products.OrderBy(x => x.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(x => x.Price);
                    break;
            }

            ViewBag.DAL = _dal.GetType().ToString();
            return View("ProductList", products);
        }


        // View one
        public ActionResult Product(int id)
        {
            Product product = _dal.GetProduct(id);
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
                _dal.AddProduct(p);
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
            Product product = _dal.GetProduct(id);
            return View("ProductForm", product);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                _dal.UpdateProduct(p);
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
            _dal.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeDal()
        {
            NinjectWebCommon.Bootstrapper.ChangeKernel();
            return new RedirectResult("/");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using Omu.ValueInjecter;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        private readonly FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Product
                .OrderByDescending(p => p.ProductId)
                .Take(10)
                .ToList();
            return View(products);
        }

        public ActionResult Index2()
        {
            var data = db.Product
                .Where(p => p.Active == true)
                .OrderByDescending(p => p.ProductId)
                .Take(10)
                .ToArray()
                .Select(p => Mapper.Map<Product, ProductViewModel>(p))
                .ToList();

            return View(data);
        }

        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewProduct(ProductViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var product = new Product();
            product.InjectFrom(data);
            product.Active = true;
            db.Product.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index2");
        }

        public ActionResult UpdateProduct(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var product = db.Product.Find(id);

            if (product == null)
                return HttpNotFound();

            var productViewModel = new ProductViewModel();
            productViewModel.InjectFrom(product);
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return View(productViewModel);

            var product = db.Product.Find(productViewModel.ProductId);

            if (product == null)
                return HttpNotFound();

            product.InjectFrom(productViewModel);
            db.SaveChanges();

            return RedirectToAction("Index2");
        }

        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
                return RedirectToAction("Index2");

            var product = db.Product.Find(id);
            if (product == null)
                return HttpNotFound();
            db.Product.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index2");
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
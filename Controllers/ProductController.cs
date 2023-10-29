using Crud_ASP.NET_MVC.DataContext;
using Crud_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_ASP.NET_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly CrudDataContext _Context;

        public ProductController(CrudDataContext context)
        {
            this._Context = context;
        }

        // Index
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<Product> products = this._Context.Products.ToList();
                return View(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        //Create
        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create( Product product)
        {
            _Context.Add(product);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Details
        [HttpGet]
        public IActionResult Details(string Id)
        {
            Product product = _Context.Products.Where(p => p.Code == Id).FirstOrDefault()!;
            return View(product);
        }
        //Edit
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Product product = _Context.Products.Where(p => p.Code == Id).FirstOrDefault()!;
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _Context.Attach(product);
            _Context.Entry(product).State = EntityState.Modified;
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Product product = _Context.Products.Where(p => p.Code == Id).FirstOrDefault()!;
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _Context.Attach(product);
            _Context.Entry(product).State = EntityState.Deleted;
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        #region "Ajax Functions"
        // IndexAjax
        [HttpGet]
        public IActionResult IndexAjax()
        {
            try
            {
                List<Product> products = this._Context.Products.ToList();
                return View(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Delete
        [HttpPost]
        public IActionResult DeleteProduct(string Id)
        {
            Product product = _Context.Products.Where(p => p.Code == Id).FirstOrDefault()!;
            _Context.Entry(product).State = EntityState.Deleted;
            _Context.SaveChanges();
            return Ok();
        }
        //Get
        public IActionResult ViewProduct(string Id)
        {
            Product product = _Context.Products.Where(p => p.Code == Id).FirstOrDefault()!;
            return PartialView("_Details", product);
        }
        public IActionResult EditProduct(string Id)
        {
            Product product = _Context.Products.Where(p => p.Code == Id).FirstOrDefault()!;
            return PartialView("_Edit", product);
        }
        public IActionResult UpdateProduct(Product product)
        {
            _Context.Attach(product);
            _Context.Entry(product).State = EntityState.Modified;
            _Context.SaveChanges();
            return PartialView("_Product", product);
        }
        #endregion
    }
}

using ProductManagementWebApp.Models.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementWebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            _productService.GetProducts();
            return View();
        }
    }
}
using Fiorella.DAL;
using Fiorella.Helper;
using Fiorella.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Fiorella.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _Db;
        private readonly IWebHostEnvironment _env;
        public ProductsController(AppDbContext Db, IWebHostEnvironment env)
        {
            _Db = Db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _Db.Products.Include(x=>x.Category).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Category=await _Db.Categories.ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, int CatId)
        {
            ViewBag.Category = await _Db.Categories.ToListAsync();
            #region Save Image


            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "Image can't be null!!");
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select image type");
                return View();
            }
            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "max 1mb !!");
                return View();
            }

            string folder = Path.Combine(_env.WebRootPath, "img");
            product.Image = await product.Photo.SaveFileAsync(folder);
            #endregion
            #region Exist Item
            bool isExist = await _Db.Products.AnyAsync(x => x.Name == product.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This product is already exist !");
                return View(product);
            }
            #endregion
            product.CategoryId = CatId;
            await _Db.Products.AddAsync(product);
            await _Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}


using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.Areas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ProductController : Controller
    {
        IRepository<Product> repoProduct;
        
        IRepository<Category> repoCategory;

        public ProductController(IRepository<Product> _repoProduct, IRepository<Category> _repoCategory)
        {
            repoProduct = _repoProduct;
            
            repoCategory = _repoCategory;
        }

        [Route("admin/Product/Index")]
        public IActionResult Index()
        {
            return View(repoProduct.GetAll().OrderByDescending(x => x.ID));
        }

        [Route("admin/Product/New")]
        public IActionResult New()
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                Categories = repoCategory.GetAll(x => x.ParentID != null).OrderBy(x => x.Name)

            };
            return View(productVM);
        }

        [Route("admin/Product/Insert")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                repoProduct.Add(model.Product);
                return RedirectToAction("Index");
            }
            else return RedirectToAction("New");

        }

        [Route("admin/Product/Edit")]
        public IActionResult Edit(int id)
        {
            Product product = repoProduct.GetBy(x => x.ID == id);
            ProductVM productVM = new ProductVM()
            {
                Product = product,
                Categories = repoCategory.GetAll(x => x.ParentID != null).OrderBy(x => x.Name)
            };
            if (product != null) return View(productVM);
            else return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductVM model)
        {
            if (ModelState.IsValid)
            {

                repoProduct.Update(model.Product);
                return RedirectToAction("Index");
            }
            else return RedirectToAction("New");

        }

        [Route("admin/Product/Delete")]
        public IActionResult Delete(int id)
        {
            Product slide = repoProduct.GetBy(x => x.ID == id);
            if (slide != null) repoProduct.Delete(slide);
            return RedirectToAction("Index");
        }

    }
}

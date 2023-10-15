using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ProductPictureController : Controller
    {
        IRepository<ProductPicture> repoProductPicture;
        public ProductPictureController(IRepository<ProductPicture> _repoProductPicture)
        {
            repoProductPicture = _repoProductPicture;
        }

        [Route("admin/ProductPicture/Index")]
        public IActionResult Index(int productid)
        {
            ViewBag.ProductID = productid;

            return View(repoProductPicture.GetAll(x => x.ProductID == productid).OrderByDescending(x => x.ID));
        }

        [Route("admin/ProductPicture/New")]
        public IActionResult New(int productid)
        {
            ViewBag.ProductID = productid;
            return View();
        }

        [Route("admin/ProductPicture/Insert")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(ProductPicture model)
        {
            if (ModelState.IsValid) 
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "productPicture")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "productPicture"));
                    }
                    string dosyaAdi = Request.Form.Files["Picture"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "productPicture", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Picture"].CopyToAsync(stream);

                    }
                    model.Picture = "/img/productPicture/" + dosyaAdi;
                }
                repoProductPicture.Add(model);

                return RedirectToAction("Index", new { productid = model.ProductID });
            }
            else return RedirectToAction("New");
        }

        [Route("admin/ProductPicture/Edit")]
        public IActionResult Edit(int id)
        {
            ProductPicture productPicture = repoProductPicture.GetBy(x => x.ID == id);
            if (productPicture != null) return View(productPicture);
            else return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductPicture model)
        {
            if (ModelState.IsValid) 
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide"));
                    }
                    string dosyaAdi = Request.Form.Files["Picture"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Picture"].CopyToAsync(stream);
                    }
                    model.Picture = "/img/slide/" + dosyaAdi;
                }
                repoProductPicture.Update(model);

                return RedirectToAction("Index", new { mulkid = model.ProductID });
            }
            else return RedirectToAction("New");
        }

        [Route("admin/ProductPicture/Delete")]
        public IActionResult Delete(int id)
        {
            ProductPicture productPicture = repoProductPicture.GetBy(x => x.ID == id);
            if (productPicture != null) repoProductPicture.Delete(productPicture);
            return RedirectToAction("Index");
        }
    }
}


using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.Areas.ViewModel;
using Evim.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductVM = Evim.UI.ViewModels.ProductVM;

namespace Evim.UI.Controllers
{
    public class ProductController : Controller
    {

        IRepository<Product> repoProduct;
        public ProductController(IRepository<Product> _repoProduct)
        {
            repoProduct = _repoProduct;

        }
        public IActionResult Index()
        {
            return View();
        }

        
        [Route("urun/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Product product = repoProduct.GetAll(x => x.ID == id).Include(x => x.Category).Include(x => x.ProductPictures).FirstOrDefault();

            if (product != null)
            {
                ProductVM productVM = new ViewModels.ProductVM()
                {
                    Product = product,
                    RelatedProducts = repoProduct.GetAll(x => x.ID == product.CategoryID && x.ID != product.ID).Include(x => x.ProductPictures)
                };
                return View(productVM);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}

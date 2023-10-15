using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evim.UI.Controllers
{
    public class OfisController : Controller
    {
        
        IRepository<Product> repoProduct;

        public OfisController( IRepository<Product> _repoProduct)
        {
            
            repoProduct = _repoProduct;

        }
        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                Products = repoProduct.GetAll().Include(x => x.ProductPictures).OrderByDescending(x => x.ID)

            };
            return View(indexVM);
        }
    }
}

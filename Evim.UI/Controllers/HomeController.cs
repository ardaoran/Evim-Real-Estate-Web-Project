
using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Evim.UI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Slide> repoSlide;
        IRepository<Product> repoProduct;
        IRepository<Personel> repoPersonel;
        
        public HomeController(IRepository<Slide> _repoSlide,IRepository<Product> _repoProduct,IRepository<Personel>_repoPersonel)
        {
            repoSlide = _repoSlide;
            repoProduct = _repoProduct;
            repoPersonel = _repoPersonel;

        }
        public IActionResult Index()
        {
            IndexVM indexVM = new IndexVM()
            {
                Slides = repoSlide.GetAll().OrderBy(x => x.DisplayIndex).Include(x => x.SlidePictures).OrderByDescending(x => x.ID).Take(4),
                Products = repoProduct.GetAll().Include(x => x.ProductPictures).OrderByDescending(x => x.ID).Take(6),
                Personels = repoPersonel.GetAll().Include(x => x.PersonelPictures).OrderByDescending(x => x.ID).Take(4)

            };
            return View(indexVM);
        }

        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                return View("NotFound");
            }
            return View();
        }


    }
}
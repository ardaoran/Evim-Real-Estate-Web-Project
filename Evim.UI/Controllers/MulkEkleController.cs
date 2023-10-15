using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Evim.UI.Controllers
{
    public class MulkEkleController : Controller
    {
        IRepository<MulkEkle> repoMulkEkle;

        public MulkEkleController(IRepository<MulkEkle> _repoMulkEkle )
        {
            repoMulkEkle = _repoMulkEkle;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        [Route("MulkEkle/Insert")]
        public async Task<IActionResult> Insert(MulkEkleVM model)
        {
            if (ModelState.IsValid)
            {
                repoMulkEkle.Add(model.MulkEkle);
                return View("Basarili");
            }
            else return RedirectToAction("NotFound");

        }
    }
}

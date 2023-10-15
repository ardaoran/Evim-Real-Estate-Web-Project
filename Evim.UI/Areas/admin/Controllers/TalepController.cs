using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class TalepController : Controller
    {
        IRepository<MulkEkle> repoMulkEkle;

        public TalepController(IRepository<MulkEkle> _repoMulkEkle)
        {
            repoMulkEkle = _repoMulkEkle;
        }
        [Route("/admin/Talep/Index")]
        public IActionResult Index()
        {
            return View(repoMulkEkle.GetAll().OrderByDescending(x => x.ID));
        }
    }
}

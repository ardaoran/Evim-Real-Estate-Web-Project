using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.Areas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SlideController : Controller
    {
        IRepository<Slide> repoSlide;

        public SlideController(IRepository<Slide> _repoSlide)
        {
            repoSlide = _repoSlide;
        }
        [Route("admin/Slide")]
        public IActionResult Index()
        {
            return View(repoSlide.GetAll().OrderByDescending(x => x.ID));
        }

        [Route("admin/Slide/New")]
        public IActionResult New()
        {
            SlideVM slideVM = new SlideVM()
            {
                Slide = new Slide(),
             
            };
            return View(slideVM);
            
        }

        [Route("admin/Slide/Insert")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(SlideVM model)
        {
            if (ModelState.IsValid)
            {
                repoSlide.Add(model.Slide);
                return RedirectToAction("Index");
            }
            else return RedirectToAction("New");

        }

        public IActionResult Edit(int id)
        {
            Slide slide = repoSlide.GetBy(x => x.ID == id);
            if (slide != null) return View(slide);
            else return RedirectToAction("Index");
        }

        [Route("admin/Slide/Edit")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SlideVM model)
        {
            if (ModelState.IsValid)
            {

                repoSlide.Update(model.Slide);
                return RedirectToAction("Index");
            }
            else return RedirectToAction("New");

        }

        [Route("admin/Slide/Delete")]
        public IActionResult Delete(int id)
        {
            Slide slide = repoSlide.GetBy(x => x.ID == id);
            if (slide != null) repoSlide.Delete(slide);
            return RedirectToAction("Index");
        }
    }
}

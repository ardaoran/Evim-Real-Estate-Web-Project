using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SlidePictureController : Controller
    {
            IRepository<SlidePicture> repoSlidePicture;
            public SlidePictureController(IRepository<SlidePicture> _repoSlidePicture)
            {
                repoSlidePicture = _repoSlidePicture;
            }

            [Route("admin/SlidePicture/Index")]
            public IActionResult Index(int slideid)
            {
                ViewBag.SlideID = slideid;

                return View(repoSlidePicture.GetAll(x => x.SlideID == slideid).OrderByDescending(x => x.ID));
            }

            [Route("admin/SlidePicture/New")]
            public IActionResult New(int slideid)
            {
                ViewBag.SlideID = slideid;
                return View();
            }

            [Route("admin/SlidePicture/Insert")]
            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> Insert(SlidePicture model)
            {
                if (ModelState.IsValid) 
                {
                    if (Request.Form.Files.Any())
                    {
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slidePicture")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slidePicture"));
                        }
                        string dosyaAdi = Request.Form.Files["Picture"].FileName;
                        using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slidePicture", dosyaAdi), FileMode.Create))
                        {
                            await Request.Form.Files["Picture"].CopyToAsync(stream);

                        }
                        model.Picture = "/img/slidePicture/" + dosyaAdi;
                    }
                    repoSlidePicture.Add(model);

                    return RedirectToAction("Index", new { slideid = model.SlideID });
                }
                else return RedirectToAction("New");
            }

            [Route("admin/SlidePicture/Edit")]
            public IActionResult Edit(int id)
            {
                SlidePicture slidePicture = repoSlidePicture.GetBy(x => x.ID == id);
                if (slidePicture != null) return View(slidePicture);
                else return RedirectToAction("Index");
            }

            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(SlidePicture model)
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
                    repoSlidePicture.Update(model);

                    return RedirectToAction("Index", new { slideid = model.SlideID });
                }
                else return RedirectToAction("New");
            }

            [Route("admin/SlidePicture/Delete")]
            public IActionResult Delete(int id)
            {
                SlidePicture slidePicture = repoSlidePicture.GetBy(x => x.ID == id);
                if (slidePicture != null) repoSlidePicture.Delete(slidePicture);
                return RedirectToAction("Index");
            }
        }
    }


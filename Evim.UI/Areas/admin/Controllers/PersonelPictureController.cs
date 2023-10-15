using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class PersonelPictureController : Controller
    {
        IRepository<PersonelPicture> repoPersonelPicture;
        public PersonelPictureController(IRepository<PersonelPicture> _repoPersonelPicture)
        {
            repoPersonelPicture = _repoPersonelPicture;
        }

        [Route("admin/PersonelPicture/Index")]
        public IActionResult Index(int personelid)
        {
            ViewBag.PersonelID = personelid;

            return View(repoPersonelPicture.GetAll(x => x.PersonelID == personelid).OrderByDescending(x => x.ID));
        }

        [Route("admin/PersonelPicture/New")]
        public IActionResult New(int personelid)
        {
            ViewBag.PersonelID = personelid;
            return View();
        }

        [Route("admin/PersonelPicture/Insert")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(PersonelPicture model)
        {
            if (ModelState.IsValid) 
            {
                if (Request.Form.Files.Any())
                {
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "personelPicture")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "personelPicture"));
                    }
                    string dosyaAdi = Request.Form.Files["Picture"].FileName;
                    using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "personelPicture", dosyaAdi), FileMode.Create))
                    {
                        await Request.Form.Files["Picture"].CopyToAsync(stream);

                    }
                    model.Picture = "/img/personelPicture/" + dosyaAdi;
                }
                repoPersonelPicture.Add(model);

                return RedirectToAction("Index", new { personelid = model.PersonelID });
            }
            else return RedirectToAction("New");
        }

        [Route("admin/PersonelPicture/Edit")]
        public IActionResult Edit(int id)
        {
            PersonelPicture personelPicture = repoPersonelPicture.GetBy(x => x.ID == id);
            if (personelPicture != null) return View(personelPicture);
            else return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonelPicture model)
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
                repoPersonelPicture.Update(model);

                return RedirectToAction("Index", new { personelid = model.PersonelID });
            }
            else return RedirectToAction("New");
        }

        [Route("admin/PersonelPicture/Delete")]
        public IActionResult Delete(int id)
        {
            PersonelPicture personelPicture = repoPersonelPicture.GetBy(x => x.ID == id);
            if (personelPicture != null) repoPersonelPicture.Delete(personelPicture);
            return RedirectToAction("Index");
        }
    }
}

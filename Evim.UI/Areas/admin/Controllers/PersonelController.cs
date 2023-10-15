using Evim.BL.Repositories;
using Evim.DAL.Entities;
using Evim.UI.Areas.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evim.UI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class PersonelController : Controller
    {
        
            IRepository<Personel> repoPersonel;

            public PersonelController(IRepository<Personel> _repoPersonel)
            {
                repoPersonel = _repoPersonel;
            }

            [Route("admin/Personel/Index")]
            public IActionResult Index()
            {
                return View(repoPersonel.GetAll().OrderByDescending(x => x.ID));
            }

            [Route("admin/Personel/New")]
            public IActionResult New()
            {
                PersonelVM personelVM = new PersonelVM()
                {
                    Personel = new Personel(),
                    

                };
                return View(personelVM);
            }

            [Route("admin/Personel/Insert")]
            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> Insert(PersonelVM model)
            {
                if (ModelState.IsValid)
                {
                    repoPersonel.Add(model.Personel);
                    return RedirectToAction("Index");
                }
                else return RedirectToAction("New");

            }

            [Route("admin/Personel/Edit")]
            public IActionResult Edit(int id)
            {
                Personel personel = repoPersonel.GetBy(x => x.ID == id);
                PersonelVM personelVM = new PersonelVM()
                {
                    Personel = personel,
                    
                };
                if (personel != null) return View(personelVM);
                else return RedirectToAction("Index");
            }

            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(PersonelVM model)
            {
                if (ModelState.IsValid)
                {

                    repoPersonel.Update(model.Personel);
                    return RedirectToAction("Index");
                }
                else return RedirectToAction("New");

            }

            [Route("admin/Personel/Delete")]
            public IActionResult Delete(int id)
            {
                Personel slide = repoPersonel.GetBy(x => x.ID == id);
                if (slide != null) repoPersonel.Delete(slide);
                return RedirectToAction("Index");
            }

        }
    }


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.Interfaces;
using Test.Models.ManyToMany;

namespace Test.Controllers
{
    public class CaesController : Controller
    {
        private readonly ICaesRepository _caesRepository;
        private readonly IDonosRepository _donosRepository;
        private readonly ICaesDonosRepository _caesDonosRepository;

        public CaesController(ICaesRepository caesRepository, IDonosRepository donosRepository, ICaesDonosRepository caesDonosRepository)
        {
            _caesRepository = caesRepository;
            _donosRepository = donosRepository;
            _caesDonosRepository = caesDonosRepository;
        }
        [HttpGet]
        public async Task<ActionResult> ToList()
        {
            return View(await _caesRepository.FindAlls());
        }
        [HttpGet]
        public async Task<ActionResult> Insert()
        {
            List<Donos> list = await _donosRepository.FindAlls();
            ViewBag.Donos = list.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Insert(int dono, Caes caes)
        {
            if (!ModelState.IsValid)
            {
                List<Donos> list = await _donosRepository.FindAlls();
                ViewBag.Donos = list.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
                return View();
            }

            await _caesRepository.Insert(caes);

            await _caesDonosRepository.Insert(new Models.ManyToMany.CaesDono { CaesId = caes.Id, DonosId = dono });

            return RedirectToAction(nameof(ToList));
        }
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            return View(await _caesRepository.FindById(id));
        }
        [HttpPost]
        public async Task<ActionResult> Update(Caes caes)
        {
            if (!ModelState.IsValid) return View();

            await _caesRepository.Insert(caes);

            return RedirectToAction(nameof(ToList));
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            List<CaesDono> rs = await _caesDonosRepository.FindByCaes(id);
            if (rs.Count() == 0) return BadRequest();

            foreach (var item in rs)
            {
                await _caesDonosRepository.Remove(item.CaesId, item.DonosId);
            }
            await _caesRepository.Remove(id);
            return RedirectToAction(nameof(ToList));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.Interfaces;

namespace Test.Controllers
{
    public class CaesController : Controller
    {
        private readonly ICaesRepository _caesRepository;
        private readonly IDonosRepository  _donosRepository;
        private readonly ICaesDonosRepository _caesDonosRepository;

        public CaesController(ICaesRepository caesRepository, IDonosRepository donosRepository, ICaesDonosRepository caesDonosRepository)
        {
            _caesRepository = caesRepository;
            _donosRepository = donosRepository;
            _caesDonosRepository = caesDonosRepository;
        }

        public async Task<ActionResult> ToList()
        {
            return View(await _caesRepository.FindAlls());
        }
        public async Task<ActionResult> Insert()
        {
            List<Donos> list = await _donosRepository.FindAlls();
            ViewBag.Donos = list.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        public async Task<ActionResult> InsertDb(int dono, Caes caes)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _caesRepository.Insert(caes);

            await _caesDonosRepository.Insert(new Models.ManyToMany.CaesDono {CaesId = caes.Id, DonosId = dono });

            return RedirectToAction(nameof(ToList));
        }

        public async Task<ActionResult> Update(int id)
        {
            return View(await _caesRepository.FindById(id));
        }

        public async Task<ActionResult> UpdateDb(Caes caes)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _caesRepository.Insert(caes);

            return RedirectToAction(nameof(ToList));
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _caesRepository.Remove(id);

            return RedirectToAction(nameof(ToList));
        }
    }
}

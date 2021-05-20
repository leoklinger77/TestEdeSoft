using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.Interfaces;
using Test.Models.ManyToMany;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDonosRepository _donosRepository;
        private readonly ICaesDonosRepository _caesDonosRepository;

        public HomeController(IDonosRepository donosRepository, ICaesDonosRepository caesDonosRepository)
        {
            _donosRepository = donosRepository;
            _caesDonosRepository = caesDonosRepository;
        }

        [HttpGet]
        public async Task<ActionResult> ToList()
        {              
            return View(await _donosRepository.FindAlls());
        }
        [HttpGet]
        public async Task<ActionResult> Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Donos donos)
        {
            if (!ModelState.IsValid) return View();

            await _donosRepository.Insert(donos);

            return RedirectToAction(nameof(ToList));
        }
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            return View(await _donosRepository.FindById(id));
        }
        [HttpPost]
        public async Task<ActionResult> Update(Donos donos)
        {
            if (!ModelState.IsValid) return View();

            await _donosRepository.Insert(donos);

            return RedirectToAction(nameof(ToList));
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {            
            List<CaesDono> rs = await _caesDonosRepository.FindByDonos(id);
            if (rs.Count() > 0)
            {
                TempData["Error"] = "Dono possui caes, não pode ser excluido! ";
                return RedirectToAction(nameof(ToList));
            }

            await _donosRepository.Remove(id);

            return RedirectToAction(nameof(ToList));
        }


    }
}

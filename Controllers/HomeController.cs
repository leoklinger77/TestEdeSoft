using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.Interfaces;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDonosRepository _donosRepository;

        public HomeController(IDonosRepository donosRepository)
        {
            _donosRepository = donosRepository;
        }
        public async Task<ActionResult> Home()
        {
            return View();
        }       

        public async Task<ActionResult> ToList()
        {              
            return View(await _donosRepository.FindAlls());
        }
        public async Task<ActionResult> Insert()
        {
            return View();
        }

        public async Task<ActionResult> InsertDb(Donos donos)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _donosRepository.Insert(donos);

            return RedirectToAction(nameof(ToList));
        }

        public async Task<ActionResult> Update(int id)
        {
            return View(await _donosRepository.FindById(id));
        }

        public async Task<ActionResult> UpdateDb(Donos donos)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _donosRepository.Insert(donos);

            return RedirectToAction(nameof(ToList));
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _donosRepository.Remove(id);

            return RedirectToAction(nameof(ToList));
        }


    }
}

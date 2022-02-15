using Microsoft.AspNetCore.Mvc;
using Rise.Core.DTOs;
using Rise.Web.Services;

namespace Rise.Web.Controllers
{
    public class PersonContactController : Controller
    {
        private readonly PersonContactApiService _personContactApiService;
        private readonly PersonApiService _personApiService;

        public PersonContactController(PersonContactApiService personContactApiService, PersonApiService personApiService)
        {
            _personContactApiService = personContactApiService;
            _personApiService = personApiService;

        }
        public async Task<IActionResult> Index(int personId)
        {
            return View(await _personApiService.GetSinglePersonByIdContact(personId));
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(PersonContactDto personContactDto)
        {

            if (ModelState.IsValid)
            {
                await _personContactApiService.SaveAsync(personContactDto);
                return RedirectToAction("Index");

            }
            return View();

        }

        public async Task<IActionResult> Update(int id)
        {
            var person = await _personContactApiService.GetByIdAsync(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonContactDto personContactDto)
        {
            if (ModelState.IsValid)
            {
                await _personContactApiService.UpdateAsync(personContactDto);
                return RedirectToAction("Index");
            }
            return View(personContactDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _personContactApiService.RemoveAsync(id);
            return RedirectToAction("Index");
        }


    }
}

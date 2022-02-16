using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rise.Core.DTOs;
using Rise.Web.Services;

namespace Rise.Web.Controllers
{
    public class PersonContactController : Controller
    {
        private readonly PersonContactApiService _personContactApiService;
        private readonly PersonApiService _personApiService;
        private readonly CityApiService _cityApiService;

        public PersonContactController(PersonContactApiService personContactApiService, PersonApiService personApiService, CityApiService cityApiService)
        {
            _personContactApiService = personContactApiService;
            _personApiService = personApiService;
            _cityApiService = cityApiService;

        }
        public async Task<IActionResult> Index(int personId)
        {
            return View(await _personApiService.GetSinglePersonByIdContact(personId));
        }

        public async Task<IActionResult> Save(int id)
        {
            var cities = await _cityApiService.GetAllAsync();
          
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.PersonId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(PersonContactDto personContactDto)
        {

            if (ModelState.IsValid)
            {
                personContactDto.Id = 0;//hata anlaşılamadığı için geçici çözüm olarak eklendi.
                await _personContactApiService.SaveAsync(personContactDto);
                return RedirectToAction("Index");

            }
            var cities= await _cityApiService.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");

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
            var cities = await _cityApiService.GetAllAsync();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            return View(personContactDto);
        }

        public async Task<IActionResult> Remove(int id, int personId)
        {
            await _personContactApiService.RemoveAsync(id);
            return RedirectToAction("GetSinglePersonByIdContact",personId);
        }


    }
}

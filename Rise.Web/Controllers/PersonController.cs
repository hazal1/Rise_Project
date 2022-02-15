﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rise.Core;
using Rise.Core.DTOs;
using Rise.Core.Services;
using Rise.Web.Services;

namespace Rise.Web.Controllers
{
    public class PersonController : Controller
    {
        
        private readonly PersonApiService _personApiService;
        private readonly IMapper _mapper;

        public PersonController(PersonApiService personApiService)
        {
            _personApiService = personApiService;
            
            
        }
        public async Task<IActionResult> Index()
        {
            return View(await _personApiService.GetPersonWithContact());
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {

            if (ModelState.IsValid)
            {
                await _personApiService.SaveAsync(personDto);
                return RedirectToAction("Index");
                
            }
              return View();

        }

        public async Task<IActionResult> Update(int id)
        {
            var person = await _personApiService.GetByIdAsync(id);
            return View(person);         
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonDto personDto)
        {
            if (ModelState.IsValid)
            {
                await _personApiService.UpdateAsync(personDto);
                return RedirectToAction("Index");
            }
            return View(personDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _personApiService.RemoveAsync(id);
            return RedirectToAction("Index");
        }

     
        public async Task<IActionResult> GetPersonByIdWithContact(int personId)
        {
            return View(await _personApiService.GetSinglePersonByIdContact(personId));
        }
    }
}

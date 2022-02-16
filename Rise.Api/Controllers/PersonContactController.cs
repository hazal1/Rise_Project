﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.Core;
using Rise.Core.DTOs;
using Rise.Core.Services;

namespace Rise.Api.Controllers
{
    
    public class PersonContactController : CustomBaseController
    {
        private readonly IPersonContactService _personContactService;
        private readonly IMapper _mapper;
        public PersonContactController(IPersonContactService personContactService, IMapper mapper)
        {
            _personContactService = personContactService;
            _mapper = mapper;
        }
        [HttpGet("[action]/{contactId}")]
        public async Task<IActionResult> GetContactWithPerson(int contactId)
        {
            return CreateActionResult(await _personContactService.GetContactWithPersonAsync(contactId));

        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonContactDto personContactDto)
        {
            var contact = await _personContactService.AddAsync(_mapper.Map<PersonContact>(personContactDto));
            var ContactDtoo = _mapper.Map<PersonContact>(contact);
            return CreateActionResult(CustomResponseDto<PersonContact>.Success(201, ContactDtoo));
        }

        //[HttpPut]
        //public async Task<IActionResult> Update(PersonUpdateDto personUpdateDto)
        //{
        //    await _personService.UpdateAsync(_maper.Map<Person>(personUpdateDto));
        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var person = await _personService.GetByIdAsync(id);

        //    await _personService.RemoveAsync(person);
        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        //}

    }
}

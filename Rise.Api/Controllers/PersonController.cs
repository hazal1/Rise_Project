using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.Core;
using Rise.Core.DTOs;
using Rise.Core.Services;

namespace Rise.Api.Controllers
{
    public class PersonController : CustomBaseController
    {
        private readonly IMapper _maper;
      
        private readonly IPersonService _service;
        public PersonController(IMapper maper, IService<Person> service, IPersonService personService)
        {
            _maper = maper;
            _service = personService;
        }

        [HttpGet("GetPersonWithContact")]
        public async Task<IActionResult> GetPersonWithContact()
        {
            return CreateActionResult(await _service.GetPersonWithContact());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var persons = await _service.GetAllAsync();
            var personDtos = _maper.Map<List<PersonDto>>(persons.ToList());
            return CreateActionResult(CustomResponseDto<List<PersonDto>>.Success(200, personDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _service.GetByIdAsync(id);
            var personDto = _maper.Map<PersonDto>(person);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(200, personDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var person = await _service.AddAsync(_maper.Map<Person>(personDto));
            var personsDto = _maper.Map<PersonDto>(person);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(201, personsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonUpdateDto personUpdateDto)
        {
             await _service.UpdateAsync(_maper.Map<Person>(personUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var person = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(person);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

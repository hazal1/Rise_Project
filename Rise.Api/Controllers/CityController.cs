using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rise.Core.DTOs;
using Rise.Core.Services;

namespace Rise.Api.Controllers
{
    public class CityController : CustomBaseController
    {
        private readonly IMapper _mapper;

        private readonly ICityService _cityService;
        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper =mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var cities = await _cityService.GetAllAsync();

            var citiesDto = _mapper.Map<List<CityDto>>(cities.ToList());

            return CreateActionResult(CustomResponseDto<List<CityDto>>.Success(200, citiesDto));

        }
    }
}

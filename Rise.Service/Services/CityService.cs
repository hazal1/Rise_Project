using AutoMapper;
using Rise.Core;
using Rise.Core.Repositories;
using Rise.Core.Services;
using Rise.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Service.Services
{
    public class CityService: Service<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(IGenericRepository<City> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}

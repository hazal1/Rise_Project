using AutoMapper;
using Rise.Core;
using Rise.Core.DTOs;
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
    public class PersonService : Service<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IGenericRepository<Person> repository, IUnitOfWork unitOfWork, IPersonRepository personRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<CustomResponseDto<List<PersonWithContactDto>>> GetPersonWithContact()
        {
            var person = await _personRepository.GetPersonWithContact();
            var personsDto = _mapper.Map<List<PersonWithContactDto>>(person);
            return CustomResponseDto<List<PersonWithContactDto>>.Success(200, personsDto);
        }

        public async Task<CustomResponseDto<PersonWithContactDto>> GetSinglePersonByIdContact(int personId)
        {
            var person = await _personRepository.GetSinglePersonByIdContact(personId);
            var personDto = _mapper.Map<PersonWithContactDto>(person);
            return CustomResponseDto<PersonWithContactDto>.Success(200, personDto);

        }

      
    }
}

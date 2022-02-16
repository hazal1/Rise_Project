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
     
    public class PersonContactService : Service<PersonContact>, IPersonContactService
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public PersonContactService(IGenericRepository<PersonContact> repository, IUnitOfWork unitOfWork, IPersonContactRepository personContactRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _personContactRepository = personContactRepository;
            _mapper=mapper;
        }

        public async Task<CustomResponseDto<List<ContactWithPersonDto>>> GetAllContactWithAllPerson()
        {
            var personcnt = await _personContactRepository.GetAllContactWithAllPerson();
            var personcntsDto = _mapper.Map<List<ContactWithPersonDto>>(personcnt);
            return CustomResponseDto<List<ContactWithPersonDto>>.Success(200, personcntsDto);
        }
     
        public async Task<CustomResponseDto<ContactWithPersonDto>> GetContactWithPersonAsync(int contactId)
        {
            var contact = await _personContactRepository.GetContactByIdPerson(contactId);
            var contactsDto= _mapper.Map<ContactWithPersonDto>(contact);
            return CustomResponseDto<ContactWithPersonDto>.Success(200, contactsDto);
        }
            
    
    }
}

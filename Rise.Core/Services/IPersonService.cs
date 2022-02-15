using Rise.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.Services
{
    public interface IPersonService:IService<Person>
    {  
        Task<CustomResponseDto<List<PersonWithContactDto>>> GetPersonWithContact();
        Task<CustomResponseDto<PersonWithContactDto>> GetSinglePersonByIdContact(int personId);
    }
}

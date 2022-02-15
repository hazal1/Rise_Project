using Rise.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.Services
{
    public interface IPersonContactService : IService<PersonContact>
    {
        public Task<CustomResponseDto<ContactWithPersonDto>> GetContactWithPersonAsync(int contactId);
    }
}

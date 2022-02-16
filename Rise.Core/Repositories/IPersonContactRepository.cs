using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.Repositories
{
    public interface IPersonContactRepository:IGenericRepository<PersonContact>
    {
        Task<PersonContact> GetContactByIdPerson(int contactId);
        Task<List<PersonContact>> GetAllContactWithAllPerson();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.Repositories
{
    public interface IPersonRepository :IGenericRepository<Person>
    {
        Task<List<Person>> GetPersonWithContact();
        Task<Person> GetSinglePersonByIdContact(int personId);
    }
}

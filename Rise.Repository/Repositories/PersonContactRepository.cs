using Microsoft.EntityFrameworkCore;
using Rise.Core;
using Rise.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Repository.Repositories
{
    public class PersonContactRepository : GenericRepository<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PersonContact> GetContactByIdPerson(int contactId)
        {
            return await _context.PersonContacts.Include(x => x.Person).Where(x => x.Id == contactId).SingleOrDefaultAsync();
        }
    }
}

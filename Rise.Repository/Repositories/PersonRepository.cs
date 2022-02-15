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
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Person>> GetPersonWithContact()
        {
            return await _context.People.Include(x => x.PersonContacts).ToListAsync();
        }

        public async Task<Person> GetSinglePersonByIdContact(int personId)
        {
            return await _context.People.Include(x => x.PersonContacts).Where(x => x.Id == personId).SingleOrDefaultAsync(); 
        }
    }
}

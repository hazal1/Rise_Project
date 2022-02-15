using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.DTOs
{
    public class PersonContactDto
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonId { get; set; }
        public int CityId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.DTOs
{
    public class PersonWithContactDto:PersonDto
    {
        public List<PersonContactDto> PersonContacts { get; set; }
    }
}

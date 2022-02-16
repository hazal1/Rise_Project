using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.DTOs
{
    public class denemedto : PersonContactDto
    {
        public PersonDto Person { get; set; }
        public CityDto City { get; set; }
    }
}

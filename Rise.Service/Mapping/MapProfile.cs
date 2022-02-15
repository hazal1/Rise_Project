using AutoMapper;
using Rise.Core;
using Rise.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Person,PersonDto>().ReverseMap();
            CreateMap<City,CityDto>().ReverseMap();
            CreateMap<PersonContact,PersonContactDto>().ReverseMap();
            CreateMap<PersonUpdateDto, Person>();
            CreateMap<Person, PersonWithContactDto>();
            CreateMap<PersonContact, ContactWithPersonDto>();
        }
    }
}

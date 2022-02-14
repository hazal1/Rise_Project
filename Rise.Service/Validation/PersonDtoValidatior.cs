using FluentValidation;
using Rise.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Service.Validation
{
    public class PersonDtoValidatior:AbstractValidator<PersonDto>
    {
        public PersonDtoValidatior()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("(PropertyName) is Required").NotEmpty().WithMessage("(PropertyName) is Required");
            RuleFor(x => x.Surname).NotNull().WithMessage("(PropertyName) is Required").NotEmpty().WithMessage("(PropertyName) is Required");
            RuleFor(x => x.FirmName).NotNull().WithMessage("(PropertyName) is Required").NotEmpty().WithMessage("(PropertyName) is Required");

          //  RuleFor(x=>x.PersonId).InclusiveBetween(1,int.MaxValue).WithMessage("(PropertyName) is Required");




        }
    }
}

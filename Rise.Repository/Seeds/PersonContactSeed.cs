using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rise.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Repository.Seeds
{
    public class PersonContactSeed : IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.HasData(
                new PersonContact { Id = 1, CityId = 1, Email = "hazal@hotmail.com", Phone = "05512365659", PersonId = 1 },
                new PersonContact { Id = 2, CityId = 5, Email = "Sinem@hotmail.com", Phone = "05512695659", PersonId = 2 }
                );
        }
    }
}

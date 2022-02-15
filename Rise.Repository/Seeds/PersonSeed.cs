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
    public class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person { Id = 1, Name = "Hazal", Surname = "Çelik", FirmName = "Kıvırcıklar Ülkesi", CreatedDate=DateTime.Now },
                new Person { Id = 2, Name = "Sinem", Surname = "Durak", FirmName = "Karanfil", CreatedDate = DateTime.Now }
            
            );
        }
    }
}

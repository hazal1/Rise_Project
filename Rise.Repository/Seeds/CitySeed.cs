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
    public class CitySeed : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City { Id = 1, Name = "Adana" },
                new City { Id = 2, Name = "Adıyaman" },
                new City { Id = 3, Name = "Afyon" },
                new City { Id = 4, Name = "Amasya" },
                new City { Id = 5, Name = "Ağrı" },
                new City { Id = 6, Name = "Ankara" },
                new City { Id = 7, Name = "Antalya" },
                new City { Id = 8, Name = "Artvin" },
                new City { Id = 9, Name = "Aydın" },
                new City { Id = 10, Name = "Balıkesir" },
                new City { Id = 11, Name = "Bilecik" },
                new City { Id = 12, Name = "Bingöl" },
                new City { Id = 13, Name = "Bitlis" },
                new City { Id = 14, Name = "Bolu" },
                new City { Id = 15, Name = "Burdur" },
                new City { Id = 16, Name = "Bursa" },
                new City { Id = 17, Name = "Çanakkale" },
                new City { Id = 18, Name = "Çankırı" },
                new City { Id = 19, Name = "Çorum" },
                new City { Id = 20, Name = "Denizli" },
                new City { Id = 21, Name = "Diyarbakır" },
                new City { Id = 22, Name = "Edirne" },
                new City { Id = 23, Name = "Elâzığ" },
                new City { Id = 24, Name = "Erzincan" },
                new City { Id = 25, Name = "Erzurum" },
                new City { Id = 26, Name = "Eskişehir" }


         );
        }
    }
}

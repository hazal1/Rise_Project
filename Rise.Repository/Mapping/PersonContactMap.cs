using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rise.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Repository.Mapping
{
    public class PersonContactMap : IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Phone).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100);

            builder.HasOne(I => I.Person).WithMany(I => I.PersonContacts).HasForeignKey(I => I.PersonId);
        }
    }
}

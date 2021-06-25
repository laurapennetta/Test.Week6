using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.Property(k => k.CF).IsFixedLength().HasMaxLength(16);
            builder.HasKey(k => k.CF);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(50);
        }
    }
}

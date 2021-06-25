using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policy");
            builder.HasKey(k => k.Number);
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Instalment).IsRequired();
            builder.HasOne(c => c.Client).WithMany(p => p.Policies).HasForeignKey(f => f.ClientCF);

            builder.HasDiscriminator<string>("Kind of Policy")
                   .HasValue<Theft>("Theft Policy")
                   .HasValue<CarRC>("Car Policy")
                   .HasValue<Life>("Life Policy");
        }
    }
}

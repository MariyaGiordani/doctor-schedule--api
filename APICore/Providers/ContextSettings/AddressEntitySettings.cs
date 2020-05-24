using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICore.Providers.ContextSettings
{
    public class AddressEntitySettings : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> modelbuilder)
        {
            modelbuilder.ToTable("M_ADDRESS");

            modelbuilder.HasKey(m => m.AddressId);

            modelbuilder.Property(u => u.AddressId)
                .HasColumnName("ADDRESS_ID")
                .IsRequired();

            modelbuilder.Property(m => m.RoadType)
                 .HasColumnName("ROAD_TYPE")
                 .HasMaxLength(30)
                 .IsRequired();

            modelbuilder.Property(m => m.Street)
                 .HasColumnName("STREET")
                 .HasMaxLength(100)
                 .IsRequired();

            modelbuilder.Property(m => m.Number)
                 .HasColumnName("NUMBER")                 
                 .IsRequired();

            modelbuilder.Property(m => m.Neighborhood)
                 .HasColumnName("NEIGHBORHOOD")
                 .HasMaxLength(100)
                 .IsRequired();

            modelbuilder.Property(m => m.Complement)
                 .HasColumnName("COMPLEMENT")
                 .HasMaxLength(200);

            modelbuilder.Property(m => m.PostalCode)
                 .HasColumnName("POSTAL_CODE")
                 .HasMaxLength(10)
                 .IsRequired();

            modelbuilder.Property(m => m.City)
                 .HasColumnName("CITY")
                 .IsRequired();

            modelbuilder.Property(m => m.UF)
                 .HasColumnName("UF")
                 .IsRequired();

            modelbuilder.Property(m => m.Information)
                 .HasColumnName("INFORMATION")
                 .HasMaxLength(4000);

            modelbuilder.Property(m => m.Telephone)
                 .HasColumnName("TELEPHONE")
                 .IsRequired();

            modelbuilder.Property(m => m.HealthCare)
                 .HasColumnName("HEALTHCARE")
                 .IsRequired();

            modelbuilder.HasOne(a => a.TimeSheet).WithOne(a => a.Address).HasForeignKey<TimeSheet>(a => a.AddressId).IsRequired();
            modelbuilder.HasMany(d => d.Appointments).WithOne(d => d.Address).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}

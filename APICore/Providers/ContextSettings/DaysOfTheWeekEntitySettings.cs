using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICore.Providers.ContextSettings
{
    public class DaysOfTheWeekEntitySettings : IEntityTypeConfiguration<DaysOfTheWeek>
    {
        public void Configure(EntityTypeBuilder<DaysOfTheWeek> modelbuilder)
        {
            modelbuilder.ToTable("DAYS_OF_THE_WEEK");

            modelbuilder.HasKey(m => m.Id);

            modelbuilder.Property(m => m.Id)
                .HasColumnName("DAYS_ID")
                .IsRequired();

            modelbuilder.Property(m => m.Name)
                 .HasColumnName("NAME")                 
                 .IsRequired();

            modelbuilder.Property(m => m.TimeSheetId)
                 .HasColumnName("TIME_SHEET_ID")                 
                 .IsRequired();
        }
    }
}

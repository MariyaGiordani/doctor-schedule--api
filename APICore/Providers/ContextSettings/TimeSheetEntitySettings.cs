using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace APICore.Providers.ContextSettings
{
    public class TimeSheetEntitySettings : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> modelbuilder)
        {
            modelbuilder.ToTable("M_TIMESHEET");

            modelbuilder.HasKey(m => m.TimeSheetId);

            modelbuilder.Property(u => u.TimeSheetId)
                .HasColumnName("TIMESHEET_ID")
                .IsRequired();

            modelbuilder.Property(m => m.StartDate)
                 .HasColumnName("START_DATE")
                 .IsRequired();

            modelbuilder.Property(m => m.EndDate)
                 .HasColumnName("END_DATE")
                 .IsRequired();

            modelbuilder.Property(m => m.LunchStartDate)
                 .HasColumnName("LUNCH_START_DATE")
                 .IsRequired();

            modelbuilder.Property(m => m.LunchEndDate)
                 .HasColumnName("LUNCH_END_DATE")
                 .IsRequired();

            modelbuilder.Property(m => m.AppointmentDuration)
                 .HasColumnName("APPOINTMENT_DURATION")
                 .IsRequired();

            modelbuilder.Property(m => m.Cpf)
                 .HasColumnName("CPF")
                 .HasMaxLength(11)
                 .IsRequired();

            modelbuilder.Property(m => m.AddressId)
                 .HasColumnName("ADDRESS_ID")
                 .IsRequired();

            modelbuilder.Property(m => m.AppointmentCancelTime)
                 .HasColumnName("APPOINTMENT_CANCEL_TIME")
                 .IsRequired();

            modelbuilder.HasMany(t => t.DaysOfTheWeeks).WithOne(t => t.TimeSheet).IsRequired();
        }
    }
}

using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICore.Providers.ContextSettings
{
    public class AppointmentEntitySettings : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> modelbuilder)
        {
            modelbuilder.ToTable("APPOINTMENT");

            modelbuilder.HasKey(m => m.AppointmentId);

            modelbuilder.Property(u => u.AppointmentId)
                .HasColumnName("APPOINTMENT_ID")
                .IsRequired();

            modelbuilder.Property(m => m.AppointmentTime)
                 .HasColumnName("APPOINTMENT_TIME")
                 .IsRequired();

            modelbuilder.Property(m => m.Status)
                 .HasColumnName("STATUS")
                 .IsRequired();

            modelbuilder.Property(m => m.RescheludedAppointmentId)
                 .HasColumnName("RE_SCHEDULED_APPOINTMENT_ID");

            modelbuilder.Property(m => m.DoctorCpf)
                 .HasColumnName("DOCTOR_CPF")
                 .IsRequired();

            modelbuilder.Property(m => m.PatientCpf)
                 .HasColumnName("PATIENT_CPF")
                 .IsRequired();            

            modelbuilder.Property(m => m.AddressId)
                 .HasColumnName("ADDRESS_ID")
                 .IsRequired();            
        }
    }
}

﻿// <auto-generated />
using System;
using APICore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICore.Migrations
{
    [DbContext(typeof(DbConnectionProvider))]
    partial class DbConnectionProviderModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APICore.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ADDRESS_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("CITY");

                    b.Property<string>("Complement")
                        .HasColumnName("COMPLEMENT")
                        .HasMaxLength(200);

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<string>("HealthCare")
                        .IsRequired()
                        .HasColumnName("HEALTHCARE");

                    b.Property<string>("Information")
                        .HasColumnName("INFORMATION")
                        .HasMaxLength(4000);

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnName("NEIGHBORHOOD")
                        .HasMaxLength(100);

                    b.Property<int>("Number")
                        .HasColumnName("NUMBER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnName("POSTAL_CODE")
                        .HasMaxLength(10);

                    b.Property<string>("RoadType")
                        .IsRequired()
                        .HasColumnName("ROAD_TYPE")
                        .HasMaxLength(30);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("STREET")
                        .HasMaxLength(100);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnName("TELEPHONE");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnName("UF");

                    b.HasKey("AddressId");

                    b.HasIndex("Cpf");

                    b.ToTable("M_ADDRESS");
                });

            modelBuilder.Entity("APICore.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("APPOINTMENT_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnName("ADDRESS_ID");

                    b.Property<DateTime>("AppointmentTime")
                        .HasColumnName("APPOINTMENT_TIME");

                    b.Property<string>("DoctorCpf")
                        .IsRequired()
                        .HasColumnName("DOCTOR_CPF");

                    b.Property<string>("PatientCpf")
                        .IsRequired()
                        .HasColumnName("PATIENT_CPF");

                    b.Property<int>("RescheludedAppointmentId")
                        .HasColumnName("RE_SCHEDULED_APPOINTMENT_ID");

                    b.Property<int>("Status")
                        .HasColumnName("STATUS");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AddressId");

                    b.HasIndex("DoctorCpf");

                    b.HasIndex("PatientCpf");

                    b.ToTable("APPOINTMENT");
                });

            modelBuilder.Entity("APICore.Models.DaysOfTheWeek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DAYS_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasColumnName("NAME");

                    b.Property<int>("TimeSheetId")
                        .HasColumnName("TIME_SHEET_ID");

                    b.HasKey("Id");

                    b.HasIndex("TimeSheetId");

                    b.ToTable("M_DAYS_OF_THE_WEEK");
                });

            modelBuilder.Entity("APICore.Models.Doctor", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnName("CPF")
                        .HasMaxLength(11);

                    b.Property<int>("Crm")
                        .HasColumnName("CRM")
                        .HasMaxLength(6);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasMaxLength(30);

                    b.Property<int>("Id")
                        .HasColumnName("USER_ID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasMaxLength(70);

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnName("SPECIALITY")
                        .HasMaxLength(39);

                    b.HasKey("Cpf");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("M_DOCTOR");
                });

            modelBuilder.Entity("APICore.Models.Patient", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnName("CPF")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasMaxLength(30);

                    b.Property<int>("Id")
                        .HasColumnName("USER_ID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasMaxLength(70);

                    b.HasKey("Cpf");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("P_PATIENT");
                });

            modelBuilder.Entity("APICore.Models.Security", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("USER_ID");

                    b.Property<byte[]>("SaltPassword")
                        .IsRequired()
                        .HasColumnName("SALT_PASSWORD");

                    b.HasKey("Id");

                    b.ToTable("U_SECURITY");
                });

            modelBuilder.Entity("APICore.Models.TimeSheet", b =>
                {
                    b.Property<int>("TimeSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TIMESHEET_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnName("ADDRESS_ID");

                    b.Property<string>("AppointmentCancelTime")
                        .IsRequired()
                        .HasColumnName("APPOINTMENT_CANCEL_TIME");

                    b.Property<string>("AppointmentDuration")
                        .IsRequired()
                        .HasColumnName("APPOINTMENT_DURATION");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasMaxLength(11);

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("END_DATE");

                    b.Property<DateTime>("LunchEndDate")
                        .HasColumnName("LUNCH_END_DATE");

                    b.Property<DateTime>("LunchStartDate")
                        .HasColumnName("LUNCH_START_DATE");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("START_DATE");

                    b.HasKey("TimeSheetId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("Cpf");

                    b.ToTable("M_TIMESHEET");
                });

            modelBuilder.Entity("APICore.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("USER_PASSWORD")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("USER_NAME")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("U_USER");
                });

            modelBuilder.Entity("APICore.Models.Address", b =>
                {
                    b.HasOne("APICore.Models.Doctor", "Doctor")
                        .WithMany("Addresses")
                        .HasForeignKey("Cpf")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APICore.Models.Appointment", b =>
                {
                    b.HasOne("APICore.Models.Address", "Address")
                        .WithMany("Appointments")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("APICore.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorCpf")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("APICore.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientCpf")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("APICore.Models.DaysOfTheWeek", b =>
                {
                    b.HasOne("APICore.Models.TimeSheet", "TimeSheet")
                        .WithMany("DaysOfTheWeeks")
                        .HasForeignKey("TimeSheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APICore.Models.Doctor", b =>
                {
                    b.HasOne("APICore.Models.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("APICore.Models.Doctor", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APICore.Models.Patient", b =>
                {
                    b.HasOne("APICore.Models.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("APICore.Models.Patient", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APICore.Models.Security", b =>
                {
                    b.HasOne("APICore.Models.User", "User")
                        .WithOne("Security")
                        .HasForeignKey("APICore.Models.Security", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APICore.Models.TimeSheet", b =>
                {
                    b.HasOne("APICore.Models.Address", "Address")
                        .WithOne("TimeSheet")
                        .HasForeignKey("APICore.Models.TimeSheet", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APICore.Models.Doctor", "Doctor")
                        .WithMany("TimeSheets")
                        .HasForeignKey("Cpf")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

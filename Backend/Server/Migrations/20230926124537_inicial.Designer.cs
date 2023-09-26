﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230926124537_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Domain.Consultation", b =>
                {
                    b.Property<long?>("ConsultationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConsultationType")
                        .HasColumnType("TEXT");

                    b.Property<long?>("DoctorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observations")
                        .HasColumnType("TEXT");

                    b.Property<long?>("PatientID")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ReceptionistID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("dateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ConsultationID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.HasIndex("ReceptionistID");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Domain.Doctor", b =>
                {
                    b.Property<long?>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProfesssionalRegistrationNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SpecialtyID")
                        .HasColumnType("INTEGER");

                    b.HasKey("DoctorID");

                    b.HasIndex("SpecialtyID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.Property<long?>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdentificationNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Receptionist", b =>
                {
                    b.Property<long?>("ReceptionistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdentificationNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("ReceptionistID");

                    b.ToTable("Receptionists");
                });

            modelBuilder.Entity("Domain.Specialty", b =>
                {
                    b.Property<long?>("SpecialtyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialtyName")
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialtyID");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Domain.TimeRange", b =>
                {
                    b.Property<long?>("TimeRangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DoctorID")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("TimeRangeID");

                    b.HasIndex("DoctorID");

                    b.ToTable("TimeRange");
                });

            modelBuilder.Entity("Domain.Consultation", b =>
                {
                    b.HasOne("Domain.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID");

                    b.HasOne("Domain.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.HasOne("Domain.Receptionist", "Receptionist")
                        .WithMany()
                        .HasForeignKey("ReceptionistID");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Receptionist");
                });

            modelBuilder.Entity("Domain.Doctor", b =>
                {
                    b.HasOne("Domain.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyID");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Domain.TimeRange", b =>
                {
                    b.HasOne("Domain.Doctor", null)
                        .WithMany("AvailableHours")
                        .HasForeignKey("DoctorID");
                });

            modelBuilder.Entity("Domain.Doctor", b =>
                {
                    b.Navigation("AvailableHours");
                });
#pragma warning restore 612, 618
        }
    }
}
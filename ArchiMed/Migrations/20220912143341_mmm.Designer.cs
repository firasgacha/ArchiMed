﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArchiMed.Migrations
{
    [DbContext(typeof(ArchiMedDB))]
    [Migration("20220912143341_mmm")]
    partial class mmm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArchiMed.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AgentId"));

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cin")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fisrtName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("postalCode")
                        .HasColumnType("integer");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AgentId");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("ArchiMed.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AppointmentId"));

                    b.Property<int>("AgentId")
                        .HasColumnType("integer");

                    b.Property<string>("AppointmentDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AgentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("ArchiMed.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ArchiMed.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<int>("DepartmentFk")
                        .HasColumnType("integer");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cin")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fisrtName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("headofDepartment")
                        .HasColumnType("boolean");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("phone")
                        .HasColumnType("integer");

                    b.Property<int>("postalCode")
                        .HasColumnType("integer");

                    b.Property<string>("specialty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DoctorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ArchiMed.Models.MedicalFolder", b =>
                {
                    b.Property<int>("MedicalFolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MedicalFolderId"));

                    b.HasKey("MedicalFolderId");

                    b.ToTable("MedicalFolder");
                });

            modelBuilder.Entity("ArchiMed.Models.Medications", b =>
                {
                    b.Property<int>("MedicationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MedicationsId"));

                    b.Property<DateTime>("DateExpiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateFabrication")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MedicalFolderId")
                        .HasColumnType("integer");

                    b.Property<string>("medicationCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationComposition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationEffets")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationPicture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationPrice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("medicationcontraindication")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MedicationsId");

                    b.HasIndex("MedicalFolderId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("ArchiMed.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientId"));

                    b.Property<int>("MedicalFolderId")
                        .HasColumnType("integer");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("birthday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("cin")
                        .HasColumnType("integer");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fisrtName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("postalCode")
                        .HasColumnType("integer");

                    b.HasKey("PatientId");

                    b.HasIndex("MedicalFolderId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("ArchiMed.Models.Radio", b =>
                {
                    b.Property<int>("RadioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RadioId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RadioDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RadioName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RadioType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("medicalFolderFk")
                        .HasColumnType("integer");

                    b.HasKey("RadioId");

                    b.HasIndex("medicalFolderFk");

                    b.ToTable("Radio");
                });

            modelBuilder.Entity("ArchiMed.Models.Scanner", b =>
                {
                    b.Property<int>("ScannerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScannerId"));

                    b.Property<int>("AgentFk")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScannerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ScannerType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("medicalFolderFk")
                        .HasColumnType("integer");

                    b.HasKey("ScannerId");

                    b.HasIndex("AgentFk");

                    b.HasIndex("medicalFolderFk");

                    b.ToTable("Scanner");
                });

            modelBuilder.Entity("ArchiMed.Models.Appointment", b =>
                {
                    b.HasOne("ArchiMed.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArchiMed.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArchiMed.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ArchiMed.Models.Doctor", b =>
                {
                    b.HasOne("ArchiMed.Models.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ArchiMed.Models.Medications", b =>
                {
                    b.HasOne("ArchiMed.Models.MedicalFolder", null)
                        .WithMany("Medications")
                        .HasForeignKey("MedicalFolderId");
                });

            modelBuilder.Entity("ArchiMed.Models.Patient", b =>
                {
                    b.HasOne("ArchiMed.Models.MedicalFolder", "MedicalFolder")
                        .WithMany()
                        .HasForeignKey("MedicalFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalFolder");
                });

            modelBuilder.Entity("ArchiMed.Models.Radio", b =>
                {
                    b.HasOne("ArchiMed.Models.MedicalFolder", "medicalFolder")
                        .WithMany("Radios")
                        .HasForeignKey("medicalFolderFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicalFolder");
                });

            modelBuilder.Entity("ArchiMed.Models.Scanner", b =>
                {
                    b.HasOne("ArchiMed.Models.Agent", "agent")
                        .WithMany()
                        .HasForeignKey("AgentFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArchiMed.Models.MedicalFolder", "medicalFolder")
                        .WithMany("Scanners")
                        .HasForeignKey("medicalFolderFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("agent");

                    b.Navigation("medicalFolder");
                });

            modelBuilder.Entity("ArchiMed.Models.Department", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("ArchiMed.Models.MedicalFolder", b =>
                {
                    b.Navigation("Medications");

                    b.Navigation("Radios");

                    b.Navigation("Scanners");
                });
#pragma warning restore 612, 618
        }
    }
}

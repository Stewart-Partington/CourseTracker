﻿// <auto-generated />
using System;
using CourseTracker.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseTracker.Persistence.Migrations
{
    [DbContext(typeof(DatabaseService))]
    [Migration("20240528152009_Attachments")]
    partial class Attachments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseTracker.Domain.Assessments.Assessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AssessmentType")
                        .HasColumnType("int");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("CourseTracker.Domain.Attachments.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssessmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Payload")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("CourseTracker.Domain.Courses.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SchoolYearId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolYearId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseTracker.Domain.SchoolYears.SchoolYear", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("SchoolYears");
                });

            modelBuilder.Entity("CourseTracker.Domain.Students.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseTracker.Domain.Assessments.Assessment", b =>
                {
                    b.HasOne("CourseTracker.Domain.Courses.Course", null)
                        .WithMany("Assessments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTracker.Domain.Attachments.Attachment", b =>
                {
                    b.HasOne("CourseTracker.Domain.Assessments.Assessment", null)
                        .WithMany("Attachments")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTracker.Domain.Courses.Course", b =>
                {
                    b.HasOne("CourseTracker.Domain.SchoolYears.SchoolYear", null)
                        .WithMany("Courses")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTracker.Domain.SchoolYears.SchoolYear", b =>
                {
                    b.HasOne("CourseTracker.Domain.Students.Student", null)
                        .WithMany("SchoolYears")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseTracker.Domain.Assessments.Assessment", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("CourseTracker.Domain.Courses.Course", b =>
                {
                    b.Navigation("Assessments");
                });

            modelBuilder.Entity("CourseTracker.Domain.SchoolYears.SchoolYear", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CourseTracker.Domain.Students.Student", b =>
                {
                    b.Navigation("SchoolYears");
                });
#pragma warning restore 612, 618
        }
    }
}

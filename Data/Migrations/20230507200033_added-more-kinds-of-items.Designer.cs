﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(EdInvestContext))]
    [Migration("20230507200033_added-more-kinds-of-items")]
    partial class addedmorekindsofitems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "item_type", new[] { "course", "application", "bootcamp", "online_course", "event" });
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shared.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shared.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Shared.Models.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("Shared.Models.Investments", b =>
                {
                    b.Property<Guid>("InvestorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Tier")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("InvestorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("Shared.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Goal")
                        .HasColumnType("numeric");

                    b.Property<List<string>>("Images")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("uuid");

                    b.Property<List<decimal>>("Prices")
                        .IsRequired()
                        .HasColumnType("numeric[]");

                    b.Property<Guid>("SubcategoryId")
                        .HasColumnType("uuid");

                    b.Property<Dictionary<string, string>>("Tiers")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Courses");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Shared.Models.Subcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("Shared.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("numeric");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("SocialLinks")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WalletAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Shared.Models.Application", b =>
                {
                    b.HasBaseType("Shared.Models.Item");

                    b.Property<string>("AppPurpose")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EstimatedNumberOfUsers")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EstimatedRelease")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("Features")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("Markets")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Shared.Models.Course", b =>
                {
                    b.HasBaseType("Shared.Models.Item");

                    b.Property<int?>("ActiveStudents")
                        .HasColumnType("integer");

                    b.Property<Dictionary<string, string>>("Curriculum")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ExpectedApplicants")
                        .HasColumnType("integer");

                    b.Property<int?>("ExpectedGraduates")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Shared.Models.Event", b =>
                {
                    b.HasBaseType("Shared.Models.Item");

                    b.Property<Dictionary<string, string>>("Activities")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ExpectedAttendance")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("NotableAttendees")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("NotableSpeakers")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("Shared.Models.OnlineCourse", b =>
                {
                    b.HasBaseType("Shared.Models.Item");

                    b.Property<int>("AvarageDuration")
                        .HasColumnType("integer");

                    b.Property<int>("ExpectedAudience")
                        .HasColumnType("integer");

                    b.Property<Dictionary<string, string>>("Lessons")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.Property<List<DateTime>>("LessonsDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone[]");

                    b.Property<Dictionary<string, string>>("LinksToChannels")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Shared.Models.Investor", b =>
                {
                    b.HasBaseType("Shared.Models.User");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Shared.Models.Organisation", b =>
                {
                    b.HasBaseType("Shared.Models.User");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Shared.Models.Student", b =>
                {
                    b.HasBaseType("Shared.Models.User");

                    b.Property<DateTime>("BegginingOfEducation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CollegeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CollegeWebsite")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndOfEducation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FieldId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FunderId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("SchoolarshipPrice")
                        .HasColumnType("numeric");

                    b.HasIndex("FieldId");

                    b.HasIndex("FunderId");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Shared.Models.Investments", b =>
                {
                    b.HasOne("Shared.Models.Item", "Course")
                        .WithMany("Investments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.Investor", "Investor")
                        .WithMany("Investments")
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("Shared.Models.Item", b =>
                {
                    b.HasOne("Shared.Models.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.Organisation", "Organisation")
                        .WithMany("Courses")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.Subcategory", "Subcategory")
                        .WithMany("Courses")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Organisation");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Shared.Models.Subcategory", b =>
                {
                    b.HasOne("Shared.Models.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shared.Models.User", b =>
                {
                    b.HasOne("Shared.Models.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Shared.Models.Student", b =>
                {
                    b.HasOne("Shared.Models.Field", "Field")
                        .WithMany("Students")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.Investor", "Funder")
                        .WithMany("Students")
                        .HasForeignKey("FunderId");

                    b.Navigation("Field");

                    b.Navigation("Funder");
                });

            modelBuilder.Entity("Shared.Models.Category", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("Shared.Models.Country", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shared.Models.Field", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Shared.Models.Item", b =>
                {
                    b.Navigation("Investments");
                });

            modelBuilder.Entity("Shared.Models.Subcategory", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Shared.Models.Investor", b =>
                {
                    b.Navigation("Investments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Shared.Models.Organisation", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}

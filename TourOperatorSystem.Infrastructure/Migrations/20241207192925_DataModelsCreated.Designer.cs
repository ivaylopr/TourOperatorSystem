﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourOperatorSystem.Infrastructure.Data;

#nullable disable

namespace TourOperatorSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241207192925_DataModelsCreated")]
    partial class DataModelsCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Agent identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Agent phone number");

                    b.Property<double?>("Rating")
                        .HasColumnType("float")
                        .HasComment("Rating of the agent");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User who is agent identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Agents");

                    b.HasComment("Agent class");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Candidate identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Candidate email");

                    b.Property<bool>("IsAvaileble")
                        .HasColumnType("bit")
                        .HasComment("Is the candidate availeble");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Phone number of the candidate");

                    b.Property<int>("SeasonalEmploymentId")
                        .HasColumnType("int");

                    b.Property<string>("ShortRepresentAndSkills")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("Short presentation and skills of the candidate");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User-Candidate");

                    b.HasKey("Id");

                    b.HasIndex("SeasonalEmploymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Candidates");

                    b.HasComment("Candidate class");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Comment identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AgentId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasComment("Rating given by the user creator of the review");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Review for the hotel or for the agent");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User who give the review");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("HotelId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");

                    b.HasComment("Class for comments and reviews by the users");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Hotel identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("AllInclusivePrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("All inclusive additional price to the room offer");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasComment("Hotel Total capacity");

                    b.Property<int>("CategoryStars")
                        .HasColumnType("int")
                        .HasComment("Category stars of the hotel");

                    b.Property<bool>("ChildrenAnimators")
                        .HasColumnType("bit")
                        .HasComment("Children animation available");

                    b.Property<string>("HotelReview")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Hotel review and presentation");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Hotel location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Hotel name");

                    b.Property<bool>("Pool")
                        .HasColumnType("bit")
                        .HasComment("Pool available");

                    b.Property<double?>("Rating")
                        .HasColumnType("float")
                        .HasComment("Rating of the hotel");

                    b.Property<bool>("Spa")
                        .HasColumnType("bit")
                        .HasComment("Spa available");

                    b.Property<int>("VacationCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VacationCategoryId");

                    b.ToTable("Hotels");

                    b.HasComment("Hotel class");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.HotelVacation", b =>
                {
                    b.Property<int>("VacationId")
                        .HasColumnType("int");

                    b.Property<int>("HodelId")
                        .HasColumnType("int");

                    b.HasKey("VacationId", "HodelId");

                    b.HasIndex("HodelId");

                    b.ToTable("HotelVacations");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalExtras")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Additional room extras");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasComment("rooms available");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Room description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Room price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Room title");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasComment("Room class");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.SeasonalEmployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgentId")
                        .HasColumnType("int")
                        .HasComment("Agent responsible for the offer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Job description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("End date for the job");

                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasComment("Hotel who is offering the season job");

                    b.Property<decimal>("HourlyWage")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Payment per hour");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Data for starting job");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Job title");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("HotelId");

                    b.ToTable("SeasonalEmployments");

                    b.HasComment("Season job class");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Vacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Vacation identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgentId")
                        .HasColumnType("int")
                        .HasComment("Agent who is responsive for the vacation");

                    b.Property<bool?>("AllInclusive")
                        .HasColumnType("bit")
                        .HasComment("Is all inclusive option added to the vacation");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Vacation description");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("Vacation end date/leaving");

                    b.Property<DateTime>("EnrollmentDeadline")
                        .HasColumnType("datetime2")
                        .HasComment("Vacation enrollment deadline");

                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasComment("Hotel identifier of the holiday");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Location of the vacation");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Vacation start date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Vacation Title");

                    b.Property<int>("VacationCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("HotelId");

                    b.HasIndex("VacationCategoryId");

                    b.ToTable("Vacations");

                    b.HasComment("Vacation class");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.VacationCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Description of the type");

                    b.Property<string>("VacationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Type of the vacation");

                    b.HasKey("Id");

                    b.ToTable("VacationCategories");

                    b.HasComment("Category class for vacations");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.VacationCustomer", b =>
                {
                    b.Property<int>("VacationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VacationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("VacationCustomers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Agent", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Candidate", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.SeasonalEmployment", "SeasonalEmployment")
                        .WithMany("Applayers")
                        .HasForeignKey("SeasonalEmploymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SeasonalEmployment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Agent", null)
                        .WithMany("Comments")
                        .HasForeignKey("AgentId");

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Hotel", null)
                        .WithMany("Comments")
                        .HasForeignKey("HotelId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Hotel", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.VacationCategory", "VacationCategory")
                        .WithMany("Hotels")
                        .HasForeignKey("VacationCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("VacationCategory");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.HotelRoom", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.HotelVacation", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Hotel", "Hotel")
                        .WithMany("HotelVacations")
                        .HasForeignKey("HodelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Vacation", "Vacation")
                        .WithMany()
                        .HasForeignKey("VacationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Vacation");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.SeasonalEmployment", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Vacation", b =>
                {
                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.VacationCategory", "VacationCategory")
                        .WithMany("Vacations")
                        .HasForeignKey("VacationCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Hotel");

                    b.Navigation("VacationCategory");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.VacationCustomer", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourOperatorSystem.Infrastructure.Data.Models.Vacation", "Vacation")
                        .WithMany("VacationCustomers")
                        .HasForeignKey("VacationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vacation");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Hotel", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("HotelRooms");

                    b.Navigation("HotelVacations");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.SeasonalEmployment", b =>
                {
                    b.Navigation("Applayers");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.Vacation", b =>
                {
                    b.Navigation("VacationCustomers");
                });

            modelBuilder.Entity("TourOperatorSystem.Infrastructure.Data.Models.VacationCategory", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Vacations");
                });
#pragma warning restore 612, 618
        }
    }
}

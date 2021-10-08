﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsaagBackend.Data;

namespace UsaagBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211008030107_CurriculumThemeUpdate")]
    partial class CurriculumThemeUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UsaagBackend.Models.CohortStudents", b =>
                {
                    b.Property<int>("CohortId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CohortId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CohortStudents");
                });

            modelBuilder.Entity("UsaagBackend.Models.Cohorts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<bool?>("Archived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("CPKColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#bdbdbd");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlackChannel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("black");

                    b.HasKey("Id");

                    b.ToTable("Cohorts");
                });

            modelBuilder.Entity("UsaagBackend.Models.CurriculumTemplateList", b =>
                {
                    b.Property<int>("ThemeId")
                        .HasColumnType("int");

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<int>("AssignmentSequence")
                        .HasColumnType("int");

                    b.Property<int>("DayToAssign")
                        .HasColumnType("int");

                    b.Property<string>("LectureTopics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectDays")
                        .HasColumnType("int");

                    b.HasKey("ThemeId", "HeaderId");

                    b.HasIndex("HeaderId");

                    b.ToTable("CurriculumTemplateList");
                });

            modelBuilder.Entity("UsaagBackend.Models.CurriculumThemes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DayTimeStatus")
                        .HasColumnType("bit");

                    b.Property<int>("DaysInWeek")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWeeks")
                        .HasColumnType("int");

                    b.Property<string>("TechnologyStack")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurriculumThemes");
                });

            modelBuilder.Entity("UsaagBackend.Models.ProjectDetails", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("BonusStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("CompletedTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("GradingScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PercentComplete")
                        .HasColumnType("int");

                    b.Property<int>("PointValue")
                        .HasColumnType("int");

                    b.Property<float>("PointsScored")
                        .HasColumnType("real");

                    b.Property<int?>("ProjectHeaderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "Id");

                    b.HasIndex("ProjectHeaderId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectDetails");
                });

            modelBuilder.Entity("UsaagBackend.Models.ProjectHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CohortId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDue")
                        .HasColumnType("datetime2");

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<float>("TotalPoints")
                        .HasColumnType("real");

                    b.Property<float>("TotalWeightedPoints")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CohortId");

                    b.HasIndex("HeaderId");

                    b.ToTable("ProjectHeader");
                });

            modelBuilder.Entity("UsaagBackend.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Archived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("CohortId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorSlackChannel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CohortId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UsaagBackend.Models.TeamAssignments", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<bool>("ProjectSubmitted")
                        .HasColumnType("bit");

                    b.Property<string>("ReflectionResponse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPointsScored")
                        .HasColumnType("real");

                    b.Property<float>("TotalWeightedPointsScored")
                        .HasColumnType("real");

                    b.HasKey("TeamId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("TeamAssignments");
                });

            modelBuilder.Entity("UsaagBackend.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutoGenName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("CohortId")
                        .HasColumnType("int");

                    b.Property<string>("GitHubRepository")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Group")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamTrelloBoard")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CohortId");

                    b.HasIndex("HeaderId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("UsaagBackend.Models.TemplateDetail", b =>
                {
                    b.Property<int>("HeaderId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("BonusStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GreyHighlight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("PointValue")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HeaderId", "Id");

                    b.ToTable("TemplateDetail");
                });

            modelBuilder.Entity("UsaagBackend.Models.TemplateHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<bool?>("Archived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotionScript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnologyStack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPoints")
                        .HasColumnType("real");

                    b.Property<float>("TotalWeightedPoints")
                        .HasColumnType("real");

                    b.Property<int>("VersionMain")
                        .HasColumnType("int");

                    b.Property<int>("VersionMinor")
                        .HasColumnType("int");

                    b.Property<int>("VersionSub")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TemplateHeader");
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

            modelBuilder.Entity("UsaagBackend.Models.CohortStudents", b =>
                {
                    b.HasOne("UsaagBackend.Models.Cohorts", "Cohorts")
                        .WithMany()
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsaagBackend.Models.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cohorts");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("UsaagBackend.Models.CurriculumTemplateList", b =>
                {
                    b.HasOne("UsaagBackend.Models.TemplateHeader", "TemplateHeader")
                        .WithMany()
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsaagBackend.Models.CurriculumThemes", "CurriculumThemes")
                        .WithMany()
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurriculumThemes");

                    b.Navigation("TemplateHeader");
                });

            modelBuilder.Entity("UsaagBackend.Models.ProjectDetails", b =>
                {
                    b.HasOne("UsaagBackend.Models.ProjectHeader", "ProjectHeader")
                        .WithMany()
                        .HasForeignKey("ProjectHeaderId");

                    b.HasOne("UsaagBackend.Models.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("ProjectHeader");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("UsaagBackend.Models.ProjectHeader", b =>
                {
                    b.HasOne("UsaagBackend.Models.Cohorts", "Cohorts")
                        .WithMany()
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsaagBackend.Models.TemplateHeader", "TemplateHeader")
                        .WithMany()
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cohorts");

                    b.Navigation("TemplateHeader");
                });

            modelBuilder.Entity("UsaagBackend.Models.Students", b =>
                {
                    b.HasOne("UsaagBackend.Models.Cohorts", "Cohorts")
                        .WithMany()
                        .HasForeignKey("CohortId");

                    b.Navigation("Cohorts");
                });

            modelBuilder.Entity("UsaagBackend.Models.TeamAssignments", b =>
                {
                    b.HasOne("UsaagBackend.Models.Students", "Students")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsaagBackend.Models.Teams", "Teams")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("UsaagBackend.Models.Teams", b =>
                {
                    b.HasOne("UsaagBackend.Models.Cohorts", "Cohorts")
                        .WithMany()
                        .HasForeignKey("CohortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsaagBackend.Models.TemplateHeader", "TemplateHeader")
                        .WithMany()
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cohorts");

                    b.Navigation("TemplateHeader");
                });

            modelBuilder.Entity("UsaagBackend.Models.TemplateDetail", b =>
                {
                    b.HasOne("UsaagBackend.Models.TemplateHeader", "TemplateHeader")
                        .WithMany()
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateHeader");
                });
#pragma warning restore 612, 618
        }
    }
}

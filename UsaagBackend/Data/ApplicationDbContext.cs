using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsaagBackend.Models;
using System;

namespace UsaagBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CurriculumThemes> CurriculumThemes { get; set; }
        public DbSet<CurriculumDetail> CurriculumDetail { get; set; }
        public DbSet<CurriculumType> CurriculumTypes { get; set; }

        public DbSet<Cohorts> Cohorts { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<CohortStudents> CohortStudents { get; set; }
        public DbSet<Teams> Teams { get; set; }
        //public DbSet<TeamAssignments> TeamAssignments { get; set; }
        public DbSet<TeamAssignments> TeamAssignments { get; set; }
        public DbSet<ProjectHeader> ProjectHeader { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }
        //public DbSet<ProjectTeams> ProjectTeams { get; set; }
        public DbSet<TemplateHeader> TemplateHeader { get; set; }
        public DbSet<TemplateDetail> TemplateDetail { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=dccBackend;Trusted_Connection=True");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new RolesConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CurriculumThemes>();
            
            modelBuilder.Entity<CurriculumDetail>()
                .HasKey(cd => new { cd.ThemeId, cd.Id });

            modelBuilder.Entity<CurriculumDetail>()
                .Property(cd => cd.CurrTypeId)
                .HasDefaultValue(1);

            modelBuilder.Entity<CurriculumType>()
                .Property(c => c.Archived)
                .HasDefaultValue(false);
            modelBuilder.Entity<CurriculumType>()
                .HasData(
                    new CurriculumType { Id = 1, Name = "Note", Abbreviation = "Note", Archived = false, TextColor = "white", ChipColor = "gray"},
                    new CurriculumType { Id = 2, Name = "Lecture", Abbreviation = "Lect", Archived = false, TextColor = "black", ChipColor = "yellow" },
                    new CurriculumType { Id = 3, Name = "Demo", Abbreviation = "Demo", Archived = false, TextColor = "black", ChipColor = "orange" },
                    new CurriculumType { Id = 4, Name = "Worksheet", Abbreviation = "WS", Archived = false, TextColor = "black", ChipColor = "cyan" },
                    new CurriculumType { Id = 5, Name = "Mini-Lab", Abbreviation = "MLab", Archived = false, TextColor = "white", ChipColor = "blue" },
                    new CurriculumType { Id = 6, Name = "Lab", Abbreviation = "Lab", Archived = false, TextColor = "white", ChipColor = "darkblue" },
                    new CurriculumType { Id = 7, Name = "Project", Abbreviation = "Proj", Archived = false, TextColor = "white", ChipColor = "purple" },
                    new CurriculumType { Id = 8, Name = "Group Capstone", Abbreviation = "GCap", Archived = false, TextColor = "black", ChipColor = "lime" },
                    new CurriculumType { Id = 9, Name = "Individual Capstone", Abbreviation = "ICap", Archived = false, TextColor = "white", ChipColor = "green" }
                );    

            modelBuilder.Entity<Cohorts>()
                .Property(c => c.Archived)
                .HasDefaultValue(false);
            modelBuilder.Entity<Cohorts>()
                .Property(c => c.CPKColor)
                .HasDefaultValue("#bdbdbd");
            modelBuilder.Entity<Cohorts>()
                .Property(c => c.TextColor)
                .HasDefaultValue("black");

            modelBuilder.Entity<Students>()
                .Property(c => c.Archived)
                .HasDefaultValue(false);

            modelBuilder.Entity<CohortStudents>()
                .HasKey(cs => new { cs.CohortId, cs.StudentId });
            
            modelBuilder.Entity<Teams>()
                .Property(t => t.Group)
                .HasDefaultValue(false);
            modelBuilder.Entity<Teams>()
                .Property(t => t.AutoGenName)
                .HasDefaultValue(false);

            modelBuilder.Entity<TeamAssignments>()
                .HasKey(ta => new { ta.TeamId, ta.StudentId });

            modelBuilder.Entity<ProjectHeader>();
            
            modelBuilder.Entity<ProjectDetails>()
                .HasKey(pd => new { pd.ProjectId, pd.Id });
            modelBuilder.Entity<ProjectDetails>()
                .Property(pd => pd.BonusStatus)
                .HasDefaultValue(false);


            modelBuilder.Entity<TemplateHeader>()
                .Property(th => th.Archived)
                .HasDefaultValue(false);

            modelBuilder.Entity<TemplateDetail>()
                .HasKey(td => new { td.HeaderId, td.Id });
            modelBuilder.Entity<TemplateDetail>()
                .Property(pd => pd.BonusStatus)
                .HasDefaultValue(false);
            modelBuilder.Entity<TemplateDetail>()
                .Property(pd => pd.GreyHighlight)
                .HasDefaultValue(false);
        }
    }
}
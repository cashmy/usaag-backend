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
        public DbSet<CurriculumTemplateList> CurriculumTemplateList { get; set; }
        public DbSet<Cohorts> Cohorts { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<CohortStudents> CohortStudents { get; set; }
        public DbSet<Teams> Teams { get; set; }
        //public DbSet<TeamAssignments> TeamAssignments { get; set; }
        public DbSet<ProjectTeams> ProjectTeams { get; set; }
        public DbSet<Projects> Projects { get; set; }
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
            
            modelBuilder.Entity<CurriculumTemplateList>()
                .HasKey(ctl => new { ctl.ThemeId, ctl.HeaderId });

            modelBuilder.Entity<Cohorts>()
                .Property(c => c.Archived)
                .HasDefaultValue(false);

            modelBuilder.Entity<Students>();

            modelBuilder.Entity<CohortStudents>()
                .HasKey(cs => new { cs.CohortId, cs.StudentId });
            
            modelBuilder.Entity<Teams>()
                .Property(t => t.Group)
                .HasDefaultValue(false);
            modelBuilder.Entity<Teams>()
                .Property(t => t.AutoGenName)
                .HasDefaultValue(false);

            modelBuilder.Entity<ProjectTeams>();

            //modelBuilder.Entity<TeamAssignments>();
            modelBuilder.Entity<Projects>();
            
            modelBuilder.Entity<ProjectDetails>()
                .HasKey(pd => new { pd.ProjectId, pd.Id });
            modelBuilder.Entity<ProjectDetails>()
                .Property(pd => pd.BonusStatus)
                .HasDefaultValue(false);
            
            //modelBuilder.Entity<ProjectTeams>()
            //    .Property(pt => pt.ProjectStatus)
            //     .HasDefaultValue(false);
            modelBuilder.Entity<TemplateHeader>();

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
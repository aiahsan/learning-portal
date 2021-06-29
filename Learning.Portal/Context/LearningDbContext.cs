using Learning.Portal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning.Portal.Context
{
    public class LearningDbContext : IdentityDbContext<
        User, IdentityRole<int>, int,
        IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public LearningDbContext()
        {
            DbInitilizer.CreateDatabase(this);
        }
        public LearningDbContext(string connectionString)
        {
            DbInitilizer.CreateDatabase(this);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(Settings.ConnectionString,
                MySql => MySql.CommandTimeout(6 * 60)
                );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestQuestion>()
        .HasKey(bc => new { bc.TestId, bc.QuestionId });
            modelBuilder.Entity<TestQuestion>()
                .HasOne(bc => bc.Test)
                .WithMany(b => b.TestQuestions)
                .HasForeignKey(bc => bc.TestId);
            modelBuilder.Entity<TestQuestion>()
                .HasOne(bc => bc.Question)
                .WithMany(c => c.TestQuestions)
                .HasForeignKey(bc => bc.QuestionId);
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Assign> Assigns { get; set; }
        public DbSet<AssignClass> AssignClasses  { get; set; }
    }
}

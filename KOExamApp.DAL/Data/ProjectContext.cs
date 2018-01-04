using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOExamApp.DAL.Models;

namespace KOExamApp.DAL.Data
{
    class ProjectContext:DbContext
    {
        public ProjectContext():base("name=KOExamApp")
        {
            Database.SetInitializer( new CreateDatabaseIfNotExists<ProjectContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}

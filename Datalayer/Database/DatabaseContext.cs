using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Project1.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {

        public DbSet<DatabaseUser> Users { get; set; }
        public DbSet<DatabaseLog> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dbFile = "Welcome.db";
            string dbPath = Path.Combine(solutionFolder, dbFile);
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        } // OnConfiguring()

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserType.Moderator,
                Expires = DateTime.Now.AddYears(10)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(
                new DatabaseUser()
                {
                    Id = 2,
                    Name = "Ivan Ivanov",
                    Password = "123",
                    Role = UserType.Student,
                    Expires = DateTime.Now.AddYears(3)
                }
            );

            modelBuilder.Entity<DatabaseUser>().HasData(user);
        } // OnModelCreating()

        public void Log(string error)
        {
            Console.WriteLine("Error");
        }
    }
}

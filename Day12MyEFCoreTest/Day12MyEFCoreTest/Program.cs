using Microsoft.EntityFrameworkCore;
using System;

namespace Day12MyEFCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class User
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Age { get; set; }

    }

    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB; Trusted_Connection=True");
        }
    }
}

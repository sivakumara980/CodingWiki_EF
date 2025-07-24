using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId=1, Title="MyStroy", ISBN = "12525", Price=10.25m },
                new Book { BookId=2, Title="NASA", ISBN = "85485", Price=559.27m }
                );

                var NewBookList = new Book[]
                {
                    new Book { BookId=3, Title="MakeMyTrip", ISBN = "1995", Price=6.14m },
                    new Book { BookId=4, Title="Google", ISBN = "2022", Price=85.56m },
                    new Book { BookId=5, Title="MSTeams", ISBN = "20254", Price=17.2m },
                    new Book { BookId=6, Title="FitApp", ISBN = "2055", Price=5874.27m },
                    new Book { BookId=7, Title="Paytm", ISBN = "7845", Price=121.25m },
                    new Book { BookId=8, Title="Gpay", ISBN = "7452", Price=879.27m }
                };

            modelBuilder.Entity<Book>().HasData(NewBookList);
        }
    }
}

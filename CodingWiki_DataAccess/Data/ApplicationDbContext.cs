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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }         
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        //public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        // Fluent Models

        public DbSet<Fluent_BookDetail> BookDetails_Fluent { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CodingWiki1;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");

           // modelBuilder.Entity<BookAuthorMap>().HasNoKey();
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookDetail>().HasData(
    new BookDetail { BookDetail_Id = 1, NumberOfChapters = 10, NumberOfPages = 100, Weight = "1kg" },
    new BookDetail { BookDetail_Id = 2, NumberOfChapters = 12, NumberOfPages = 120, Weight = "1.2kg" },
    new BookDetail { BookDetail_Id = 3, NumberOfChapters = 8, NumberOfPages = 80, Weight = "0.8kg" },
    new BookDetail { BookDetail_Id = 4, NumberOfChapters = 15, NumberOfPages = 150, Weight = "1.5kg" },
    new BookDetail { BookDetail_Id = 5, NumberOfChapters = 20, NumberOfPages = 200, Weight = "2kg" },
    new BookDetail { BookDetail_Id = 6, NumberOfChapters = 18, NumberOfPages = 180, Weight = "1.8kg" },
    new BookDetail { BookDetail_Id = 7, NumberOfChapters = 22, NumberOfPages = 220, Weight = "2.2kg" },
    new BookDetail { BookDetail_Id = 8, NumberOfChapters = 25, NumberOfPages = 250, Weight = "2.5kg" }
);

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "MyStroy", ISBN = "12525", Price = 10.25m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "NASA", ISBN = "85485", Price = 559.27m, Publisher_Id = 2 },
                new Book { BookId = 3, Title = "MakeMyTrip", ISBN = "1995", Price = 6.14m, Publisher_Id = 3 },
                new Book { BookId = 4, Title = "Google", ISBN = "2022", Price = 85.56m, Publisher_Id = 1 },
                new Book { BookId = 5, Title = "MSTeams", ISBN = "20254", Price = 17.2m, Publisher_Id = 2 },
                new Book { BookId = 6, Title = "FitApp", ISBN = "2055", Price = 5874.27m, Publisher_Id = 3 },
                new Book { BookId = 7, Title = "Paytm", ISBN = "7845", Price = 121.25m, Publisher_Id = 1 },
                new Book { BookId = 8, Title = "Gpay", ISBN = "7452", Price = 879.27m, Publisher_Id = 2 }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
                );

        }
    }
}

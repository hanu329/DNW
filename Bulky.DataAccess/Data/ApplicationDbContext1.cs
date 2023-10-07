using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext1 : DbContext
    {
        public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BulkyBook> BulkyBooks { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 2 }
                );
            modelBuilder.Entity<BulkyBook>().HasData(
               new BulkyBook { Id = 1, Name = "Action", Description = "ljsdf", Category="Action" , Price =200 , Rating=4, ImgUrl= "https://cdn.asaha.com/assets/thumbs/d1a/d1a5fc33dd966632e859578c63e05567.jpg",
                   NoOfPages=250, Year=2015
               }
               );

            modelBuilder.Entity<UserModel>().HasData(
             new UserModel
             {
                 Id = 1,
                 UserName = "Hanu",
                 Password="1234"
                
             }
             );
        }
    
    }
}


using Evim.DAL.Entities;
using Evim.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evim.DAL.Content
{
    public class SQLContext:DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPicture>().HasOne(x => x.Product).WithMany(x => x.ProductPictures);
            modelBuilder.Entity<PersonelPicture>().HasOne(x => x.Personel).WithMany(x => x.PersonelPictures);
            modelBuilder.Entity<SlidePicture>().HasOne(x => x.Slide).WithMany(x => x.SlidePictures);

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                ID = 1,
                NameSurname = "Arda Oran",
                LastLongDate = DateTime.Now,
                LastLoginIP = "",
                UserName = "arda",
                Password = "202cb962ac59075b964b07152d234b70",
            });


        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public DbSet<SlidePicture> SlidePictures { get; set; }


        public DbSet<Category> Category { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelPicture> PersonelPictures { get; set; }

        public DbSet<MulkEkle> mulkEkle { get; set; }
    }
}




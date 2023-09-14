using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DatabaseEntityContext : DbContext
    {
        public DatabaseEntityContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Category { set; get; }
        public DbSet<Brand> Band { set; get; }
        public DbSet<Products> products { set; get; }
        public DbSet<ProductImages> ProductImages { set; get; }
        public DbSet<ProductQuantity> ProductQuantity { set; get; }
        public DbSet<AppColor> AppColor { set; get; }
        public DbSet<AppImages> AppImages { set; get; }
        public DbSet<AppUser> AppUser { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
     
    }
}

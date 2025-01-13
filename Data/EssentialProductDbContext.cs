using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EssentialProductDbContext : DbContext
    {
        public EssentialProductDbContext(DbContextOptions<EssentialProductDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductOwner> ProductOwner { get; set; }
        public DbSet<WishListItem> WishListItem { get; set; }


    }
}

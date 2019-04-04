using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GUI_JavaJam.Models;

namespace GUI_JavaJam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        public DbSet<JobApplicantModel> JobApplicantModel { get; set; }
        public DbSet<MenuItemModel> MenuItemModels { get; set; }
        public DbSet<MenuItemPriceModel> MenuItemPriceModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItemPriceModel>()
                .HasOne(p => p.MenuItem)
                .WithMany(m => m.PriceModels)
                .HasForeignKey(p => p.MenuItemId);
            SeedData.Initialize(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using GUI_JavaJam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GUI_JavaJam.Data
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MenuItemModel>().HasData(new MenuItemModel()
                {
                    Id = 1,
                    Name = "Just Java",
                    Description = "Regular house blend, decaffeinated coffee, or flavor of the day",
                    PriceModels = new List<MenuItemPriceModel>(),
                },
                new MenuItemModel()
                {
                    Id = 2,
                    Name = "Cafe au Lait",
                    Description = "House blended coffee infused into a smooth, steamed milk",
                    PriceModels = new List<MenuItemPriceModel>(),
                },
                new MenuItemModel()
                {
                    Id = 3,
                    Name = "Iced Cappuccino",
                    Description = "Sweetend espresso blended with icy-cold milk and served in a chilled glass.",
                    PriceModels = new List<MenuItemPriceModel>(),
                });

            modelBuilder.Entity<MenuItemPriceModel>().HasData(
                new MenuItemPriceModel()
                {
                    Price = 2,
                    PriceDescription = "Endless Cup",
                    Id = 1,
                    MenuItemId = 1
                },
                new MenuItemPriceModel()
                {
                    Price = 2,
                    PriceDescription = "Single",
                    Id = 2,
                    MenuItemId = 2,
                },
                new MenuItemPriceModel()
                {
                    Price = 3,
                    PriceDescription = "Double",
                    Id = 3,
                    MenuItemId = 2,
                },
                new MenuItemPriceModel()
                {
                    Price = 4.75,
                    PriceDescription = "Single",
                    Id = 4,
                    MenuItemId = 3,
                },
                new MenuItemPriceModel()
                {
                    Price = 5.75,
                    PriceDescription = "Double",
                    Id = 5,
                    MenuItemId = 3,
                });
        }
    }
}
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DbContextExtensions
    {
        public static void SeedCars(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new[]
            {
                new Car()
                {
                    Id = 1,
                    Name = "Toyota Camry",
                    Year = 2006,
                    Price = 7550,
                    Km = 300,
                    Fuel = "Gasoline",
                    City = "Kyiv",
                    Transmission = "Manual",
                    ImagePath = @"https://thumbs.img-sprzedajemy.pl/1000x901c/16/97/24/toyota-camry-hybrid-vi-2006-benzyna-slaskie-560029414.jpg"
                },
                new Car()
                {
                    Id = 2,
                    Name = "Renault Megane",
                    Year = 2012,
                    Price = 7700,
                    Km = 240,
                    Fuel = "Diesel",
                    City = "Dnipro",
                    Transmission = "Manual",
                    ImagePath = @"https://carteam.pl/img/53/53205/4929.jpg"
                },
                new Car()
                {
                    Id = 3,
                    Name = "Kia Sportage",
                    Year = 2017,
                    Price = 17500,
                    Km = 99,
                    Fuel = "Diesel",
                    City = "Kiyv",
                    Transmission = "Robot",
                    ImagePath = @"https://media.ed.edmunds-media.com/kia/sportage/2017/oem/2017_kia_sportage_4dr-suv_ex_fq_oem_1_1600.jpg"
                },
                new Car()
                {
                    Id = 4,
                    Name = "Audi Q5",
                    Year = 2019,
                    Price = 59200,
                    Km = 47,
                    Fuel = "Diesel",
                    City = "Zhytomyr",
                    Transmission = "Automat",
                    ImagePath = @"https://img.chceauto.pl/audi/q5/audi-q5-suv-3519-32981_head.jpg"
                },
                new Car()
                {
                    Id = 5,
                    Name = "Porsche Cayenne",
                    Year = 2013,
                    Price = 32500,
                    Km = 159,
                    Fuel = "Diesel",
                    City = "Uzhhorod",
                    Transmission = "Automat",
                    ImagePath = @"https://i.gaw.to/content/photos/10/97/109744_Porsche_Cayenne_Turbo_S_il_ne_fait_pas_dans_la_dentelle.jpg?460x287"
                },
                new Car()
                {
                    Id = 6,
                    Name = "Ford Focus",
                    Year = 2013,
                    Price = 6900,
                    Km = 218,
                    Fuel = "Gasoline",
                    City = "Kiyv",
                    Transmission = "Automat",
                    ImagePath = @"https://e7.pngegg.com/pngimages/968/736/png-clipart-car-ford-focus-electric-2013-ford-focus-2014-ford-focus-se-carrom-compact-car-sedan-thumbnail.png"
                }
            });
        }
    }
}
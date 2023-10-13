using System;
using System.Linq;
using Ishu_Bowl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ishu_Bowl.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BowlContext(
                serviceProvider.GetRequiredService<DbContextOptions<BowlContext>>()))
            {
                // Look for any bowls.
                if (context.Bowl.Any())
                {
                    return; // DB has been seeded
                }

                context.Bowl.AddRange(
                    new Bowl
                    {
                        Name = "Ceramic Bowl",
                        DateCreated = DateTime.Parse("2022-01-15"),
                        Material = "Ceramic",
                        Price = 12.99M,
                        MicrowaveSafe = true,
                        Depth = 4,
                        Rating = RatingScale.Three
                    },
                    new Bowl
                    {
                        Name = "Plastic Bowl",
                        DateCreated = DateTime.Parse("2021-10-08"),
                        Material = "Plastic",
                        Price = 5.99M,
                        MicrowaveSafe = false,
                        Depth = 3,
                        Rating = RatingScale.One
                    },
                    new Bowl
                    {
                        Name = "Glass Bowl",
                        DateCreated = DateTime.Parse("2020-07-20"),
                        Material = "Glass",
                        Price = 9.99M,
                        MicrowaveSafe = true,
                        Depth = 3,
                        Rating = RatingScale.Two
                    },
                    new Bowl
                    {
                        Name = "Stainless Steel Bowl",
                        DateCreated = DateTime.Parse("2021-03-05"),
                        Material = "Stainless Steel",
                        Price = 14.99M,
                        MicrowaveSafe = false,
                        Depth = 5,
                        Rating = RatingScale.Five
                    },
                    new Bowl
                    {
                        Name = "Wooden Bowl",
                        DateCreated = DateTime.Parse("2019-11-12"),
                        Material = "Wood",
                        Price = 7.49M,
                        MicrowaveSafe = false,
                        Depth = 3,
                        Rating = RatingScale.Two
                    },
                    new Bowl
                    {
                        Name = "Porcelain Bowl",
                        DateCreated = DateTime.Parse("2020-05-18"),
                        Material = "Porcelain",
                        Price = 10.99M,
                        MicrowaveSafe = true,
                        Depth = 4,
                        Rating = RatingScale.Four
                    },
                    new Bowl
                    {
                        Name = "Bamboo Bowl",
                        DateCreated = DateTime.Parse("2021-09-30"),
                        Material = "Bamboo",
                        Price = 8.99M,
                        MicrowaveSafe = false,
                        Depth = 3,
                        Rating = RatingScale.Three
                    },
                      new Bowl
                      {
                          Name = "Melamine Bowl",
                          DateCreated = DateTime.Parse("2022-06-10"),
                          Material = "Melamine",
                          Price = 6.99M,
                          MicrowaveSafe = true,
                          Depth = 3,
                          Rating = RatingScale.Three
                      },
                    new Bowl
                    {
                        Name = "Copper Bowl",
                        DateCreated = DateTime.Parse("2021-04-28"),
                        Material = "Copper",
                        Price = 19.99M,
                        MicrowaveSafe = false,
                        Depth = 2,
                        Rating = RatingScale.Five
                    },
                    new Bowl
                    {
                        Name = "Marble Bowl",
                        DateCreated = DateTime.Parse("2020-12-15"),
                        Material = "Marble",
                        Price = 24.99M,
                        MicrowaveSafe = false,
                        Depth = 2,
                        Rating = RatingScale.Four
                    }


                );
                context.SaveChanges();
            }
        }
    }
}

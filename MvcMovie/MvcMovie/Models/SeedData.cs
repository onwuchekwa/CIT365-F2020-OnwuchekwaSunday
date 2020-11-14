using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return; // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        TItle = "Mountain of the Lord",
                        ReleaseDate = DateTime.Parse("2005-3-12"),
                        Genre = "Historical",
                        Rating = "R",
                        Price = 7.99M,
                        ImagePath = "mountain.jpg"
                    },

                    new Movie
                    {
                        TItle = "The Book of Mormon Movie",
                        ReleaseDate = DateTime.Parse("2020-11-8"),
                        Genre = "Adventure",
                        Rating = "PG",
                        Price = 10.99M,
                        ImagePath = "bom.jpg"
                    },

                    new Movie
                    {
                        TItle = "Mr. Krueger's Christmas",
                        ReleaseDate = DateTime.Parse("2010-4-15"),
                        Genre = "Fantasy",
                        Rating = "R",
                        Price = 5.99M,
                        ImagePath = "christmas.jpg"
                    },

                    new Movie
                    {
                        TItle = "Pioneer in Petticoats",
                        ReleaseDate = DateTime.Parse("2002-1-31"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 7.99M,
                        ImagePath = "pioneer.jpg"
                    },

                    new Movie
                    {
                        TItle = "The Best Two Years",
                        ReleaseDate = DateTime.Parse("2008-10-15"),
                        Genre = "Adventure",
                        Rating = "R",
                        Price = 9.56M,
                        ImagePath = "besttwoyears.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_app_6.Models;

namespace movie_app_6.Data
{
    public class movie_app_6Context : DbContext
    {
        public movie_app_6Context (DbContextOptions<movie_app_6Context> options)
            : base(options)
        {
        }

        public DbSet<movie_app_6.Models.Movie> Movie { get; set; } = default!;
    }
}

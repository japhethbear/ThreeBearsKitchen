using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThreeBearsKitchen.Models;

namespace ThreeBearsKitchen.Data
{
    public class ThreeBearsKitchenContext : DbContext
    {
        public ThreeBearsKitchenContext (DbContextOptions<ThreeBearsKitchenContext> options)
            : base(options)
        {

        }

        public DbSet<ThreeBearsKitchen.Models.Recipe> Recipes { get; set; } = default!;

    }
}

using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<FineJewellerCategory> FineJewellerCategories { get; set; }
        public DbSet<HighJewellerCategory> HighJewellerCategories { get; set; }
        public DbSet<BespokeAnimation> BespokeAnimations { get; set; }
    }
}


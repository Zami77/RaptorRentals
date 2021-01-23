using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaptorRentals.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorRentals.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RentalInvestment> Rentals { get; set; }
    }
}

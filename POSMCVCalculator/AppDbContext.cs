using System;
using Microsoft.EntityFrameworkCore;
using POSMCVCalculator.Models;

namespace POSMCVCalculator
{
	public class AppDbContext : DbContext
	{
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<SplineAreaChartModel> SplineChart { get; set; }
	}
}


using Microsoft.EntityFrameworkCore;
using CountryHolidaySolution.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryHolidaySolution.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CountryHolidaySolution.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupportedCountry>()
                .Property(e => e.Regions)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            modelBuilder.Entity<SupportedCountry>()
                .Property(e => e.HolidayTypes)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            modelBuilder.Entity<SupportedCountry>().OwnsOne(p => p.ToDate);
            modelBuilder.Entity<SupportedCountry>().OwnsOne(p => p.FromDate);
        }
        public DbSet<SupportedCountry> Countries { get; set; }
        public DbSet<DayStatus> DayStatuses { get; set; }
        public DbSet<MaxHolidayPeriod> HolidayPeriods { get; set; }
    }
}

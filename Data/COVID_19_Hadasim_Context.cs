using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COVID_19_Hadasim_.Models;

namespace COVID_19_Hadasim_.Data
{
    public class COVID_19_Hadasim_Context : DbContext
    {
        public COVID_19_Hadasim_Context (DbContextOptions<COVID_19_Hadasim_Context> options)
            : base(options)
        {
        }

        public DbSet<COVID_19_Hadasim_.Models.Member> Member { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasIndex(m => m.MemberId) // Create an index on MemberId
                .IsUnique(); // Ensure uniqueness
        }
        public DbSet<COVID_19_Hadasim_.Models.Vaccine>? Vaccine { get; set; }
    }
}

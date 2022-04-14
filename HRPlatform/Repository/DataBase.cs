using HRPlatform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPlatform.Repository
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<Skill>().ToTable("Skill");
        }
    }
}

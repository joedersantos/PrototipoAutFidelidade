using Microsoft.EntityFrameworkCore;
using Prototipo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototipo.Infra.Data.Context
{
    public class FidelidadeContext : DbContext
    {
        public FidelidadeContext(DbContextOptions<FidelidadeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(o => o.Id);
            modelBuilder.Entity<Endereco>().HasKey(o => o.Id);
        }
    }
}

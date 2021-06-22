using Microsoft.EntityFrameworkCore;
using Practica1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       
        public DbSet<Candidate> candidate { get; set; }

        public DbSet<Evaluation> evaluation { get; set; }
    }
}

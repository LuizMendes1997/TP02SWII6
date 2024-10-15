using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP02.Models;

namespace TP02.Data
{
    public class TP02Context : DbContext
    {
        public TP02Context (DbContextOptions<TP02Context> options)
            : base(options)
        {
        }

        public DbSet<TP02.Models.BL> BL { get; set; } = default!;
        public DbSet<TP02.Models.Cont> Cont { get; set; } = default!;
    }
}

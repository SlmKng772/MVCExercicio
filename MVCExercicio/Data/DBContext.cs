using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCExercicio.Models;

namespace MVCExercicio.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<MVCExercicio.Models.CadCli> CadCli { get; set; } = default!;

        public DbSet<MVCExercicio.Models.CadMaq> CadMaq { get; set; } = default!;

        public DbSet<MVCExercicio.Models.Inventario> Inventario { get; set; } = default!;
    }
}

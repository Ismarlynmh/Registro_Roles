using Registro_Roles.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Roles.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<aPermiso> aPermiso { get; set; }
        public DbSet<rPermiso> rPermiso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA/aPermiso.db");
        }
    }
}

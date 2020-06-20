using Microsoft.EntityFrameworkCore;
using Registro_Detalle_Aplicada_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Detalle_Aplicada_2.DALL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Mora> Moras { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\RegistroPrestamoDetalle.db");
        }
    }
}

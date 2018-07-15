using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositorioGenericoMVC5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //Aqui van los dbset
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Direcciones> Direcciones { get; set; }
    }
}
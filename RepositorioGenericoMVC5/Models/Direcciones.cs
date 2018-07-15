using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositorioGenericoMVC5.Models
{
    public class Direcciones
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public Persona Persona { get; set; }
    }
}
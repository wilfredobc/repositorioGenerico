using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepositorioGenericoMVC5.Models
{
    public class Persona
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad { get; set; }

        public int IdNacionalidad { get; set; }

        [ForeignKey("IdNacionalidad")]
        public Nacionalidad Nacionalidad { get; set; }

        public List<Direcciones> Direcciones { get; set; }


    }
}
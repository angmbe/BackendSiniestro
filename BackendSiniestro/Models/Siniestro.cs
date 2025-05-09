using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSiniestro.Models
{
    public class Siniestro
    {
        public int IdSiniestro { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombres { get;set; }
        public int Edad {  get; set; }
        public DateTime FechaSiniestro { get;set;}
        public int IdTipoSiniestro { get; set; }
        public int IdParentesco { get; set; }
        public int IdSexo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdEstadoSiniestro { get; set; }
    }
}

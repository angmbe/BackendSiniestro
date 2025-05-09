using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSiniestro.Models
{
    [Table("Parentesco")]
    public class Parentesco
    {
        public int IdParentesco { get; set; }
        public string Nombre { get; set; }
    }
}

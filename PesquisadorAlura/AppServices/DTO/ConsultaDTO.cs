using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class ConsultaDTO
    {
        [Required]
        public string Texto { get; set; }
    }
}

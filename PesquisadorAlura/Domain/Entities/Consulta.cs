using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Consulta : BaseEntity
    {
        public string TextoConsultado { get; set; }
        public string Excecao { get; set; }
        public ICollection<Resultado> Resultados { get; set; }
    }
}

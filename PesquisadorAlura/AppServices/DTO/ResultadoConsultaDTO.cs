using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class ResultadoConsultaDTO
    {
        public string Titulo { get; set; }
        public int CargaHoraria { get; set; }
        public string Descricao { get; set; }
        public List<string> Professores { get; set; }
    }
}

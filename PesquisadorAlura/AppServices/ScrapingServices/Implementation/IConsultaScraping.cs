using AppServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.ScrapingServices.Implementation
{
    public interface IConsultaScraping
    {
        List<ResultadoConsultaDTO> Curso(string textoConsulta);
    }
}

using AppServices.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Interfaces
{
    public interface IConsultaService
    {
        Task Consulta(string textoConsulta);
        List<Consulta> VizualizarConsultas();
    }
}

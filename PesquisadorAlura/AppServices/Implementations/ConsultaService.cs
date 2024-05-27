using AppServices.DTO;
using AppServices.Interfaces;
using AppServices.ScrapingServices.Implementation;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaScraping _consultaScraping;
        private readonly IConsultaRepository _repository;
        private readonly IMapper _mapper;

        public ConsultaService(IConsultaScraping consultaScraping, IMapper map, IConsultaRepository repository)
        {
            _consultaScraping = consultaScraping;
            _mapper = map;
            _repository = repository;
        }

        public async Task Consulta(string textoConsulta)
        {
            Consulta consulta = new Consulta();
            consulta.TextoConsultado = textoConsulta;
            try
            {
                List<ResultadoConsultaDTO> result = _consultaScraping.Curso(textoConsulta);
                consulta.Resultados = _mapper.Map<List<Resultado>>(result);
                consulta.Excecao = "";
            }
            catch (Exception e)
            {
                consulta.Excecao = e.Message;

            }
           await _repository.Creat(consulta);
        }
        public List<Consulta> VizualizarConsultas()
        {
           return _repository.GetAll().Include(c => c.Resultados).ToList();
        }
    }
}

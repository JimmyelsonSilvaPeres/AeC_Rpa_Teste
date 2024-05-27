using AppServices.Implementations;
using AppServices.Interfaces;
using AppServices.ScrapingServices.Implementation;
using AppServices.ScrapingServices.Interfaces;
using Data;
using Data.Repositories;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IoC
{
    public static class InjecaoDependencia
    {
        public static void InjetarRepositorios(IServiceCollection services)
        {
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
        }
        public static void InjetarServicos(IServiceCollection services)
        {
            services.AddScoped<IConsultaService, ConsultaService>();
            services.AddScoped<IConsultaScraping, ConsultaScraping>();
        }
        public static void InjetarAutomapper(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void InjetarContext(IServiceCollection services, string stringConexao) 
        {
            SQLitePCL.Batteries.Init();
            services.AddDbContext<Context>(options =>
            options.UseSqlite(stringConexao)
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

    }
}

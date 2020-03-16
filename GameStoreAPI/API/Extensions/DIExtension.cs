using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameService<GameBLL>, GameService>();

            return services;
        }
    }
}

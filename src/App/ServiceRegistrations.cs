using Hms.Exercise.Domain.ResultAggregate;
using Hms.Exercise.Domain.Services;
using Hms.Exercise.Infrastructure.Sql;
using Hms.Exercise.Infrastructure.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hms.Exercise.App
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddHmsServices(this IServiceCollection services)
        {
            services.AddScoped<ITransform, Transform>();
            services.AddDbContext<HmsDbContext>(opt => {
                opt.UseInMemoryDatabase("HmsInMemDb");
            });
            services.AddScoped<IResultRepository, SqlServerResultRepository>();
            return services;
        }
    }
}

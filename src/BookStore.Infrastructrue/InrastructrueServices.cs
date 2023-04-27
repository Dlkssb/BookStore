using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using BookStore.Infrastructrue.Presistince;
using BookStore.Infrastructrue.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructrue
{
    public static class InrastructrueServices
    {
            public static  IServiceCollection AddInfrastructrueDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BookStoreConnectionString")
            ));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRackRepository,RackRepository>();
            services.AddScoped<IShelfRepository, ShelfRepository>();
            return services;
        }
    }
}

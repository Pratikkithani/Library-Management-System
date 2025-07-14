using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repository;
using LibraryApp.Application.Interfaces.BookInterfaces;
using LibraryApp.Application.Interfaces.CategoryInterfaces;
using LibraryApp.Application.Interfaces.LoanInterfaces;
using LibraryApp.Application.Interfaces.MemberInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure
{
    public static class InterfaceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryWebAPIconnString"));
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IMemberRepository, MemberRespository>();


            return services;

        }
    }
}

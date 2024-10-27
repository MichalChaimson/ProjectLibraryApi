using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Repositories.Entity;
using Repositories.Repository;

namespace Repositories
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
           
            services.AddScoped<IAuthorR<Author>, AuthorRepository>();
            services.AddScoped<IBookR<Book>, BookRepository>();
            services.AddScoped<IBorrowingR<Borrowing>, BorrowingRepository>();
            services.AddScoped<IRequestR<Requeste>, RequestReposoitory>();
            services.AddScoped<IResponseR<Responsee>, ResponseRepository>();
            services.AddScoped<IUserR<User>, UserRepository>();

            return services;
        }
    }
}

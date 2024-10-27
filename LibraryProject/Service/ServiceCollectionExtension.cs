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
using Repositories;
using Common.Model;
using Service.Services;
using Service.Interfaces;
using Repositories.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IAuthor<AuthorDto>, AuthorService>();
            services.AddScoped<IBook<BookDto>, BookService>();
            services.AddScoped<IBorrowing<BorrowingDto>, BorrowingService>();
            services.AddScoped<IRequest<RequestDto>, RequestService>();
            services.AddScoped<IResponse<ResponseDto>, ResponseService>();
            services.AddScoped<IUser<UserDto>, UserService>();
            services.AddAutoMapper(typeof(MapProFile));
            return services;
        }
    }
}

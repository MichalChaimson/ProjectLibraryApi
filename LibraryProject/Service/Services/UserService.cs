
using AutoMapper;
using Common.Model;
using Repositories.Entity;
using Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service.Services
{
    public class UserService : IUser<UserDto>
    {
        private readonly IUserR<User> repository;
        private readonly IMapper mapper;
        public UserService(IUserR<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return await mapper.Map<Task<List<UserDto>>>(repository.GetAllAsync());
        
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            return await mapper.Map<Task<UserDto>>(repository.GetByEmailAsync(email));
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            return await mapper.Map<Task<UserDto>>(repository.GetByIdAsync(id));
        }

        public async Task<UserDto> GetByNameAsync(string name)
        {
         return await mapper.Map<Task<UserDto>>( repository.GetByNameAsync(name));
            
        }
        public async Task<UserDto> GetByPhoneAsync(string phone)
        {
            return await mapper.Map<Task<UserDto>>(repository.GetByPhoneAsync(phone));
        }
        public async Task<UserDto> PostAsync(UserDto item)
        {
            //UserDto u = await GetByEmailAsync(item.Email);
            //if (u == null)
            //{
                return await mapper.Map<Task<UserDto>>(repository.PostAsync(mapper.Map<User>(item)));
            //}
            //return null;
        }
        public async Task<UserDto> GetByNamAndPasswordAsync(string name, string password)
        {
            return await mapper.Map<Task<UserDto>>(repository.GetByNamAndPasswordAsync(name,password));
        }
        public async Task PutAsync(UserDto item)
        {
            await repository.PutAsync(mapper.Map<User>(item));
        }
    }
}

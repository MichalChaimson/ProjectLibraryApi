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

namespace Service.Services
{
    public class AuthorService:IAuthor<AuthorDto>
    {
        private readonly IAuthorR<Author> repository;
        private readonly IMapper mapper;
        public AuthorService(IAuthorR<Author> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAllAsync()
        {
            return await mapper.Map<Task<List<AuthorDto>>>(repository.GetAllAsync());
        }

        public async Task<AuthorDto> GetByNameAsync(string name)
        {
            return await mapper.Map<Task<AuthorDto>>(repository.GetByNameAsync(name));
        }
        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            return await mapper.Map<Task<AuthorDto>>(repository.GetByIdAsync(id));

        }
    }
}

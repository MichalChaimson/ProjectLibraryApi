using AutoMapper;
using Common.Model;
using Repositories.Entity;
using Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Enums;

namespace Service.Services
{
    public class BookService : IBook<BookDto>
    {
        private readonly IBookR<Book> repository;
        private readonly IMapper mapper;
        public BookService(IBookR<Book> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<BookDto>> GetAllAsync()
        {
            return await mapper.Map<Task<List<BookDto>>>(repository.GetAllAsync());
        }

        public async Task<List<BookDto>> GetByCategoryAsync(CategoryType category)
        {
            return await mapper.Map<Task<List<BookDto>>>(repository.GetByCategoryAsync(category));
        }
        public async Task<List<BookDto>> GetByGenreAsync(GenreType genre)
        {
            return await mapper.Map<Task<List<BookDto>>>(repository.GetByGenreAsync(genre));
        }
        public async Task<BookDto> GetByIdAsync(int id)
        {
            return await mapper.Map<Task<BookDto>>(repository.GetByIdAsync(id));
        }
        public async Task<BookDto> GetByNameAsync(string name)
        {
            return await mapper.Map<Task<BookDto>>(repository.GetByNameAsync(name));
        }
        public async Task<List<BookDto>> GetAllByName(string name)
        {
            return await mapper.Map<Task<List<BookDto>>>(repository.GetAllByName(name));
        }
    }
}

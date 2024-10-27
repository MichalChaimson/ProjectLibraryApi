using AutoMapper;
using Common.Model;
using Repositories.Entity;
using Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ResponseService : IResponse<ResponseDto>
    {
        private readonly IResponseR<Responsee> repository;
        private readonly IBookR<Book> repositoryBook;
        private readonly IMapper mapper;
        public ResponseService(IResponseR<Responsee> repository, IBookR<Book> repositoryBook, IMapper mapper)
        {
            this.repository = repository;
            this.repositoryBook = repositoryBook;
            this.mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<List<ResponseDto>> GetAllAsync()
        {
            return await mapper.Map<Task<List<ResponseDto>>>(repository.GetAllAsync());
        }

        public async Task<ResponseDto> PostAsync(ResponseDto item)
        {
            return await mapper.Map<Task<ResponseDto>>(repository.PostAsync(mapper.Map<Responsee>(item)));
        }
        public async Task PutAsync(ResponseDto item)
        {
            await repository.PutAsync(mapper.Map<Responsee>(item));
        }
    }
}


using AutoMapper;
using Common.Model;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Service
{
    public class MapProFile : Profile
    {
        public MapProFile()
        {
            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Task<Author>, Task<AuthorDto>>().ReverseMap();
            CreateMap<Task<List<Author>>, Task<List<AuthorDto>>>().ReverseMap();


            CreateMap<Book, BookDto>().ReverseMap();
           CreateMap<Task<Book>, Task<BookDto>>().ReverseMap();
            CreateMap<Task<List<Book>>, Task<List<BookDto>>>().ReverseMap();

            CreateMap<Borrowing,BorrowingDto>().ReverseMap();
            CreateMap<Task<Borrowing>, Task<BorrowingDto>>().ReverseMap();
            CreateMap<Task<List<Borrowing>>, Task<List<BorrowingDto>>>().ReverseMap();

            CreateMap<Requeste, RequestDto>().ReverseMap();
            CreateMap<Task<Requeste>, Task<RequestDto>>().ReverseMap();
            CreateMap<Task<List<Requeste>>, Task<List<RequestDto>>>().ReverseMap();

            CreateMap<Responsee, ResponseDto>().ReverseMap();
            CreateMap<Task<Responsee>, Task<ResponseDto>>().ReverseMap();
            CreateMap<Task<List<Responsee>>, Task<List<ResponseDto>>>().ReverseMap();

            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Task<User>,Task< UserDto>>().ReverseMap();
            CreateMap<Task<List<User>>, Task<List<UserDto>>>().ReverseMap();
        }
    }
}

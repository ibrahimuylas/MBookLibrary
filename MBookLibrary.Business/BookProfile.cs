using AutoMapper;
using MBookLibrary.Data.Entities;
using MBookLibrary.Models;
using MBookLibrary.Models.Externals;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBookLibrary.Business
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<BookDetails, Book>();

        }
    }
}

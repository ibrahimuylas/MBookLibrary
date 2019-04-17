using MBookLibrary.Data.Entities;
using MBookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBookLibrary.Business
{
    public interface IBookService
    {
        int Add(BookModel book);
        void Update(BookModel book);
        List<BookModel> GetAll();
        BookModel GetById(int Id);
        List<BookModel> Find(BookSearchCriteriaModel criteria);
        void Delete(int Id);
    }
}

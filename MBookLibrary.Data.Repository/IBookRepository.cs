using MBookLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MBookLibrary.Data.Repository
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        IQueryable<Book> FindBy(Expression<Func<Book, bool>> predicate);
        void Add(Book entity);
        void Update(Book entity);
        void Delete(Book entity);
        void DeleteById(int id);
    }
}

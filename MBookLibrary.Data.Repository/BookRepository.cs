using MBookLibrary.Common;
using MBookLibrary.Data.EF;
using MBookLibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MBookLibrary.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookContext context;
        public BookRepository(BookContext context)
        {
            this.context = context;
        }

        #region IBookRepository Member(s)
        public virtual IQueryable<Book> GetAll()
        {

            IQueryable<Book> query = context.Set<Book>().Where(x => x.State == EntityStatus.Active);
            return query;
        }

        public virtual Book GetById(int id)
        {
            return context.Set<Book>().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Book> FindBy(System.Linq.Expressions.Expression<Func<Book, bool>> predicate)
        {

            IQueryable<Book> query = GetAll().Where(predicate);
            return query;
        }

        public Book FirstOrDefault(System.Linq.Expressions.Expression<Func<Book, bool>> predicate)
        {
            return context.Set<Book>().Where(x => x.State == EntityStatus.Active).FirstOrDefault(predicate);
        }

        public virtual void Add(Book book)
        {
            book.State = EntityStatus.Active;
            book.Id = context.Books.Count() + 1;
            context.Set<Book>().Add(book);
            Save();
        }

        public virtual void Delete(Book book)
        {
            book.CanceledDate = DateTime.Now;
            book.State = EntityStatus.Deleted;
            Save();
        }

        public virtual void DeleteById(int id)
        {
            Book book = context.Set<Book>().FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                Delete(book);
            }
        }

        public void Update(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            Save();
        }

        public virtual void Save()
        {
            foreach (var item in context.ChangeTracker.Entries<Book>())
            {
                if (item.State == EntityState.Added || item.State == EntityState.Modified)
                {
                    if (item.Entity.State != EntityStatus.Deleted)
                    {
                        item.Entity.ModifiedDate = DateTime.Now;
                    }
                }
            }

            context.SaveChanges();
        }

        #endregion

        #region IDisposable Member(s)

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {

                if (disposing)
                {
                    context.Dispose();
                }

            }

            this.disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion


    }
}

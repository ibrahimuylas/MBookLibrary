using System;
using System.Collections.Generic;
using AutoMapper;
using MBookLibrary.Data.Entities;
using MBookLibrary.Data.Repository;
using MBookLibrary.Models;
using System.Linq;
using MBookLibrary.Externals;
using MBookLibrary.Models.Externals;

namespace MBookLibrary.Business
{
    public class BookService : ServiceBase, IBookService
    {
        private IMapper mapper;
        private IBookRepository repository;

        public BookService(IMapper mapper, IBookRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public int Add(BookModel bookModel)
        {
            var bookDetailsFactory = new BookDetailsFactory<OpenLibraryBookService>();
            var details = bookDetailsFactory.GetBookDetails(bookModel.ISBN);

            Book book = mapper.Map<BookDetails, Book>(details);

            repository.Add(book);
            return book.Id;
        }

        public void Delete(int Id)
        {
            repository.DeleteById(Id);
        }

        public List<BookModel> Find(BookSearchCriteriaModel criteria)
        {
            return mapper.Map<List<Book>, List<BookModel>>(repository.FindBy(x => x.ISBN == criteria.ISBN || x.Author.Contains(criteria.Author) || x.Genre.Contains(criteria.Genre) || x.Title.Contains(criteria.Title)).ToList());
        }

        public List<BookModel> GetAll()
        {
            return mapper.Map<List<Book>, List<BookModel>>(repository.GetAll().ToList());
        }

        public BookModel GetById(int Id)
        {
            return mapper.Map<Book, BookModel>(repository.GetAll().FirstOrDefault(x=>x.Id == Id));
        }

        public void Update(BookModel bookModel)
        {
            Book book = mapper.Map<BookModel, Book>(bookModel);
            repository.Update(book);
        }
    }
}

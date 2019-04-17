using System;
using MBookLibrary.Models.Externals;

namespace MBookLibrary.Externals
{
    public class BookDetailsFactory<T> where T : IBookDetailService
    {
        public BookDetailsFactory()
        {
        }

        public BookDetails GetBookDetails(string isbnCode) {
            IBookDetailService detailService = null;

            if (typeof(T) == typeof(OpenLibraryBookService))
                detailService = new OpenLibraryBookService();

            if (detailService != null)
            {
                detailService.Init();
                return detailService.GetBookDetails(isbnCode);
            }

            return null;
        }
    }
}

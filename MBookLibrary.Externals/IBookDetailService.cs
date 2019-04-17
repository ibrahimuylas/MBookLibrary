using System;
using MBookLibrary.Models.Externals;

namespace MBookLibrary.Externals
{
    public interface IBookDetailService 
    {
        void Init();

        BookDetails GetBookDetails(string isbnCode);
    }
}

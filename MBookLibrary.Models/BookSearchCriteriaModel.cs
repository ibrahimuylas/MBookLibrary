using System;

namespace MBookLibrary.Models
{
    public class BookSearchCriteriaModel : ModelBase
    {
        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }
    }
}

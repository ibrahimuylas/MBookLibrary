using System;
using System.Collections.Generic;
using System.Text;

namespace MBookLibrary.Data.Entities
{
    public class Book :EntityBase
    {
        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }
    }
}

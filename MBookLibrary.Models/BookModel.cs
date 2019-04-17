﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MBookLibrary.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }
    }
}
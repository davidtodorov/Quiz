using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Quote> Quotes { get; set; } = new List<Quote>();
    }
}

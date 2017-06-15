using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Author
    {
		public long Id { get; set; }

		public String Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}
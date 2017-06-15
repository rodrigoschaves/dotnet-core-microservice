using System;
namespace WebAPI.Models
{
    public class Book
    {

		public long Id { get; set; }

		public String Title { get; set; }

        public Category Category { get; set; }

        public Author Author { get; set; }

        public Decimal price { get; set; }
    }
}

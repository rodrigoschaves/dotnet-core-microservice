using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class BookController : Controller
    {
		private readonly StoreContext _context;

		public BookController(StoreContext context)
		{
			_context = context;
		}

		[HttpGet]
        public IEnumerable<Book> Get()
		{
            return _context.Books.ToList();
		}

		[HttpGet("{id}")]
		public Book Get(int id)
		{
            return _context.Books.FirstOrDefault(p => p.Id.Equals(id));
		}
        
		[HttpPost]
        public Book Create([FromBody]Book book)
		{
            _context.Books.Add(book);
			_context.SaveChanges();

			return book;
		}

		[HttpPut("{id}")]
		public void Update(int id, [FromBody]Book book)
		{
			
            var bookFromDb = _context.Books.FirstOrDefault(t => t.Id == id);

            bookFromDb.Title = book.Title;
            bookFromDb.price = book.price;
			bookFromDb.Category = book.Category;

            _context.Books.Update(bookFromDb);
			_context.SaveChanges();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var authorFromDb = _context.Authors.FirstOrDefault(t => t.Id == id);
            _context.Authors.Remove(authorFromDb);
            _context.SaveChanges();
		}
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class AuthorController : Controller
    {
		private readonly StoreContext _context;

		public AuthorController(StoreContext context)
		{
            _context = context;
		}

		[HttpGet]
		public IEnumerable<Author> Get()
		{
            return _context.Authors.ToList();
		}

		[HttpGet("{id}")]
		public Author Get(int id)
		{
            return _context.Authors.FirstOrDefault(p => p.Id.Equals(id));
		}
        
		[HttpPost]
        public Author Create([FromBody]Author author)
		{
            _context.Authors.Add(author);
			_context.SaveChanges();

			return author;
		}

		[HttpPut("{id}")]
		public void Update(int id, [FromBody]Author author)
		{
			
            var authorFromDb = _context.Authors.FirstOrDefault(t => t.Id == id);
	
			authorFromDb.Name = author.Name;
            authorFromDb.Books = author.Books;
			_context.Authors.Update(authorFromDb);
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

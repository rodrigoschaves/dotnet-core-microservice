using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	public class CategoryController : Controller
    {
		private readonly StoreContext _context;

        public CategoryController(StoreContext context)
		{
			_context = context;
			IList<Author> authors = new List<Author>();
			authors.Add(new Author()
			{
				Name = "J. K. Rowling",
				Books = new List<Book>() {
					new Book() { Title = "Harry Potter and the Philosopher's Stone" },
					new Book() { Title = "Harry Potter and the Chamber of Secrets" },
					new Book() { Title = "Harry Potter and the Half-Blood Prince" },
					new Book() { Title = "Harry Potter and the Prisoner of Azkaban" }
				}
			});
			authors.Add(new Author() { Name = "J. R. R. Tolkien" });
			authors.Add(new Author() { Name = "Rodrigo Soares" });
			_context.Authors.AddRange(authors);
			_context.SaveChanges();
		}

		[HttpGet]
        public IEnumerable<Category> Get()
		{
            return _context.Categories.ToList();
		}

		[HttpGet("{id}")]
        public Category Get(int id)
		{
            return _context.Categories.FirstOrDefault(p => p.Id.Equals(id));
		}
        
		[HttpPost]
        public Category Create([FromBody]Category category)
		{
            _context.Categories.Add(category);
			_context.SaveChanges();

			return category;
		}

		[HttpPut("{id}")]
        public void Update(int id, [FromBody]Category category)
		{
			
            var categoryDb = _context.Authors.FirstOrDefault(t => t.Id == id);
			category.Name = categoryDb.Name;
            _context.Categories.Update(category);
			_context.SaveChanges();
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
            var categoryFromDb = _context.Categories.FirstOrDefault(t => t.Id == id);
            _context.Categories.Remove(categoryFromDb);
            _context.SaveChanges();
		}
    }
}

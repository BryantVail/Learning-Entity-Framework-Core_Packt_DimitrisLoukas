using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;
using Newtonsoft.Json;

namespace BookStoreApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(b => b.Author).ToListAsync();
            return View(books);
        }

        [Route("Books/Explicit")]
        public async Task<IActionResult> BooksExplicit()
        {
            var books = await _context.Books.ToListAsync();
            foreach (var book in books)
            {
                await _context.Entry(book).Reference(b => b.Author).LoadAsync();
            }
            return View("Index", books);
        }

        [Route("Books/Eager")]
        public async Task<IActionResult> BooksEager()
        {
            var books = await _context.Books.Include(b => b.Author).ToListAsync();
            return View("Index", books);
        }

        [Route("Books/Raw")]
        public async Task<IActionResult> BooksRaw()
        {
            var books = await _context.Books.FromSql("SELECT * FROM dbo.books")
                                            .Include(b => b.Author)
                                            .AsNoTracking()
                                            .ToListAsync();
            return View("Index", books);
        }

        [Route("Books/Raw/Author/{id}")]
        public async Task<IActionResult> BooksByAuthorRaw(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                int authorId = (int)id;
                var books = await _context.Books.FromSql($"SELECT * FROM dbo.Books WHERE AuthorId={authorId}")
                                            .Include(b => b.Author)
                                            .ToListAsync();
                return View("Index", books);
            }
        }

        [Route("books/sp/{firstName}/{lastName}")]
        public async Task<IActionResult> BooksSp(string firstName, string lastName)
        {
            var books = await _context.Books.FromSql($"EXEC dbo.BooksByAuthor {firstName}, {lastName}").ToListAsync();
            return View("Index", books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                int bookId = (int)id;
                var book = await _context.Books.AsNoTracking().SingleOrDefaultAsync(b => b.Id == id);
                if(book == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(book);
                }
            }
        }
        
        [Route("books/author/{id}")]
        public async Task<IActionResult> GetBookByAuthor(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                int authorId = (int)id;
                var books = await ( from b in _context.Books
                            where b.AuthorId == authorId
                            orderby b.Isbn descending
                            select b ).ToListAsync();
                if(books == null)
                {
                    return NotFound();
                }
                else
                {
                    return View("ByAuthor", books);
                }
            }
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,AuthorId,Isbn")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AuthorId,Isbn")] Book book, byte[] RowVersion)
        {
            book.RowVersion = RowVersion;
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "This book has been edited by another user. Please exit and try again");
                        return View(book);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(m => m.Id == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}

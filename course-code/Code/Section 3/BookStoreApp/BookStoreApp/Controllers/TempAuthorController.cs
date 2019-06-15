using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using BookStoreApp.Models;
using BookStoreApp.Data;

namespace BookStoreApp.Controllers
{
    [Route("temp-authors")]
    public class TempAuthorController : Controller
    {
        private AppDbContext _context;

        public TempAuthorController(AppDbContext context)
        {
            _context = context;
        }
        
        [Route("create")]
        public async Task<string> CreateTempAuthor()
        {
            var author = new Author()
            {
                FirstName = "Mark",
                LastName = "Robinson",
                DoB = new DateTime(1962, 06, 12),
                Nationality = "Canada"
            };
            _context.Authors.Add(author);
            //Don't forget to save
            await _context.SaveChangesAsync();
            return "Author successfully added";
        }

        [Route("update")]
        public async Task<string> UpdateTempAuthor()
        {
            var author = await (from a in _context.Authors
                          where a.FirstName.Equals("Mark") && a.LastName.Equals("Robinson")
                          select a).SingleOrDefaultAsync();
            if(author == null)
            {
                return "Update failed";
            }
            else
            {
                if(author.MiddleName == null)
                {
                    author.MiddleName = "Jake";
                }
                else
                {
                    author.MiddleName = null;
                }
                _context.Update(author);
                await _context.SaveChangesAsync();
                return "Temp author updated";
            }
        }

        [Route("delete")]
        public async Task<string> DeleteTempAuthor()
        {
            var author = await (from a in _context.Authors
                                where a.FirstName.Equals("Mark") && a.LastName.Equals("Robinson")
                                select a).SingleOrDefaultAsync();
            if(author == null)
            {
                return "Author not found";
            }
            else
            {
                _context.Remove(author);
                await _context.SaveChangesAsync();
                return "Author removed";
            }
        }
    }
}

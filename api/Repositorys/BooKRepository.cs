using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositorys
{
    public class BooKRepository : IBookRepository
    {
        
       private readonly ApplicationDbContext _context;
       public BooKRepository(ApplicationDbContext context)
       {
        _context=context;
       }
        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x=>x.Id == id);
            if(bookModel == null)
            {
                return null;
            }
            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateAsync(int id, Book updateBook)
        {
            var existingBook =await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
            if(existingBook == null)
            {
                return null;
            }
            existingBook.Title = updateBook.Title;
            existingBook.Author = updateBook.Author;
            existingBook.Description = updateBook.Description;

            await _context.SaveChangesAsync();
            return existingBook;
        }
    }
}
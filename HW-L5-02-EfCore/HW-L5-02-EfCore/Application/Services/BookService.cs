using HW_L5_02_EfCore.Domain.Entities;
using HW_L5_02_EfCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace HW_L5_02_EfCore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;


        public BookService(AppDbContext context)
        {
            _context = context;
        }



        public async Task AddBook(Book book)
        {
            var existingBook =  await _context.Books .FirstOrDefaultAsync(x => x.Title == book.Title);


            if (existingBook != null)
            {
                existingBook.Mojudi++;

                await _context.SaveChangesAsync();

                return;
            }


            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();
        }





        public async Task UpdateBook(Book book)
        {
            var existingBook =
                await _context.Books  .FirstOrDefaultAsync(x => x.Id == book.Id);


            if (existingBook == null)
                return;


            existingBook.Title = book.Title;

            existingBook.Author = book.Author;

            existingBook.Price = book.Price;

            existingBook.Mojudi = book.Mojudi;


            await _context.SaveChangesAsync();
        }





        public async Task DeleteBook(int id)
        {
            var book = await _context.Books  .FirstOrDefaultAsync(x => x.Id == id);


            if (book == null)
                return;


            _context.Books.Remove(book);


            await _context.SaveChangesAsync();
        }





        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books .FirstOrDefaultAsync(x => x.Id == id);


            return book;
        }





        public async Task<List<string>> GetBookTitles()
        {
            var titles =  await _context.Books .Select(x => x.Title) .ToListAsync();


            return titles;
        }





        public async Task<List<Book>> GetBooks(int pageNumber, int pageSize)
        {
            var books = await _context.Books.Skip((pageNumber - 1) * pageSize)  .Take(pageSize) .ToListAsync();


            return books;
        }

    }
}
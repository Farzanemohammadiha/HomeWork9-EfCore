using HW_L5_02_EfCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_L5_02_EfCore.Application.Services
{
    public interface IBookService
    {
        Task AddBook(Book book);

        Task UpdateBook(Book book);

        Task DeleteBook(int id);

        Task<Book> GetBookById(int id);

        Task<List<string>> GetBookTitles();

        Task<List<Book>> GetBooks(int pageNumber, int pageSize);
    }
}

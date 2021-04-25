using LibbaryMangmantSystem.Data;
using LibbaryMangmantSystem.Interface;
using LibbaryMangmantSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibbaryMangmantSystem.Repository
{
    public class RepositoryBook : IRepository<Book>
    {
        public async Task<Book> Create(Book book)
        {
            _dbcontext.Add(book);
            await _dbcontext.SaveChangesAsync();
            return book;
        }

        public void Delete(Book book)
        {
            _dbcontext.Books.Remove(book);
             _dbcontext.SaveChangesAsync();
        }

        public IEnumerable<Book> GetAll()
        {
            return  _dbcontext.Books.Include(b => b.Genres).Where(i => i.IsDeleted == false).ToList();
        }

        public Book GetById(int? Id)
        {
            return  _dbcontext.Books.Find(Id);
        }

        public IEnumerable<Genre> GetGerne()
        {
            return _dbcontext.Genres.ToList();
        }

        public void Update(Book book)
        {
            _dbcontext.Update(book);
             _dbcontext.SaveChangesAsync();
        }

        public bool Exists(int Id)
        {
            return _dbcontext.Books.Any(x=>x.Id==Id);
        }

        DataModelContext _dbcontext;
        public RepositoryBook(DataModelContext dbContext)
        {
            _dbcontext = dbContext;
        }
        
    }
}

using LibbaryMangmantSystem.Data;
using LibbaryMangmantSystem.Interface;
using LibbaryMangmantSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LibbaryMangmantSystem.Repository
{
    public class RepositoryGener
    {
        DataModelContext _dbcontext;
        public RepositoryGener(DataModelContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<Genre> Create(Genre genre)
        {
            _dbcontext.Add(genre);
            await _dbcontext.SaveChangesAsync();
            return genre;
        }

        public void Delete(Genre genre)
        {
            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChangesAsync();
        }

        public bool Exists(int Id)
        {
            return _dbcontext.Genres.Any(x => x.Id==Id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return  _dbcontext.Genres.Where(x => x.IsDeleted == false).ToList();
        }

        public Genre GetById(int? Id)
        {
            return  _dbcontext.Genres.Find(Id);
        }

        public IEnumerable<Genre> GetGerne()
        {
            throw new NotImplementedException();
        }

        public void Update(Genre genre)
        {
            _dbcontext.Update(genre);
            _dbcontext.SaveChangesAsync();
        }
    }
}

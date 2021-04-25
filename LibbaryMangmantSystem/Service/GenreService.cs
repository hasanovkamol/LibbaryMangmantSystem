using LibbaryMangmantSystem.Interface;
using LibbaryMangmantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibbaryMangmantSystem.Service
{
    public class GenreService
    {
        private readonly IRepository<Genre> _genre;

        public GenreService(IRepository<Genre> genre)
        {
            _genre = genre;
        }
        //Get Books Details By Book Id
        public Genre GetGenreByID(int? genreId)
        {
            return  _genre.GetById(genreId);
        }
        //GET All Books Details 
        public IEnumerable<Genre> GetAllGenre()
        {
            try {
                return  _genre.GetAll();
            }
            catch (Exception) {
                throw;
            }
        }
        //Add Book
        public async Task<Genre> AddGenre(Genre genre)
        {
            return await _genre.Create(genre);
        }
        //Delete Book 
        public bool DeleteGenre(int genreId)
        {

            try {
                   var item =  _genre.GetById(genreId);
                    _genre.Delete(item);
                return true;
            }
            catch (Exception) {
                return true;
            }

        }
        //Update GenreService Details
        public bool Update(Genre genre)
        {
            try {
                 _genre.Update(genre);
                return true;
            }
            catch (Exception) {
                return true;
            }
        }
        // Exists Book
        public bool Exists(int id)
        {
            return _genre.Exists(id);
        }
    }
}

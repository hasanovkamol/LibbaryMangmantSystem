using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibbaryMangmantSystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string AuthorBook { get; set; }
        public int GenreId { get; set; }
        public Genre Genres { get; set; }
    }
}

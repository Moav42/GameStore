using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? BaseGenreId { get; set; }

        public Genre BaseGenre { get; set; }

        public ICollection<GameGenre> Games { get; set; }
    }
}
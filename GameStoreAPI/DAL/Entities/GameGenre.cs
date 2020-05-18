using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class GameGenre
    {
        public int GameId { get; set; }
        public int GenreId { get; set; }
        public Game Game { get; set; }
        public Genre Genre { get; set; }
    }
}

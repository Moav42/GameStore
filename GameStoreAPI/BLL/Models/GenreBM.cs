using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class GenreBM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? BaseGenreId { get; set; }
    }
}

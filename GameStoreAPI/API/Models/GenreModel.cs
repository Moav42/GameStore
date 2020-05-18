﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class GenreModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? BaseGenreId { get; set; }
    }
}
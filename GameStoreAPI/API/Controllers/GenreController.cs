using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genreBMs = await _genreService.GetAllGenresAsync();
            var genreModels = _mapper.Map<IEnumerable<GenreModel>>(genreBMs);

            return Ok(genreModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genreBM = await _genreService.GetGenreAsync(id);

            if(genreBM == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GenreModel>(genreBM));
        }

        [HttpPost]
        public async Task<IActionResult> PostGenre(GenreModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            await _genreService.AddGenreAsync(_mapper.Map<GenreBM>(model));

            return CreatedAtAction(nameof(GetGenreById), new { id = model.Id }, model);
        }
    }
}
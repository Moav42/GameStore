using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper, IGenreService genreService)
        {
            _gameService = gameService;
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var gameBMs = await _gameService.GetAllGamesAsync();

            return Ok(_mapper.Map<IEnumerable<GameModel>>(gameBMs));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var gameBM = await _gameService.GetGameAsync(id);

            if (gameBM == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<GameModel>(gameBM));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostGame(GameModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _gameService.AddGameAsync(_mapper.Map<GameBM>(model));

            return CreatedAtAction(nameof(GetGameById), new { id = model.Id }, model);
        }

        [HttpGet("{gameId}/genres")]
        public async Task<IActionResult> GetGameGenres(int gameId)
        {      
            var genreBMs = await _genreService.GetGenresByGameAsync(gameId);
            var genreModels = _mapper.Map<IEnumerable<GenreModel>>(genreBMs);           

            return Ok(genreModels);
        }

        [HttpPost("{gameId}/genres")]
        public async Task<IActionResult> AssignGenreToGame(int gameId, int genreId)
        {
            if(!await _genreService.ExistsGenre(genreId))
            {
                return BadRequest();
            }

            await _genreService.AssignGenreToGame(gameId, genreId);

            return Ok();
        }      

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredGames([FromQuery]string searchString, [FromQuery]int genreId)
        {
            IEnumerable<GameBM> gameBMs = new List<GameBM>();

            if(searchString != null && searchString.Length > 2 && genreId != 0)
            {
                gameBMs = await _gameService.GetGamesFilteredByGenreAndName(searchString, genreId);
            }

            if(searchString != null && searchString.Length > 2)
            {
                gameBMs = await _gameService.GetGamesFilteredByName(searchString);
            }

            if(genreId != 0)
            {
                gameBMs = await _gameService.GetGamesFilteredByGenre(genreId);
            }

            return Ok(_mapper.Map<IEnumerable<GameModel>>(gameBMs));
        }      

    }
}
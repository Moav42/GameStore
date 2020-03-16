using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IGameService<GameBLL> _gameService;
        private readonly IMapper _mapper;
        public GameController(IGameService<GameBLL> gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetAllGames()
        {
            var modelBLL = await _gameService.ReadAllGamesAsync();
            var models = new List<GameModel>();

            foreach (var item in modelBLL)
            {
                models.Add(_mapper.Map<GameModel>(item));
            }
            if (models.Count == 0)
            {
                return NotFound();
            }
            return Ok(models);
        }
    }
}
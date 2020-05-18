using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddGameAsync(GameBM game)
        {
            await _unitOfWork.GameRepository.CreateGameAsync(_mapper.Map<Game>(game));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameBM>> GetAllGamesAsync()
        {
            var games = await _unitOfWork.GameRepository.ReadAllGamesAsync();
            var gameBMs = _mapper.Map<IEnumerable<GameBM>>(games);

            return gameBMs;
        }

        public async Task<GameBM> GetGameAsync(int id)
        {
            var game = await _unitOfWork.GameRepository.ReadGameAsync(id);

            return _mapper.Map<GameBM>(game);
        }

        public async Task<IEnumerable<GameBM>> GetGamesFilteredByName(string filterString)
        {
            var games = await _unitOfWork.GameRepository.ReadGamesFilteredByName(filterString);
            var gameBMs = _mapper.Map<IEnumerable<GameBM>>(games);

            return gameBMs;
        }

        public async Task<IEnumerable<GameBM>> GetGamesFilteredByGenre(int genreId)
        {
            var games = await _unitOfWork.GameRepository.ReadGamesFilteredByGenre(genreId);
            var gameBMs = _mapper.Map<IEnumerable<GameBM>>(games);

            return gameBMs;
        }
        public async Task<IEnumerable<GameBM>> GetGamesFilteredByGenreAndName(string filterString, int genreId)
        {
            var games = await _unitOfWork.GameRepository.ReadGamesFilteredByGenreAndName(filterString, genreId);
            var gameBMs = _mapper.Map<IEnumerable<GameBM>>(games);

            return gameBMs;
        }
    }
}
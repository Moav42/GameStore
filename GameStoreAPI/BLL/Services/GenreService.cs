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
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AssignGenreToGame(int gameId, int genreId)
        {
            await _unitOfWork.GenreRepository.AssignGenreToGame(gameId, genreId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddGenreAsync(GenreBM genre)
        {
            if (genre.BaseGenreId == 0)
            {
                genre.BaseGenreId = null;
            }

            await _unitOfWork.GenreRepository.CreateGenreAsync(_mapper.Map<Genre>(genre));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GenreBM>> GetAllGenresAsync()
        {
            var genres = await _unitOfWork.GenreRepository.ReadAllGenresAsync();
            var genreBMs = _mapper.Map<IEnumerable<GenreBM>>(genres);

            return genreBMs;
        }

        public async Task<GenreBM> GetGenreAsync(int id)
        {
            var genre = await _unitOfWork.GenreRepository.ReadGenreAsync(id);

            return _mapper.Map<GenreBM>(genre);
        }

        public async Task<IEnumerable<GenreBM>> GetGenresByGameAsync(int gameId)
        {
            var genres = await _unitOfWork.GenreRepository.ReadGenresByGameAsync(gameId);
            var genreBMs = _mapper.Map<IEnumerable<GenreBM>>(genres);

            return genreBMs;
        }

        public async Task<bool> ExistsGenre(int genreId)
        {
            return await GetGenreAsync(genreId) != null;
        }
    }
}

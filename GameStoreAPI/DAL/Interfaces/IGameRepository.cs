using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGameRepository
    {
        Task CreateGameAsync(Game game);
        Task<IEnumerable<Game>> ReadAllGamesAsync();
        Task<Game> ReadGameAsync(int id);
        Task<IEnumerable<Game>> ReadGamesFilteredByName(string filterString);
        Task<IEnumerable<Game>> ReadGamesFilteredByGenre(int genreId);
        Task<IEnumerable<Game>> ReadGamesFilteredByGenreAndName(string filterString, int genreId);
    }
}
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        Task AddGameAsync(GameBM game);
        Task<IEnumerable<GameBM>> GetAllGamesAsync();
        Task<GameBM> GetGameAsync(int id);
        Task<IEnumerable<GameBM>> GetGamesFilteredByName(string filterString);
        Task<IEnumerable<GameBM>> GetGamesFilteredByGenre(int genreId);
        Task<IEnumerable<GameBM>> GetGamesFilteredByGenreAndName(string filterString, int genreId);
    }
}
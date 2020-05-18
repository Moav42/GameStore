using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        Task AddGenreAsync(GenreBM genre);
        Task<IEnumerable<GenreBM>> GetAllGenresAsync();
        Task<IEnumerable<GenreBM>> GetGenresByGameAsync(int gameId);
        Task<GenreBM> GetGenreAsync(int id);
        Task AssignGenreToGame(int gameId, int genreId);
        Task<bool> ExistsGenre(int genreId);
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenreRepository
    {
        Task CreateGenreAsync(Genre genre);
        Task<IEnumerable<Genre>> ReadAllGenresAsync();
        Task<IEnumerable<Genre>> ReadGenresByGameAsync(int gameId);
        Task<Genre> ReadGenreAsync(int id);
        Task AssignGenreToGame(int gameId, int genreId);
    }
}

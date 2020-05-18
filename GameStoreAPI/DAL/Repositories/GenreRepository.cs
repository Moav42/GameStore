using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GameStoreContext _context;

        public GenreRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task AssignGenreToGame(int gameId, int genreId)
        {
            await _context.GameGenres.AddAsync(new GameGenre() { GameId = gameId, GenreId = genreId });
        }

        public async Task CreateGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        public async Task<IEnumerable<Genre>> ReadAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> ReadGenreAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<IEnumerable<Genre>> ReadGenresByGameAsync(int gameId)
        {
            return await _context.GameGenres.Where(gg => gg.GameId == gameId).Select(gg => gg.Genre).ToListAsync();
        }
    }
}

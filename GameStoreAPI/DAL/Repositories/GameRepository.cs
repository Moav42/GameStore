using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreContext _context;

        public GameRepository(GameStoreContext context)
        {
            _context = context;
        }

        public async Task CreateGameAsync(Game game)
        {
            await _context.Games.AddAsync(game);
        }

        public async Task<IEnumerable<Game>> ReadAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> ReadGameAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> ReadGamesFilteredByName(string filterString)
        {
            return await _context.Games.Where(g => g.Name.Contains(filterString)).ToListAsync();
        }

        public async Task<IEnumerable<Game>> ReadGamesFilteredByGenre(int genreId)
        {
            return await _context.GameGenres.Where(gg => gg.GenreId == genreId).Select(gg => gg.Game).ToListAsync();
        }

        public async Task<IEnumerable<Game>> ReadGamesFilteredByGenreAndName(string filterString, int genreId)
        {
            return await _context.GameGenres.Where(gg => gg.GenreId == genreId)
                        .Select(gg => gg.Game).Where(g => g.Name.Contains(filterString)).ToListAsync();
        }
    }
}
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GameRepository : IGameRepository<Game>
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> ReadAllGamesAsync()
        {
            var items = await Task.Run(() => _context.Games);
            return items;
        }

    }
}

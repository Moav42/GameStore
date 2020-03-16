using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GameService : IGameService<GameBLL>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameBLL>> ReadAllGamesAsync()
        {
            var itemsDAL = await _unitOfWork.GameRepository.ReadAllGamesAsync();
            var itemsBLL = new List<GameBLL>();
            foreach (var item in itemsDAL)
            {
                itemsBLL.Add(_mapper.Map<GameBLL>(item));
            }
            return itemsBLL;
        }

    }
}

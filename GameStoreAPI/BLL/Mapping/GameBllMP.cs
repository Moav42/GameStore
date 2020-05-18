using AutoMapper;
using BLL.Models;
using DAL.Entities;


namespace BLL.Mapping 
{
    public class GameBllMP : Profile
    {
        public GameBllMP()
        {
            CreateMap<Game, GameBM>();
            CreateMap<GameBM, Game>();
        }
    }
}

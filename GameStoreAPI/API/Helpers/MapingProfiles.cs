using API.Models;
using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace API.Helpers
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {
            CreateMap<Game, GameBLL>();
            CreateMap<GameBLL, Game>();

            CreateMap<GameBLL, GameModel>();
            CreateMap<GameModel, GameBLL>();
        }
    }
}

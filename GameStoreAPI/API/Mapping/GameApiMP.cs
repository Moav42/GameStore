using API.Models;
using AutoMapper;
using BLL.Models;

namespace API.Mapping
{
    public class GameApiMP : Profile
    {
        public GameApiMP()
        {
            CreateMap<GameBM, GameModel>();
            CreateMap<GameModel, GameBM>();
        }
    }
}

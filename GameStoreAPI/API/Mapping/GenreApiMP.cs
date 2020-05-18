using API.Models;
using AutoMapper;
using BLL.Models;

namespace API.Mapping
{
    public class GenreApiMP : Profile
    {
        public GenreApiMP()
        {
            CreateMap<GenreBM, GenreModel>();
            CreateMap<GenreModel, GenreBM>();
        }
    }
}

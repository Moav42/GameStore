using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapping
{
    public class GenreBllMP : Profile
    {
        public GenreBllMP()
        {
            CreateMap<Genre, GenreBM>();
            CreateMap<GenreBM, Genre>();
        }
    }
}

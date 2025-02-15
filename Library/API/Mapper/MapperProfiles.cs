using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace API.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Livre,LivreDTO>();
        }
    }


}


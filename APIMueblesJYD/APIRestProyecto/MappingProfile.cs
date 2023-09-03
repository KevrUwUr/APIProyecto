using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace APIRestProyecto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cargo, CargoDto>();
        }
    }
}

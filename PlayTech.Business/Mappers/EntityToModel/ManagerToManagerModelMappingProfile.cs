using AutoMapper;
using PlayTech.Abstractions.Entities;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Mappers.EntityToModel;

public class ManagerToManagerModelMappingProfile : Profile
{
    public ManagerToManagerModelMappingProfile ()
    {
        CreateMap<Manager, ManagerModel>().ReverseMap();
    }
}
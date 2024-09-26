using AutoMapper;
using PlayTech.Abstractions.Entities;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Mappers.EntityToModel;

public class DepartmentToDepartmentModelMappingProfile : Profile
{
    public DepartmentToDepartmentModelMappingProfile()
    {
        CreateMap<Department, DepartmentModel>();
    }
}
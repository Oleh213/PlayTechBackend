using AutoMapper;
using PlayTech.Abstractions.Entities;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Mappers.EntityToModel;

public class EmployeeToEmployeeModelMappingProfile : Profile
{
    public EmployeeToEmployeeModelMappingProfile()
    {
        CreateMap<Employee, EmployeeModel>();
    }
}
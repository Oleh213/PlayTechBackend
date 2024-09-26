using AutoMapper;
using PlayTech.Abstractions.Entities;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Mappers.ModelToEntity;

public class EmployeeModelToEmployeeMappingProfile : Profile
{
    public EmployeeModelToEmployeeMappingProfile()
    {
        CreateMap<EmployeeModel, Employee>()
            .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary))
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.Manager.Id))
            .ForMember(dest => dest.Manager, opt => opt.Ignore())
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id))
            .ForMember(dest => dest.Department, opt => opt.Ignore());
    }
}
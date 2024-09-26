using AutoMapper;
using MediatR;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Department;
using PlayTech.Repositories.Department;

namespace PlayTech.Business.Handlers.Department;

public class GetDepartmentsWithMoreThan50EmployeesCommandHandler : IRequestHandler<GetDepartmentsWithMoreThan50EmployeesCommand, IEnumerable<DepartmentModel>>
{
    private IDepartmentRepository _departmentRepository { get; set; }
    private IMapper _mapper { get; set; }

    public GetDepartmentsWithMoreThan50EmployeesCommandHandler(
        IDepartmentRepository departmentRepository, 
        IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DepartmentModel>> Handle(GetDepartmentsWithMoreThan50EmployeesCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<DepartmentModel>>(await _departmentRepository.GetDepartmentsWithMoreThan50EmployeesAsync());
    }
}
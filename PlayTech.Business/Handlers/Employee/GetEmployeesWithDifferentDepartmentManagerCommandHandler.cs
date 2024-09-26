using AutoMapper;
using MediatR;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Employee;
using PlayTech.Repositories.Employee;

namespace PlayTech.Business.Handlers.Employee;

public class GetEmployeesWithDifferentDepartmentManagerCommandHandler : IRequestHandler<GetEmployeesWithDifferentDepartmentManagerCommand, IEnumerable<EmployeeModel>>
{
    private IEmployeeRepository _employeeRepository { get; set; }
    private IMapper _mapper { get; set; }

    public GetEmployeesWithDifferentDepartmentManagerCommandHandler(
        IMapper mapper, 
        IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<IEnumerable<EmployeeModel>> Handle(GetEmployeesWithDifferentDepartmentManagerCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<EmployeeModel>>(await _employeeRepository.GetEmployeesWithDifferentDepartmentManagersAsync());
    }
}
using AutoMapper;
using MediatR;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Employee;
using PlayTech.Repositories.Employee;

namespace PlayTech.Business.Handlers.Employee;

public class GetEmployeesWithHigherSalaryThenManagersCommandHandler : IRequestHandler<GetEmployeesWithHigherSalaryThenManagersCommand, IEnumerable<EmployeeModel>>
{
    private IEmployeeRepository _employeeRepository { get; set; }
    private IMapper _mapper { get; set; }

    public GetEmployeesWithHigherSalaryThenManagersCommandHandler(
        IMapper mapper, 
        IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<IEnumerable<EmployeeModel>> Handle(GetEmployeesWithHigherSalaryThenManagersCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<EmployeeModel>>(await _employeeRepository.GetEmployeesWithHigherSalaryThenManagersAsync());
    }
}
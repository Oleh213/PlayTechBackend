using AutoMapper;
using MediatR;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Employee;
using PlayTech.Repositories.Employee;

namespace PlayTech.Business.Handlers.Employee;

public class GetAllEmployeesCommandHandler: IRequestHandler<GetAllEmployeesCommand, IEnumerable<EmployeeModel>>
{
    private IEmployeeRepository _employeeRepository { get; set; }
    private IMapper _mapper { get; set; }

    public GetAllEmployeesCommandHandler(
        IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }
    
    public async Task<IEnumerable<EmployeeModel>> Handle(GetAllEmployeesCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<EmployeeModel>>(await _employeeRepository.GetAllEmployeesAsync());
    }
}
using AutoMapper;
using MediatR;
using PlayTech.Business.Commands.Employee;
using PlayTech.Repositories.Employee;

namespace PlayTech.Business.Handlers.Employee;

public class UpdateEmployeeByIdCommandHandler : IRequestHandler<UpdateEmployeeByIdCommand>
{
    private IEmployeeRepository _employeeRepository { get; set; }
    private IMapper _mapper { get; set; }

    public UpdateEmployeeByIdCommandHandler(
        IMapper mapper,
        IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    public async Task Handle(UpdateEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        //todo: need to add a rule to check manager and also validator to check if salary is valid
        
        var employee = _mapper.Map<Abstractions.Entities.Employee>(request.EmployeeModel);

        await _employeeRepository.UpdateEmployeeAsync(employee);
    }
}
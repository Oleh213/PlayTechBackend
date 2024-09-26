using AutoMapper;
using MediatR;
using PlayTech.Business.Commands.Employee;
using PlayTech.Repositories.Employee;

namespace PlayTech.Business.Handlers.Employee;

public class AddNewEmployeeCommandHandler: IRequestHandler<AddNewEmployeeCommand>
{
    private IEmployeeRepository _employeeRepository { get; set; }
    private IMapper _mapper { get; set; }

    public AddNewEmployeeCommandHandler(
        IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }
    
    public async Task Handle(AddNewEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _employeeRepository.AddNewEmployeeAsync(request.Employee);
    }
}
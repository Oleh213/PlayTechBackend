using AutoMapper;
using MediatR;
using PlayTech.Business.Commands.Employee;
using PlayTech.Repositories.Employee;

namespace PlayTech.Business.Handlers.Employee;

public class DeleteAnEmployeeByIdCommandHandler: IRequestHandler<DeleteAnEmployeeByIdCommand>
{
    private IEmployeeRepository _employeeRepository { get; set; }
    private IMapper _mapper { get; set; }

    public DeleteAnEmployeeByIdCommandHandler(
        IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }
    
    public async Task Handle(DeleteAnEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAllEmployeesAsync();
        
        if (employees.Any(e => e.ManagerId == request.Id))
        {
            throw new InvalidOperationException($"Cannot delete employee with Id {request.Id} because they are a manager.");
        }
        
        await _employeeRepository.DeleteAnEmployeeAsync(request.Id);
    }
}
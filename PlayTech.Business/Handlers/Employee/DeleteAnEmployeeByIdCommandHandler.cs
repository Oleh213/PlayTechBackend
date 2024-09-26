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
        await _employeeRepository.DeleteAnEmployeeAsync(request.Id);
    }
}
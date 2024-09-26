using MediatR;

namespace PlayTechBackend.Business.Commands.Employee;

public class GetAllEmployeesCommand : IRequest<IEnumerable<Abstractions.Entities.Employee>>
{
    
}
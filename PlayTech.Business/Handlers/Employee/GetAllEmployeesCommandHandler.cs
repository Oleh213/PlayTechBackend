using MediatR;
using PlayTechBackend.Business.Commands.Employee;

namespace PlayTechBackend.Business.Handlers.Employee;

public class GetAllEmployeesCommandHandler: IRequestHandler<GetAllEmployeesCommand, IEnumerable<Abstractions.Entities.Employee>>
{
    
    public async Task<IEnumerable<Abstractions.Entities.Employee>> Handle(GetAllEmployeesCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<Abstractions.Entities.Employee>());
    }
}
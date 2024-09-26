using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Employee;

public class GetAllEmployeesCommand : IRequest<IEnumerable<EmployeeModel>>
{
    
}
using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Handlers.Employee;

public class GetEmployeesWithHigherSalaryThenManagersCommand : IRequest<IEnumerable<EmployeeModel>>
{
    
}
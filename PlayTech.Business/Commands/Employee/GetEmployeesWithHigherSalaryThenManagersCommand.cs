using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Employee;

public class GetEmployeesWithHigherSalaryThenManagersCommand : IRequest<IEnumerable<EmployeeModel>>
{
    
}
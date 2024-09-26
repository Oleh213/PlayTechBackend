using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Employee;

public class GetEmployeesWithHighestSalaryInDepartmentsCommand : IRequest<IEnumerable<EmployeeModel>>
{
    
}
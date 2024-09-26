using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Employee;

public class GetEmployeesWithDifferentDepartmentManagerCommand : IRequest <IEnumerable<EmployeeModel>>
{
    
}
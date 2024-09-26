using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Department;

public class GetDepartmentsWithMoreThan50EmployeesCommand : IRequest<IEnumerable<DepartmentModel>>
{
    
}
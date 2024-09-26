using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Department;

public class GetAllDepartmentsCommand : IRequest<IEnumerable<DepartmentModel>>
{
    
}
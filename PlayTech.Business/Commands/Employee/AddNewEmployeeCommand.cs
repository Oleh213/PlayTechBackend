using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Handlers.Employee;

public class AddNewEmployeeCommand : IRequest
{
    public EmployeeInputModel Employee { get; set; }
}
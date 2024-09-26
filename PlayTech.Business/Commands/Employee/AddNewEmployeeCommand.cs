using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Employee;

public class AddNewEmployeeCommand : IRequest
{
    public AddNewEmployeeCommand(EmployeeInputModel employee)
    {
        Employee = employee;
    }

    public EmployeeInputModel Employee { get; set; }
}
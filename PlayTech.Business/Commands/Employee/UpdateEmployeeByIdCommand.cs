using MediatR;
using PlayTech.Abstractions.Models;

namespace PlayTech.Business.Commands.Employee;

public class UpdateEmployeeByIdCommand : IRequest
{
    public UpdateEmployeeByIdCommand(EmployeeModel employeeModel)
    {
        EmployeeModel = employeeModel;
    }

    public EmployeeModel EmployeeModel { get; set; }
}
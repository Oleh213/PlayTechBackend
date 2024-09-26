using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Employee;

namespace PlayTech.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("allEmployees")]
    public async Task<IEnumerable<EmployeeModel>> GetAllEmployees(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllEmployeesCommand(), cancellationToken);
    }
    
    [HttpGet("employeesWithHighestSalaryInDepartments")]
    public async Task<IEnumerable<EmployeeModel>> GetEmployeesWithHighestSalaryInDepartments(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetEmployeesWithHighestSalaryInDepartmentsCommand(), cancellationToken);
    }
    
    [HttpGet("employeesWithDifferentDepartmentManager")]
    public async Task<IEnumerable<EmployeeModel>> GetEmployeesWithDifferentDepartmentManager(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetEmployeesWithDifferentDepartmentManagerCommand(), cancellationToken);
    }
    
    [HttpGet("employeesWithHigherSalaryThenManagers")]
    public async Task<IEnumerable<EmployeeModel>> GetEmployeesWithHigherSalaryThenManagers(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetEmployeesWithHigherSalaryThenManagersCommand(), cancellationToken);
    }
    
    [HttpPut("updateEmployee")]
    public async Task UpdateEmployee(EmployeeModel employeeModel,CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateEmployeeByIdCommand(employeeModel), cancellationToken);
    }
    
    [HttpPost("createANewEmployee")]
    public async Task UpdateEmployee(EmployeeInputModel employeeModel,CancellationToken cancellationToken)
    {
        await _mediator.Send(new AddNewEmployeeCommand(employeeModel), cancellationToken);
    }
    
    [HttpDelete("{Id}/deleteANEmployee")]
    public async Task UpdateEmployee(int Id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAnEmployeeByIdCommand(Id), cancellationToken);
    }
    
}
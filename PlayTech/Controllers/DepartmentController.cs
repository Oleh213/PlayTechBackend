using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Department;

namespace PlayTech.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("allDepartments")]
    public async Task<IEnumerable<DepartmentModel>> GetAllDepartments(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllDepartmentsCommand(), cancellationToken);
    }
    
    [HttpGet("departmentsWithMoreThan50Employees")]
    public async Task<IEnumerable<DepartmentModel>> GetDepartmentsWithMoreThan50Employees(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDepartmentsWithMoreThan50EmployeesCommand(), cancellationToken);
    }
    
    [HttpGet("departmentWithHighestSalary")]
    public async Task<DepartmentModel> GetDepartmentWithHighestSalary(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDepartmentWithHighestSalaryCommand(), cancellationToken);
    }
}
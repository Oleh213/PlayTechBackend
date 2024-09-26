using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayTechBackend.Abstractions.Entities;
using PlayTechBackend.Business.Commands;
using PlayTechBackend.Business.Commands.Employee;

namespace PlayTechBackend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Employee>> GetAllEmployees(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetAllEmployeesCommand(), cancellationToken);
    }}
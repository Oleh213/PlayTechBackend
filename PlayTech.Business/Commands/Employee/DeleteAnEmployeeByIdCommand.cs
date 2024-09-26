using MediatR;

namespace PlayTech.Business.Commands.Employee;

public class DeleteAnEmployeeByIdCommand : IRequest
{
    public DeleteAnEmployeeByIdCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
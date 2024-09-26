using AutoMapper;
using MediatR;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Department;
using PlayTech.Repositories.Department;

namespace PlayTech.Business.Handlers.Department;

public class GetDepartmentWithHighestSalaryCommandHandler : IRequestHandler<GetDepartmentWithHighestSalaryCommand, DepartmentModel>
{
    private IDepartmentRepository _departmentRepository { get; set; }
    private IMapper _mapper { get; set; }

    public GetDepartmentWithHighestSalaryCommandHandler(
        IDepartmentRepository departmentRepository, 
        IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    
    public async Task<DepartmentModel> Handle(GetDepartmentWithHighestSalaryCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<DepartmentModel>(await _departmentRepository.GetDepartmentWithHighestSalaryAsync());
    }
}
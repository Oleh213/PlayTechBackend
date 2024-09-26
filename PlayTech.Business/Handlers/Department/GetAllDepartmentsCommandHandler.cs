using AutoMapper;
using MediatR;
using PlayTech.Abstractions.Models;
using PlayTech.Business.Commands.Department;
using PlayTech.Repositories.Department;

namespace PlayTech.Business.Handlers.Department;

public class GetAllDepartmentsCommandHandler: IRequestHandler<GetAllDepartmentsCommand, IEnumerable<DepartmentModel>>
{
    public IDepartmentRepository _departmentRepository { get; set; }
    public IMapper _mapper { get; set; }

    public GetAllDepartmentsCommandHandler(
        IDepartmentRepository departmentRepository, 
        IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DepartmentModel>> Handle(GetAllDepartmentsCommand request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<DepartmentModel>>(await _departmentRepository.GetAllDepartmentsAsync());
    }
}
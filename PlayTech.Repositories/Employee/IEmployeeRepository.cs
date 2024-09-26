using PlayTech.Abstractions.Entities;

namespace PlayTech.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
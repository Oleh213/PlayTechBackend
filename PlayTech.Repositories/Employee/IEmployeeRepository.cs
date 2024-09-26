using PlayTech.Abstractions.Models;

namespace PlayTech.Repositories.Employee;

public interface IEmployeeRepository
{
    Task<IEnumerable<Abstractions.Entities.Employee>> GetAllEmployeesAsync();
    Task<IEnumerable<Abstractions.Entities.Employee>> GetEmployeesWithHigherSalaryThenManagersAsync();
    Task<IEnumerable<Abstractions.Entities.Employee>> GetEmployeesWithHighestSalaryInDepartmentsAsync();
    Task<IEnumerable<Abstractions.Entities.Employee>> GetEmployeesWithDifferentDepartmentManagersAsync();
    Task UpdateEmployeeAsync(Abstractions.Entities.Employee employee);
    Task AddNewEmployeeAsync(EmployeeInputModel employee);
    Task DeleteAnEmployeeAsync(int employeeId);
}
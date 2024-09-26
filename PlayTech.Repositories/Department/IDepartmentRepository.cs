namespace PlayTech.Repositories.Department;

public interface IDepartmentRepository
{ 
    Task<IEnumerable<Abstractions.Entities.Department>> GetAllDepartmentsAsync();
    Task<IEnumerable<Abstractions.Entities.Department>> GetDepartmentsWithMoreThan50EmployeesAsync();
    Task<Abstractions.Entities.Department> GetDepartmentWithHighestSalaryAsync();
    
}
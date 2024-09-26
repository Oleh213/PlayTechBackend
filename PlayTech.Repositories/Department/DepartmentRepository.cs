using System.Data;
using Dapper;

namespace PlayTech.Repositories.Department;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _dbConnection;

    public DepartmentRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Abstractions.Entities.Department>> GetAllDepartmentsAsync()
    {
        var query = $"SELECT * FROM {nameof(Department)}";
        
        return await _dbConnection.QueryAsync<Abstractions.Entities.Department>(query);
    }

    public async Task<IEnumerable<Abstractions.Entities.Department>> GetDepartmentsWithMoreThan50EmployeesAsync()
    {
        var query = @"
        SELECT d.Id, d.Name, COUNT(e.Id) AS EmployeeCount
        FROM Department d
        LEFT JOIN Employee e ON e.DepartmentId = d.Id
        GROUP BY d.Id, d.Name
        HAVING COUNT(e.Id) > 50";
        
        var departments = await _dbConnection.QueryAsync<Abstractions.Entities.Department>(query);
    
        return departments;
    }

    public async Task<Abstractions.Entities.Department> GetDepartmentWithHighestSalaryAsync()
    {
        var query = @"
        SELECT TOP 1 d.Id , d.Name, SUM(e.Salary) AS TotalSalary
        FROM Department d
        LEFT JOIN Employee e ON e.DepartmentId = d.Id
        GROUP BY d.Id, d.Name
        ORDER BY TotalSalary DESC";

        var department = await _dbConnection.QueryFirstOrDefaultAsync<Abstractions.Entities.Department>(query);
    
        return department;
    }

}
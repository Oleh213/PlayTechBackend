using System.Data;
using Dapper;
using PlayTech.Abstractions.Entities;
using PlayTech.Abstractions.Models;

namespace PlayTech.Repositories.Employee;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbConnection _dbConnection;

    public EmployeeRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<IEnumerable<Abstractions.Entities.Employee>> GetAllEmployeesAsync()
    {
        var query = @"
            SELECT e.Id, e.Name, e.Salary, e.ManagerId, e.DepartmentId, d.Id, d.Name
            FROM Employee e
            JOIN Department d ON e.DepartmentId = d.Id";
        
        var employees = await _dbConnection.QueryAsync<Abstractions.Entities.Employee, Abstractions.Entities.Department, Abstractions.Entities.Employee>(
            query,
            (employee, department) =>
            {
                employee.Department = department;
                return employee;
            },
            splitOn: "DepartmentId"
        );

        LinkManager(employees);
        
        return employees;
    }

    public async Task<IEnumerable<Abstractions.Entities.Employee>> GetEmployeesWithHigherSalaryThenManagersAsync()
    {
        var employees = await GetAllEmployeesAsync();
        
        var selectedEmployees = new List<Abstractions.Entities.Employee>();
        
        foreach (var employee in employees)
        {
            if (employee.Salary > employee.Manager.Salary)
            {
                selectedEmployees.Add(employee);
            }
        }
        
        return selectedEmployees;
    }

    public async Task<IEnumerable<Abstractions.Entities.Employee>> GetEmployeesWithHighestSalaryInDepartmentsAsync()
    {
        var query = @"
            SELECT e.Id, e.Name AS Name, e.Salary, e.DepartmentId, d.Name AS Name
            FROM Employee e
            JOIN (
                SELECT DepartmentId, MAX(Salary) AS MaxSalary
                FROM Employee
                GROUP BY DepartmentId
            ) AS MaxSalaries ON e.DepartmentId = MaxSalaries.DepartmentId AND e.Salary = MaxSalaries.MaxSalary
            JOIN Department d ON e.DepartmentId = d.Id";

        var employees = await _dbConnection.QueryAsync<Abstractions.Entities.Employee, Abstractions.Entities.Department, Abstractions.Entities.Employee>(
            query,
            (employee, department) => 
            {
                employee.Department = department;
                return employee;
            },
            splitOn: "DepartmentId");

        return employees;
    }

    public async Task<IEnumerable<Abstractions.Entities.Employee>> GetEmployeesWithDifferentDepartmentManagersAsync()
    {
        var query = @"
            SELECT e.Id, e.Name, 
                   e.Salary, 
                   e.DepartmentId,
                   e.ManagerId
            FROM Employee e
            WHERE e.ManagerId <> e.DepartmentId";

        var employees = await _dbConnection.QueryAsync<Abstractions.Entities.Employee>(query);

        return employees;
    }
    
    public async Task UpdateEmployeeAsync(Abstractions.Entities.Employee employee)
    {
        var query = @"
            UPDATE Employee
            SET 
                Name = @Name,
                Salary = @Salary,
                ManagerId = @ManagerId,
                DepartmentId = @DepartmentId
            WHERE Id = @Id";

        await _dbConnection.ExecuteAsync(query, new
        {
            employee.Name,
            employee.Salary,
            employee.ManagerId,
            employee.DepartmentId,
            employee.Id
        });
    }

    public async Task AddNewEmployeeAsync(EmployeeInputModel employee)
    {
        var query = @"
            INSERT INTO Employee (Name, Salary, DepartmentId, ManagerId)
            VALUES (@Name, @Salary, @DepartmentId, @ManagerId);
            SELECT CAST(SCOPE_IDENTITY() as int);"; 

        var parameters = new 
        {
            Name = employee.Name,
            Salary = employee.Salary,
            DepartmentId = employee.DepartmentId,
            ManagerId = employee.ManagerId
        };

        await _dbConnection.QuerySingleAsync(query, parameters);
    }
    
    public async Task DeleteAnEmployeeAsync(int employeeId)
    {
        var query = @"
            DELETE FROM Employee 
            WHERE Id = @EmployeeId";

        await _dbConnection.ExecuteAsync(query, new { EmployeeId = employeeId });
    }

    private void LinkManager(IEnumerable<Abstractions.Entities.Employee> employees)
    {
        foreach (var employee in employees)
        {
            employee.Manager = employee.ManagerId == 0 ? null : GetManager(employee.ManagerId, employees);
        }
    }
    
    
    private Manager GetManager(int managerId, IEnumerable<Abstractions.Entities.Employee> employees)
    {
        var employee = employees.Single(e => e.Id == managerId);
        
        return new Manager{ Id = employee.Id, Name = employee.Name, Salary = employee.Salary };
    }

}
using System.Data;
using PlayTech.Abstractions.Entities;
using Dapper;

namespace PlayTech.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbConnection _dbConnection;

    public EmployeeRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var query = "SELECT * FROM Em WHERE Id = @Id";
        
        return await _dbConnection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
        
        return await Task.FromResult(new List<Employee>());
    }

}
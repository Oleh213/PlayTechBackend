using Microsoft.Extensions.DependencyInjection;
using PlayTech.Repositories.Department;
using PlayTech.Repositories.Employee;

namespace PlayTech.Repositories;


public static class RepositoriesServiceCollectionExtensions
{
    public static void AddRepositoryInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}

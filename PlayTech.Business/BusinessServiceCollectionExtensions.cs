using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PlayTech.Business.Mappers.EntityToModel;

namespace PlayTech.Business;

public static class BusinessServiceCollectionExtensions
{
    public static void AddBusiness(this IServiceCollection services)
    {
        var profileAssembly = typeof(DepartmentToDepartmentModelMappingProfile).Assembly;
        services.AddAutoMapper(profileAssembly);
    }
}

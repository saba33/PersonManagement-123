using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Data;
using PersonManagement.Data.EF;
using PersonManagement.Data.EF.Repository;

namespace PersonManagement.Web.Infrastracture.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}

using Firebase.Database;
using Microsoft.Extensions.DependencyInjection;
using StudyProject.Application.Common.Interfaces;

namespace StudyProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            var client = new FirebaseClient("https://wikiforum-6f73d-default-rtdb.firebaseio.com/");

            services.AddScoped<IDatabaseContext, FirebaseContext>(s => new FirebaseContext(client));
        }
    }
}

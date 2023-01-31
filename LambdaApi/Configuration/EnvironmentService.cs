using LambdaApi.Services;

namespace LambdaApi.Configuration
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService() {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? "Production";
        }
        public string EnvironmentName { get; set; }
    }
}

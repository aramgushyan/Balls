using Microsoft.Extensions.DependencyInjection;

namespace Ball
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection()
                .AddTransient<IMoveable, MoveBall>()
                .AddTransient<Form1>(); 

            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
    }
}

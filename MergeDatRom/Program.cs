using MergeDatRom.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MergeDatRom
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();
            Application.Run(Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<Main>(serviceProvider));
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LoggingService>();
            services.AddSingleton<DatMetadataService>();
            services.AddTransient<Main>();
        }
    }
}
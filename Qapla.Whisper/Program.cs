using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Qapla.Whisper;

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

        // Configure and build your settings here
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
#if DEBUG
            .AddUserSecrets(Assembly.GetExecutingAssembly()) // Load secrets based on the executing assembly
#endif
            .Build();

        Application.Run(new Whisper(configuration));
    }
}

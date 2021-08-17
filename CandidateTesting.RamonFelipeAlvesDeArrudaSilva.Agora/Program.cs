using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.FormatLog;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.Persistance;
using CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora.RestRequest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CandidateTesting.RamonFelipeAlvesDeArrudaSilva.Agora
{
    class Program
    {
        private static readonly IServiceCollection serviceCollection = new ServiceCollection();
        private static ServiceProvider serviceProvider;
        private static ILogFormat logFormat;
        private static IFilePersistance filePersistance;
        private static IHttpRequest httpRequest;
        static void Main(string[] args)
        {
            if (!AreArgsValid(args))
                return;

            ConfigureServices(serviceCollection);

            var sourceUrl = args[0];
            var targetPath= args[1];

            MainAsync(sourceUrl, targetPath).Wait();

            Console.ReadKey();
        }

        static async Task MainAsync(string sourceUrl, string targetPath)
        {
            var processedLog = await logFormat.FormatLog(sourceUrl);
            filePersistance.SaveFile(processedLog, targetPath);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFilePersistance, FilePersistance>()
                    .AddScoped<IHttpRequest, HttpRequest>()
                    .AddScoped<ILogFormat, LogFormat>()
                    .AddHttpClient();

            serviceProvider = serviceCollection.BuildServiceProvider();
            logFormat = serviceProvider.GetService<ILogFormat>();
            filePersistance = serviceProvider.GetService<IFilePersistance>();
            httpRequest = serviceProvider.GetService<IHttpRequest>();
        }

        private static bool AreArgsValid(string[] args)
        {
            try
            {
                Console.WriteLine(args[0]);
                if (args.Length != 2)
                {

                    Console.WriteLine("You need to pass two parameters (sourceUrl and targePath).");
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                throw new Exception($"Error validating args.\n{e.Message}");
            }
        }
    }
}


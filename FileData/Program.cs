using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using ThirdPartyTools;
using ThirdPartyTools.Model;
using ThirdPartyTools.Service;

namespace FileData
{
    public static class Program
    {
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => 
                    services.AddSingleton<IArgumentsRepository, ArgumentsRepository>()
                    .AddSingleton<IFileDetails, FileDetails>()
                    .AddSingleton<IHandler,Handler>())
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });

        public static void Main(string[] args)
        {
            ILogger logger;
            using (ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {
                logger = loggerFactory.CreateLogger("");
            } 
            try
            {
                using (IHost host = CreateHostBuilder(args).Build())
                {
                    IHandler handler = host.Services.GetRequiredService<IHandler>();
                    var response = handler.GetResponse(args);
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, "Error in DI configuration");
            }
            Console.ReadKey();
        }
        
    }
}

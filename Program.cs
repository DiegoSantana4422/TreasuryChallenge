using System;
using System.Diagnostics;
using TreasuryChallenge.Model;
using Microsoft.Extensions.DependencyInjection;
using TreasuryChallenge.Contracts.Services;
using TreasuryChallenge.Services;

namespace TreasuryChallenge
{
    class Program
    {
       static void Main(string[] args)
        {
            Console.WriteLine("Tell me the number of lines do you need and press enter.");
            int numberLines = int.Parse(Console.ReadLine());

            Console.WriteLine("Tell me the name of file and press enter.");
            string nameFile = Console.ReadLine();

            var stopwatch = Stopwatch.StartNew();

            var templateFile = new TemplateFile
            {
                NameFile = nameFile,
                NumberLines = numberLines
            };

            CallMarketingCampaignService(templateFile);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMarketingCampaignService, MarketingCampaignService>();
        }      

        private static void CallMarketingCampaignService(TemplateFile templateFile)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var eventService = serviceProvider.GetService<IMarketingCampaignService>();

            try
            {
                eventService.CreateCodeFile(templateFile);
                Console.WriteLine($"The file {templateFile.NameFile} with {templateFile.NumberLines} lines was generated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error to generete File: {ex.Message}");
            }
        }
    }
}


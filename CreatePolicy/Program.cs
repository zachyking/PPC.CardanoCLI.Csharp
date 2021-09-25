using CreatePolicy.Interfaces;
using CreatePolicy.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CreatePolicy
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var policyService = serviceProvider.GetService<IPolicyService>();

            Console.WriteLine("---------Create Policy---------");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter policy name:");
            var policyName = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter your signing key path:");
            var signingKeyPath = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter your verification key path:");
            var verifKeyPath = Console.ReadLine();
            Console.WriteLine("Enter number, how many minutes policy will be valid for (leave empty if no time lock)");
            var minutes = Console.ReadLine();

            int minInt;

            //if timelocked policy
            if(!string.IsNullOrEmpty(minutes) && int.TryParse(minutes, out minInt)) Console.WriteLine(policyService.CreatePolicy(signingKeyPath, verifKeyPath, policyName, minInt));
            else
            {
                Console.WriteLine(policyService.CreatePolicy(signingKeyPath, verifKeyPath, policyName));
            }

            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .AddSingleton<IPolicyService, PolicyService>();
        }
    }
}

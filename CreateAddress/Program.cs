using CreateAddress.Interfaces;
using CreateAddress.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CreateAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var addresService = serviceProvider.GetService<IAddressService>();

            Console.WriteLine("---------Create Address---------");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter verification-key output path:");
            var verifKeyPath = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter signing-key output path:");
            var signingKeyPath = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(addresService.CreateAddress(signingKeyPath, verifKeyPath));
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .AddSingleton<IAddressService, AddressService>();
        }
    }
}

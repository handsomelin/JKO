using System;
using Data;
using Microsoft.Extensions.DependencyInjection;

namespace Request
{
    public class CommandLine
    {
        public CommandLine()
        {
            
        }
        public void Start()
        {
            var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            serviceCollection.AddSingleton<Request>();
            string input = "";
            while (input != "Quit")
            {
                Console.Write("# ");
                input = Console.ReadLine();
                Parameters parameters = new Parameters(input);
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please type Something");
                    continue;
                }
                string command = parameters.GetParameter(0);
                if (command == "REGISTER")
                {
                    serviceCollection.AddSingleton<IRequest, Register>();
                }
                else if (command == "CREATE_LISTING")
                {
                    serviceCollection.AddSingleton<IRequest, CreateListing>();
                }
                else if (command == "DELETE_LISTING")
                {
                    serviceCollection.AddSingleton<IRequest, DeleteListing>();
                }
                else if (command == "GET_LISTING")
                {
                    serviceCollection.AddSingleton<IRequest, GetListing>();
                }
                else if (command == "GET_CATEGORY")
                {
                    serviceCollection.AddSingleton<IRequest, GetCategory>();
                }
                else if (command == "GET_TOP_CATEGORY")
                {
                    serviceCollection.AddSingleton<IRequest, GetTopCategory>();
                }
                else
                {
                    serviceCollection.AddSingleton<IRequest, Invalid>();
                }
                var serviceProvider = serviceCollection.BuildServiceProvider();
                serviceProvider.GetRequiredService<Request>().Main(parameters);
            }
        }
    }
}

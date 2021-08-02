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
            IRequest request;
            //var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            //serviceCollection.AddSingleton<Request>();
            string input = "";
            while (input != null && input != "Quit")
            {
                Console.Write("# ");
                input = Console.ReadLine();
                if(input == null || input == "Quit")
                {
                    break;
                }
                Parameters parameters = new Parameters(input);
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please type Something");
                    continue;
                }
                string command = parameters.GetParameter(0);
                if (command == "REGISTER")
                {
                    //serviceCollection.AddSingleton<IRequest, Register>();
                    request = Actions.register;
                }
                else if (command == "CREATE_LISTING")
                {
                    //serviceCollection.AddSingleton<IRequest, CreateListing>();
                    request = Actions.createListing;
                }
                else if (command == "DELETE_LISTING")
                {
                    //serviceCollection.AddSingleton<IRequest, DeleteListing>();
                    request = Actions.deleteListing;
                }
                else if (command == "GET_LISTING")
                {
                    //serviceCollection.AddSingleton<IRequest, GetListing>();
                    request = Actions.getListing;
                }
                else if (command == "GET_CATEGORY")
                {
                    //serviceCollection.AddSingleton<IRequest, GetCategory>();
                    request = Actions.getCategory;
                }
                else if (command == "GET_TOP_CATEGORY")
                {
                    //serviceCollection.AddSingleton<IRequest, GetTopCategory>();
                    request = Actions.getTopCategory;
                }
                else
                {
                    //serviceCollection.AddSingleton<IRequest, Invalid>();
                    request = Actions.invalid;
                }
                //var serviceProvider = serviceCollection.BuildServiceProvider();
                //serviceProvider.GetRequiredService<Request>().Main(parameters);
                request.Execute(parameters);
            }
        }
    }
}

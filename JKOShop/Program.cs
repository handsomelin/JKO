using System;
using System.Linq;
using Data;
using System.Collections.Generic;
using Request;

namespace JKOShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            CommandLine commandLine = new CommandLine();
            commandLine.Start();
            Console.WriteLine("Bye!");
        }
    }
}

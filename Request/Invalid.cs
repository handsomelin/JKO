using System;
using Data;
namespace Request
{
    public class Invalid : IRequest
    {
        public Invalid()
        {
        }
        
        public bool CheckParameters(Parameters parameters)
        {
            string name = parameters.GetParameter(0);
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
        public bool Execute(Parameters parameters)
        {
            Console.WriteLine("Invalid action");
            return false;
        }
    }
}

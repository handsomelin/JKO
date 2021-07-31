using System;
using Data;

namespace Request
{
    public class Register : IRequest
    {
        public Register()
        {
        }
        public bool CheckParameters(Parameters parameters)
        {
            string name = parameters.GetParameter(1);
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
        public bool Execute(Parameters parameters)
        {
            if (!CheckParameters(parameters))
            {
                return false;
            }
            string name = parameters.GetParameter(1).ToLower();
            return Database.userList.Register(name);
        }
    }
}

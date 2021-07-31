using System;
using Data;
namespace Request
{
    public class GetTopCategory : IRequest
    {
        public GetTopCategory()
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
            User user = Database.userList.GetUser(name);
            if (user == null)
            {
                return false;
            }
            if (Database.categoryList.GetTopCategory() == null)
            {
                return false;
            }
            return true;
        }
    }
}

using System;
using Data;
namespace Request
{
    public class GetListing : IRequest
    {
        public GetListing()
        {
        }
        public bool CheckParameters(Parameters parameters)
        {
            string name = parameters.GetParameter(1);
            string id = parameters.GetParameter(2);
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Wrong format");
                return false;
            }
            try
            {
                int listingID = Convert.ToInt32(id);
            }
            catch
            {
                Console.WriteLine("ID wrong format");
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
            int id = Convert.ToInt32(parameters.GetParameter(2));
            Listing listing = Database.listingList.GetListing(id);
            if(listing == null)
            {
                return false;
            }
            return true;
        }
    }
}

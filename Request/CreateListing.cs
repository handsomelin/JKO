using System;
using Data;
namespace Request
{
    public class CreateListing : IRequest
    {
        public CreateListing()
        {
        }
        public bool CheckParameters(Parameters parameters)
        {
            string name = parameters.GetParameter(1);
            string title = parameters.GetParameter(2);
            string description = parameters.GetParameter(3);
            string price = parameters.GetParameter(4);
            string category = parameters.GetParameter(5);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Wrong format");
                return false;
            }
            try
            {
                int p = Convert.ToInt32(price);
            }
            catch
            {
                Console.WriteLine("Price wrong format");
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
            string title = parameters.GetParameter(2);
            string description = parameters.GetParameter(3);
            string p = parameters.GetParameter(4);
            string c = parameters.GetParameter(5);
            int price = Convert.ToInt32(p);
            User user = Database.userList.GetUser(name);
            if (user == null)
            {
                return false;
            }
            Category category = Database.categoryList.GetCategory(c);
            if(category == null)
            {
                category = new Category(c);
            }
            Listing listing = Database.listingList.CreateListing(user, title, description, price, category);
            if (listing == null)
            {
                return false;
            }
            
            return Database.categoryList.AddListings(category, listing);
        }
    }
}

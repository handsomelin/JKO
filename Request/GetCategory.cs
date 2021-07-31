using System;
using Data;
using System.Collections.Generic;

namespace Request
{
    public class GetCategory : IRequest
    {
        public GetCategory()
        {
        }
        public bool CheckParameters(Parameters parameters)
        {
            string name = parameters.GetParameter(1);
            string category = parameters.GetParameter(2);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Wrong format");
                return false;
            }
            return true;
        }
        public bool Execute(Parameters parameters)
        {
            string name = parameters.GetParameter(1).ToLower();
            User user = Database.userList.GetUser(name);
            if (user == null)
            {
                return false;
            }
            string c = parameters.GetParameter(2);
            Category category = Database.categoryList.GetCategory(c);
            if(category == null)
            {
                return false;
            }
            List<Listing> listings = Database.categoryList.GetCategoryListings(category);
            if (listings == null)
            {
                return false;
            }
            string sort_type = parameters.GetEmptyParameter(3);
            string sort_order = parameters.GetEmptyParameter(4);
            SortedCategory sortedCategory = new SortedCategory(sort_type, sort_order, listings);
            sortedCategory.print();
            return true;
        }
    }
}

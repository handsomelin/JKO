using System;
using System.Collections.Generic;

namespace Data
{
    public class CategoryList
    {
        Dictionary<Category, List<Listing>> listings;
        List<Category> topCategory;
        public CategoryList()
        {
            this.listings = new Dictionary<Category, List<Listing>>();
            this.topCategory = new List<Category>();
        }

        public Category GetCategory(string str)
        {
            foreach(Category category in listings.Keys)
            {
                if(category.Name == str)
                {
                    return category;
                }
            }
            return null;
        }
        public List<Listing> GetCategoryListings(Category category)
        {
            if (!listings.ContainsKey(category))
            {
                Console.WriteLine("Error - category not found");
                return null;
            }
            if(listings[category].Count == 0)
            {
                Console.WriteLine("Error - category has no listings");
                return null;
            }
            return listings[category];
        }
        public List<Category> GetTopCategory()
        {
            if (topCategory == null || topCategory.Count == 0)
            {
                Console.WriteLine("No Top Category");
                return null;
            }
            foreach(Category category in topCategory)
            {
                category.Print();
            }
            return topCategory;
        }
        public bool AddListings(Category category, Listing listing)
        {
            if (!listings.ContainsKey(category))
            {
                List<Listing> new_listing = new List<Listing>();
                new_listing.Add(listing);
                listings.Add(category, new_listing);
                Refresh();
                return true;
            }
            if (listings[category].Contains(listing))//////////////affect efficiency?
            {
                Console.WriteLine("Already Exist");
                return false;
            }
            listings[category].Add(listing);
            Refresh();
            return true;
        }
        public bool RemoveListings(Category category, Listing listing)
        {
            if (!listings.ContainsKey(category))
            {
                Console.WriteLine("No Category");
                return false;
            }
            if (!listings[category].Remove(listing))//////////////affect efficiency?
            {
                Console.WriteLine("Listing Not Exist");
                return false;
            }
            Refresh();
            return true;
        }
        public void Refresh()
        {
            int max = 1;
            topCategory.Clear();
            foreach(Category category in listings.Keys)
            {
                int n = listings[category].Count;
                if(n > max)
                {
                    max = n;
                    topCategory.Clear();
                    topCategory.Add(category);
                    continue;
                }
                if(n == max)
                {
                    topCategory.Add(category);
                }
            }
        }

        public void Print()
        {
            foreach(Category category in listings.Keys)
            {
                Console.WriteLine(category.Name + ": ");
                foreach(Listing listing in listings[category])
                {
                    listing.Print();
                }
            }
        }
    }
}

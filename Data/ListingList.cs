using System;
using System.Collections.Generic;

namespace Data
{
    public class ListingList
    {
        List<Listing> listings;
        public ListingList()
        {
            this.listings = new List<Listing>();
        }
        public Listing CreateListing(User user, string title, string description, int price, Category category)
        {
            Listing listing = new Listing(title, description, price, user, category);
            listings.Add(listing);
            Console.WriteLine(listing.ID);
            return listing;
        }
        public Listing DeleteListing(User user, int id)
        {
            int index = id - Constant.seed;
            if (index < 0 || index >= listings.Count)
            {
                Console.WriteLine("Error - listing does not exist");
                return null;
            }
            else if (listings[index].Deleted)
            {
                Console.WriteLine("Error - listing does not exist");
                return null;
            }
            else if (listings[index].Listing_user.Name != user.Name)
            {
                Console.WriteLine("Error - listing owner mismatch");
                return null;
            }
            listings[index].Deleted = true;
            Console.WriteLine("Success");
            return listings[index];
        }
        public Listing GetListing(int id)
        {
            int index = id - Constant.seed;
            if(index < 0 || index >= listings.Count)
            {
                Console.WriteLine("Error - not found");
                return null;
            }
            if (listings[index].Deleted)
            {
                Console.WriteLine("Error - not found");
                return null;
            }
            listings[index].Print();
            return listings[index];
        }
    }
}

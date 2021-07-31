using System;
using System.Collections.Generic;

namespace Data
{
    public class Category
    {
        private string name;
        private List<Listing> listings;

        public Category()
        {
            this.name = "";
            this.listings = new List<Listing>();
        }
        public Category(string str)
        {
            this.name = str;
            this.listings = new List<Listing>();
        }
        public Category(string str, Listing listing)
        {
            this.name = str;
            this.listings = new List<Listing>();
            listings.Add(listing);
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Listing> Listings
        {
            get
            {
                return listings;
            }
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            string str = ((Category)obj).name;
            return this.name.Equals(str);
        }
        public void Print()
        {
            Console.WriteLine(name);
        }
        public bool AddListing(Listing listing)
        {
            if (listings.Contains(listing))
            {
                Console.WriteLine("Already Exist");
                return false;
            }
            listings.Add(listing);
            return true;
        }
        public bool RemoveListing(Listing listing)
        {
            if (!listings.Remove(listing))
            {
                Console.WriteLine("Listing Not Exist");
                return false;
            }
            return true;
        }

    }
}

using System;
namespace Data
{
    public class Listing
    {
        private int id;
        private int seed = Constant.seed;
        private static int count = 0;
        private string title;
        private string description;
        private int price;
        private DateTime created_at;
        private Category listingCategory;
        private User listingUser;
        private bool deleted;
        public Listing()
        {
            this.id = seed+count;
            count++;
            this.title = "";
            this.description = "";
            this.price = 0;
            this.created_at = DateTime.Now;
            this.listingCategory = new Category();
            this.listingUser = new User();
            this.deleted = false;
        }
        public Listing(string t, string d, int p, User u, Category category)
        {
            this.id = seed+count;
            count++;
            this.title = t;
            this.description = d;
            this.price = p;
            this.created_at = DateTime.Now;
            this.listingCategory = category;
            this.listingUser = u;
            this.deleted = false;
        }
        public int ID
        {
            get { return id; }
        }
        public int Seed
        {
            get { return seed; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public DateTime Created_at
        {
            get { return created_at; }
        }
        public Category ListingCategory
        {
            get { return listingCategory; }
        }
        public User Listing_user
        {
            get { return listingUser; }
        }
        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
        public override bool Equals(object obj)
        {
            int n = ((Listing)obj).id;
            return this.id.Equals(n);
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
        public void Print()
        {
            Console.WriteLine($"{title}|{description}|{price}|{created_at}|{listingCategory.Name}|{listingUser.Name}");
        }
        public void print2()
        {
            Console.WriteLine($"{id}|{title}|{description}|{price}|{created_at}");
        }
        public override string ToString()
        {
            return ($"{title}|{description}|{price}|{created_at}|{listingCategory.Name}|{listingUser.Name}");
        }
    }
}

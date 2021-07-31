using System;
using System.Linq;
using System.Collections.Generic;

namespace Data
{
    public class SortedCategory
    {
        IEnumerable<Listing> sortedListings;
        bool asc;
        public SortedCategory()
        {
            asc = true;
        }
        public SortedCategory(string sort_type, string sort_order, List<Listing> listings)
        {
            asc = true;
            if (sort_type == "sort_time")///////若照時間排序預設為dsc
            {
                asc = false;
            }
            if (sort_order == "dsc")
            {
                asc = false;
            }
            if (sort_order == "asc")
            {
                asc = true;
            }
            if (sort_type == "sort_price")
            {
                if (asc)
                {
                    this.sortedListings =
                        from listing in listings
                        orderby listing.Price ascending
                        select listing;
                }
                else
                {
                    this.sortedListings =
                        from listing in listings
                        orderby listing.Price descending
                        select listing;
                }
            }
            else 
            {
                if (asc)
                {
                    this.sortedListings =
                        from listing in listings
                        orderby listing.Created_at ascending
                        select listing;
                }
                else
                {
                    this.sortedListings =
                        from listing in listings
                        orderby listing.Created_at descending
                        select listing;
                }
            }
        }
        
        public void print()
        {
            foreach (Listing listing in sortedListings)
            {
                listing.Print();
            }
        }
    }
}

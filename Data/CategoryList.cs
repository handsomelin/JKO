using System;
using System.Collections.Generic;

namespace Data
{
    public class CategoryList
    {
        HashSet<Category> categories;
        List<Category> topCategory;
        public CategoryList()
        {
            this.categories = new HashSet<Category>();
            this.topCategory = new List<Category>();
        }

        public Category GetCategory(string str)
        {
            Category category = new Category(str);
            if (categories.TryGetValue(category, out category))
            {
                return category;
            }
            Console.WriteLine("Error - category not found");
            return null;
        }
        public Category GetCategory(string str, bool createListing)
        {
            Category category = new Category(str);
            if (categories.TryGetValue(category, out category))
            {
                return category;
            }
            if (createListing)
            {
                return null;
            }
            Console.WriteLine("Error - category not found");
            return null;
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

        public Category Register(string str)
        {
            Category category = new Category(str);
            if (categories.Add(category))
            {
                return category;
            }
            Console.WriteLine("Cannot register category");
            return category;
        }

        public void Refresh(Category updatedCategory)
        {
            if(topCategory.Count != 0 && updatedCategory.Listings.Count < topCategory[0].Listings.Count)
            {
                if (!topCategory.Contains(updatedCategory))
                {
                    return;
                }
            }
            int max = 1;
            topCategory.Clear();
            foreach(Category category in categories)
            {
                int n = category.Listings.Count;
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
            foreach(Category category in categories)
            {
                category.Print();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Data
{
    public class Category
    {
        private string name;

        public Category()
        {
            this.name = "";
        }
        public Category(string str)
        {
            this.name = str;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
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



    }
}

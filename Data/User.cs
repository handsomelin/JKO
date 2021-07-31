using System;

namespace Data
{
    public class User
    {
        private string name;

        public User()
        {
            this.name = "";
        }
        public User(string str)
        {
            this.name = str.ToLower();
        }
        public string Name
        {
            get { return name; }
            set { name = value.ToLower(); }
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            string str = ((User)obj).name;
            return this.name.Equals(str);
        }
        public void Print()
        {
            Console.WriteLine(name);
        }
    }
}

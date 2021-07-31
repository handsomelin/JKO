using System;
using System.Collections.Generic;

namespace Data
{
    public class Parameters
    {
        private List<string> parameter;

        public Parameters()
        {
            this.parameter = new List<string>();
        }
        public Parameters(string str)
        {
            this.parameter = new List<string>();
            string[] token = str.Split(' ');
            bool head = false;
            string part = "";
            string last = token[token.Length - 1];
            for(int i=0;i<token.Length;i++)
            {
                string s = token[i];
                if (head)
                {
                    part += " ";
                    part += s;
                    if (IsTail(s))
                    {
                        part = part.Remove(part.Length - 1);
                        parameter.Add(part);
                        head = false;
                        part = "";
                        continue;
                    }
                    continue;
                }
                if (IsHead(s))
                {
                    head = true;
                    part += s.Substring(1);
                    if(IsTail(s))
                    {
                        part = part.Remove(part.Length - 1);
                        parameter.Add(part);
                        head = false;
                        part = "";
                    }
                    continue;
                }
                parameter.Add(s);
            }
        }
        private bool IsHead(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            if(str[0] == '\'')
            {
                return true;
            }
            return false;
        }
        private bool IsTail(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            if (str[str.Length-1] == '\'')
            {
                return true;
            }
            return false;
        }
        public string GetParameter(int i)
        {
            if(i < 0 || i >= parameter.Count)
            {
                Console.WriteLine("Bug: out of range");
                return "";
            }
            if (string.IsNullOrEmpty(parameter[i]))
            {
                Console.WriteLine("Bug: No Parameter");
                return "";
            }
            return parameter[i];
        }
        public string GetEmptyParameter(int i)
        {
            if (i < 0 || i >= parameter.Count)
            {
                //Console.WriteLine("Bug: out of rabge");
                return "";
            }
            return parameter[i];
        }

        public void Print()
        {
            foreach(string s in parameter)
            {
                Console.Write($"{s}|");
            }
            Console.WriteLine("");
        }
        
    }
}

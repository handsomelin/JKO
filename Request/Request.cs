using System;
using Data;
namespace Request
{
    public class Request
    {
        private readonly IRequest _Request;
        //private int hash;
        public Request(IRequest request)
        {
            _Request = request;
            //Random random = new Random();
            //hash = random.Next();
        }

        public void Main(Parameters parameters)
        {
            _Request.Execute(parameters);
        }
    }
}

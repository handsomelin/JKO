using System;
using Data;
namespace Request
{
    public interface IRequest
    {
        public bool Execute(Parameters parameters);
        public bool CheckParameters(Parameters parameters);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class CollegeException : Exception
    {
        public CollegeException(string message) : base(message)
        {
        }
    }
}

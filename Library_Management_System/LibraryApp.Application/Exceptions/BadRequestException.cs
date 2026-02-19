using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooApp.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string msg) : base(msg)
        {

        }
    }
}

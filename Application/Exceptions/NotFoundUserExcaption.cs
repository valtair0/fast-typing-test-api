using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NotFoundUserExcaption : Exception
    {
        public NotFoundUserExcaption() : base("Username or password incorrect")
        {
        }

        public NotFoundUserExcaption(string? message) : base(message)
        {
        }

        public NotFoundUserExcaption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

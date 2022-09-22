using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment.Exceptions
{
    internal class AlreadyUsedUsernameException : Exception
    {
        public AlreadyUsedUsernameException() : base("The Username is already used")
        { }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_assignment.Exceptions
{
    internal class IncorrectInformationException : Exception
    {
        public IncorrectInformationException() : base("Incorrect information")
        { }
    }
}

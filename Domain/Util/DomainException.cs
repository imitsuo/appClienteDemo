
using System;
using System.Collections.Generic;

namespace clientprj.Domain.Util
{
    public class DomainException : Exception
    {
        public List<string> Errors {get; set;}

        public DomainException()
        {
            Errors = new List<string>();
        }
    }
}
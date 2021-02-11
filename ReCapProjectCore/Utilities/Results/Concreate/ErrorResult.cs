using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Results.Concreate
{
    public class ErrorResult : Result
    {
        public ErrorResult(string messages) : base(false, messages)
        {
        }

        public ErrorResult() : base(false)
        { 
        
        }
    }
}

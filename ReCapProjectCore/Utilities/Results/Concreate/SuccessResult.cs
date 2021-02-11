using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Results.Concreate
{
    public class SuccessResult : Result
    {
        public SuccessResult(string messages) : base(true, messages)
        {
        }
        public SuccessResult() : base(true)
        { 

        }
    }
}

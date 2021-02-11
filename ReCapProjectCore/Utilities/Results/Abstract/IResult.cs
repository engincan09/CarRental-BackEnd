using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Results.Abstract
{
    public interface IResult
    {
         bool Success { get; }
         string Messages { get; }
    }
}

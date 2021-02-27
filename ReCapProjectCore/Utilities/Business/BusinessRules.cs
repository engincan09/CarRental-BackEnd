using ReCapProjectCore.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectCore.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult  Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}

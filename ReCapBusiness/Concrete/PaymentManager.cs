using ReCapProjectBusiness.Abstract;
using ReCapProjectBusiness.Constants;
using ReCapProjectCore.Utilities.Results.Abstract;
using ReCapProjectCore.Utilities.Results.Concrete;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult Pay(Payment payment)
        {
            if (payment.Amount > 5000)
            {
                return new ErrorResult(Messages.InsufficientBalance);
            }
            return new SuccessResult(Messages.PaymentCompleted);
        }
    }
}

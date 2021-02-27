using FluentValidation;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p=> p.CompanyName).NotEmpty();
            RuleFor(p=> p.UserId).NotEmpty();
        }
    }
}

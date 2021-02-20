using FluentValidation;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p=> p.Name).NotEmpty();
        }
    }
}

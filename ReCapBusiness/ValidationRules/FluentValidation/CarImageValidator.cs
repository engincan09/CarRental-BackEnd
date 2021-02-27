using FluentValidation;
using FluentValidation.Results;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p=> p.CarId).NotEmpty();
            
        }
    }
}

using FluentValidation;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p=> p.Name).NotEmpty();
        }
    }
}

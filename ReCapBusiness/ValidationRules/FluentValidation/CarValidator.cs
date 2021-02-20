﻿using FluentValidation;
using ReCapProjectEntities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();

            RuleFor(p => p.ModelYear).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThan(0);

        }
    }
}

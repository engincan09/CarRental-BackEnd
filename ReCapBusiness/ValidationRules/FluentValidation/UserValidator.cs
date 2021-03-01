using FluentValidation;
using ReCapProjectCore.Entities.Concrete;
using ReCapProjectEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectBusiness.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p=>p.Email).NotEmpty();
            RuleFor(p=> p.FirstName).NotEmpty();
            RuleFor(p=> p.LastName).NotEmpty();

        }
    }
}

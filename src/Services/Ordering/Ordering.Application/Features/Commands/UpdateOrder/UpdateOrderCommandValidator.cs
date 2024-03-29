﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.UpdateOrder
{
    internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.UserName)
              .NotEmpty().WithMessage("{UserName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{UserName} must ont exceed 50 characters.");

            RuleFor(x => x.EmailAddress)
               .NotEmpty().WithMessage("{EmailAdress} is required");

            RuleFor(x => x.TotalPrice)
               .NotEmpty().WithMessage("{TotalPrice} is required")
               .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero");
        }
    }
}

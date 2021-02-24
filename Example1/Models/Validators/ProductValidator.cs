using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Example1.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Daxil Edimelidir.");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Daxil edilen email formasi duzgun deyil.");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Daxil Edimelidir.");
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Daxil Edile biler.");
        }
    }
}

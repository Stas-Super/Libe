using FluentValidation;
using Libe.AccountMicroservice.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.ApiServices.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            this.RuleFor(r => r.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}

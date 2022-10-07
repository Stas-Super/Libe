using FluentValidation;
using Libe.AccountMicroservice.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libe.AccountMicroservice.ApiServices.Validators
{
    public class LogInValidator : AbstractValidator<LogInDto>
    {
        public LogInValidator()
        {
            this.RuleFor(e => e.Email)
                 .EmailAddress()
                 .NotEmpty();
            this.RuleFor(e => e.Password)
                .NotEmpty();
        }

        public static LogInValidator Create()
        {
            return new LogInValidator();
        }
    }
}

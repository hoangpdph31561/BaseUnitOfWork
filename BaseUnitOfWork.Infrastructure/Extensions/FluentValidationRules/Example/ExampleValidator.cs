using BaseUnitOfWork.Application.DataTransferObjects.Example.Requests;
using BaseUnitOfWork.Application.ValueObjects.Common;
using BaseUnitOfWork.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUnitOfWork.Infrastructure.Extensions.FluentValidationRules.Example
{
    public class ExampleValidator : AbstractValidator<ExampleEntity>
    {
        public ExampleValidator()
        {
            RuleFor(x => x.Name)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);

            //        RuleFor(x => x.FirstName)
            //        .Cascade(CascadeMode.Stop)
            //        .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
            //        RuleFor(x => x.LastName)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
            //        RuleFor(x => x.Email)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField)
            //            .EmailAddress().WithMessage(LocalizationString.Validator.EmailIncorrectFormat);
            //        RuleFor(x => x.PhoneNumber)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
            //        RuleFor(x => x.UDID)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
            //        RuleFor(x => x.OS)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
            //        RuleFor(x => x.OSVersion)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
            //        RuleFor(x => x.DeviceName)
            //            .Cascade(CascadeMode.Stop)
            //            .NotEmpty().WithMessage(LocalizationString.Common.EmptyField);
        }
    }
}

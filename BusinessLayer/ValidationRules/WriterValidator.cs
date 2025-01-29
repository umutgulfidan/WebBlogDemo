using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez.").WithErrorCode("CE-{PropertyName}-NotEmpty");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez").WithErrorCode("CE-{PropertyName}-NotEmpty");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez").WithErrorCode("CE-{PropertyName}-NotEmpty");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakterden oluşmalı.").WithErrorCode("CE-{PropertyName}-MinimumLength");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı maksimum 50 karakterden oluşabilir.").WithErrorCode("CE-{PropertyName}-MaximumLength");

        }

    }
}

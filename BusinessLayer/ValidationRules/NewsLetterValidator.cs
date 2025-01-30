using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class NewsLetterValidator : AbstractValidator<NewsLetter>
    {
        public NewsLetterValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş olamaz.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Mail alanı doğru formatta değil.");
        }
    }
}

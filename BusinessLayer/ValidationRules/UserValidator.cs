using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(4).WithMessage("Kullanıcı adı minimum 4 karakterden oluşmalıdır");
            RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Kullanıcı adı maksimum 30 karakterden oluşabilir");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresi doğru formatta olmalıdır.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("İsim soyisim alanı boş geçilemez");
            RuleFor(x => x.NameSurname).MinimumLength(4).WithMessage("İsim soyisim alanı en az 4 karakterden oluşmalıdır");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("İsim soyisim alanı en fazla 50 karakterden oluşabilir");
        }
    }
}

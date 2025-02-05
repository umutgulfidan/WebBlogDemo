using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakterden oluşmalı.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı maksimum 50 karakterden oluşabilir.");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Yazar profil resmi boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında kısmı boş geçilemez.");

            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("Yazar şifresi 8 karakterden kısa olamaz");
            RuleFor(x => x.WriterPassword).Matches("[a-z]").WithMessage("Şifre küçük harf içermek zorundadır.");
            RuleFor(x => x.WriterPassword).Matches("[A-Z]").WithMessage("Şifre büyük harf içermek zorundadır.");
            RuleFor(x => x.WriterPassword).Matches("[0-9]").WithMessage("Şifre rakam içermek zorundadır.");
            RuleFor(x => x.WriterPassword).Matches($"[{Regex.Escape(SpecialCharacters)}]").WithMessage("Şifre bir adet özel karakter içermek zorundadır. (Özel Karakterler: "+SpecialCharacters+" )");

        }
        private const string SpecialCharacters = "!@#$%^&*(),.?\":{}|<>";

    }
}

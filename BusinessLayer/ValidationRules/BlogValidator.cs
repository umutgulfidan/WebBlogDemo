using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez");
            RuleFor(x=>x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez");
            RuleFor(x=>x.BlogImage).NotEmpty().WithMessage("Blog Resmi Boş Geçilemez");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog Kapak Resmi Boş Geçilemez");

            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog Başlığı 150 karakterden uzun olamaz.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog Başlığı 5 karakterden kısa olamaz.");
            RuleFor(x => x.BlogContent).MinimumLength(50).WithMessage("Blog İçeriği 50 karakterden kısa olamaz.");


        }
    }
}

using FluentValidation;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Validations
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
                                 .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
                                       .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL alanı boş geçilemez.")
                                     .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                                     .WithMessage("Geçerli bir resim URL'si giriniz.");
        }
    }
}

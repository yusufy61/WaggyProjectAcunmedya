using FluentValidation;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Validations
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum alanı boş geçilemez.")
                                                .MinimumLength(10).WithMessage("Yorum en az 50 karakter olmalıdır.")
                                                .MaximumLength(500).WithMessage("Yorum en fazla 200 karakter olabilir.");
        }
    }
}

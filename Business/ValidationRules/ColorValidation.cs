using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
   public class ColorValidation:AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("Color ismi boş geçilemez");
        }
    }
}

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).Length(2, 45);
            RuleFor(x => x.BrandName).NotEqual("Araba Markası");
            //RuleFor(x => x.BrandName).NotEqual(0).When(x => x.HasDiscount);
            //RuleFor(x => x.Address).Length(20, 250);
            RuleFor(x => x.BrandName).Must(StartWithA).WithMessage("Please specify a valid postcode");
        }

        private bool StartWithA(string args)
        {
            return args.StartsWith("A");
        }
    }
}


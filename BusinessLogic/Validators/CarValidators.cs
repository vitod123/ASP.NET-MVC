using DataAccess.Entites;
using FluentValidation;

namespace WebApplication1.Validators
{
    public class CarValidators : AbstractValidator<Car>
    {
        public CarValidators()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(c => c.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("Value {PropertyValue} is incorrect.");

            RuleFor(c => c.Km)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("Value {PropertyValue} is incorrect.");

            RuleFor(c => c.City)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);


            RuleFor(c => c.ImagePath)
                .Must(LinkMustBeAUri).WithMessage("Incorrect URL. Try again!!!");

        }

        private static bool LinkMustBeAUri(string? link)
        {
            if(string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }


    }
}

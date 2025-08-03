using FluentValidation;
using itransition_task5_server.DTOs;

namespace itransition_task5_server.Validators
{
    public class BookRequestDtoValidator : AbstractValidator<BookRequestDto>
    {
        private static readonly string[] SupportedLocales = { "en", "es", "de" };

        public BookRequestDtoValidator()
        {
            RuleFor(x => x.Locale)
                .NotEmpty().WithMessage("Locale is required.")
                .Must(x => SupportedLocales.Contains(x, StringComparer.OrdinalIgnoreCase))
                .WithMessage($"Locale must be one of: {string.Join(", ", SupportedLocales)}.");
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(0).WithMessage("Page cannot be negative.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 1000)
                .WithMessage("PageSize must be between 1 and 1000.");

            RuleFor(x => x.Seed)
                .GreaterThanOrEqualTo(0).WithMessage("Seed cannot be negative.")
                .LessThanOrEqualTo(int.MaxValue)
                .WithMessage($"Seed cannot be greater than {int.MaxValue}.");

            RuleFor(x => x.AvgLikes)
                .InclusiveBetween(0.0, 100.0)
                .WithMessage("Average likes must be between 0.0 and 100.0.");

            RuleFor(x => x.AvgReviews)
                .InclusiveBetween(0.0, 10.0)
                .WithMessage("Average reviews must be between 0.0 and 10.0.");
        }
    }
}

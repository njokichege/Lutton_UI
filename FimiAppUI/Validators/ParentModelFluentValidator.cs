namespace FimiAppUI.Validators
{
    public class ParentModelFluentValidator : AbstractValidator<ParentModel>
    {
        [Inject] public IParentService ParentService { get; set; }
        public ParentModelFluentValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required")
                .Length(1, 100).WithMessage("'{PropertyName}' has exceeded the maximum length")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters");
            RuleFor(x => x.MiddleName)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required")
                .Length(1, 100).WithMessage("'{PropertyName}' has exceeded the maximum length")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required")
                .Length(1, 100).WithMessage("'{PropertyName}' has exceeded the maximum length")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters");
            RuleFor(x => x.NationalId)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required.")
                .MinimumLength(10).WithMessage("'{PropertyName}' must not be less than 10 characters.")
                .MaximumLength(11).WithMessage("'{PropertyName}' must not exceed 50 characters.");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ParentModel>.CreateWithOptions((ParentModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
namespace FimiAppUI.Validators
{
    public class StaffModelFluentValidator : AbstractValidator<StaffModel>
    {
        [Inject] public IStaffService StaffService { get; set; }
        public StaffModelFluentValidator()
        {
            RuleFor(x => x.NationalId)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required");
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
            RuleFor(x => x.Designation)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required")
                .Length(1, 100).WithMessage("'{PropertyName}' has exceeded the maximum length")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters");
            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required");
            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .LessThan(p => DateTime.Now).WithMessage("'{PropertyName}' should be less cannot be today");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<StaffModel>.CreateWithOptions((StaffModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}

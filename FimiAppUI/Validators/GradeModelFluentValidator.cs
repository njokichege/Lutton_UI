namespace FimiAppUI.Validators
{
    public class GradeModelFluentValidator : AbstractValidator<GradeModel>
    {
        [Inject] IGradeService GradeService { get; set; }
        public GradeModelFluentValidator()
        {
            RuleFor(x => x.Grade)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required")
                .Matches("[A-Z]").WithMessage("'{PropertyName}' should be a capital letter")
                .MaximumLength(1).WithMessage("'{PropertyName}' has exceeded the maximum length")
                .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters");
            RuleFor(x => x.StartGrade)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .LessThanOrEqualTo(100.00).WithMessage("'{PropertyName}' must be less than or equal to 100")
                .GreaterThanOrEqualTo(0.00).WithMessage("'{PropertyName}' must be greater than or equal to 0")
                .NotNull().WithMessage("'{PropertyName}' is required");
            RuleFor(x => x.EndGrade)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .LessThanOrEqualTo(100.00).WithMessage("'{PropertyName}' must be less than or equal to 100")
                .GreaterThanOrEqualTo(0.00).WithMessage("'{PropertyName}' must be greater than or equal to 0")
                .NotNull().WithMessage("'{PropertyName}' is required");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<GradeModel>.CreateWithOptions((GradeModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}

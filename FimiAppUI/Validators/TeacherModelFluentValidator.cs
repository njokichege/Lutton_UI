namespace FimiAppUI.Validators
{
    public class TeacherModelFluentValidator : AbstractValidator<TeacherModel>
    {
        [Inject] public ITeacherService TeacherService { get; set; }
        public TeacherModelFluentValidator()
        {
            RuleFor(x => x.TSCNumber)
                .NotEmpty().WithMessage("'{PropertyName}' is required")
                .NotNull().WithMessage("'{PropertyName}' is required");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<TeacherModel>.CreateWithOptions((TeacherModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}

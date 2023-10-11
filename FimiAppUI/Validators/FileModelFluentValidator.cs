namespace FimiAppUI.Validators
{
    public class FileModelFluentValidator : AbstractValidator<FileModel>
    {
        public FileModelFluentValidator()
        {
            RuleFor(x => x.File.ContentType).NotNull().Must(x => x.Equals("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")) 
                .WithMessage("File type is not allowed");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<FileModel>.CreateWithOptions((FileModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}


namespace FimiAppUI.Pages
{
    public class StudentModelFluentValidator : AbstractValidator<StudentModel>
    {
        [Inject] public IStudentService StudentService { get; set; }
        public StudentModelFluentValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(1, 200);

            RuleFor(x => x.MiddleName)
                .NotEmpty()
                .Length(1, 200);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .Length(1, 200);

            RuleFor(x => x.DateOfBirth)
                .NotEmpty();
        }
        private async Task<bool> IsUniqueAsync(int studentNumber)
        {
            var studentCheck = StudentService.GetStudentByStudentNumber(studentNumber);
            if(studentCheck != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<StudentModel>.CreateWithOptions((StudentModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
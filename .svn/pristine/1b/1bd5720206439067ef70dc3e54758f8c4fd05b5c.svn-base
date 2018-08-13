using CLAServer.Models;
using FluentValidation;

namespace CLAServer.Validators
{
    public class CourseViewModelValidator : AbstractValidator<ClassesViewModel>
    {
        public CourseViewModelValidator()
        {
            RuleFor(x => x.ClassName).NotEmpty();
        }
    }
}
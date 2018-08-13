using CLAServer.Models;
using FluentValidation;

namespace CLAServer.Validators
{
    public class SubjectsViewModelValidator : AbstractValidator<SubjectViewModel>
    {
        public SubjectsViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.ClassId).NotEmpty().NotEqual(0).WithMessage("Please select course");
        }
    }
}
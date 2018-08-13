using CLAServer.Models;
using FluentValidation;

namespace CLAServer.Validators
{
    public class FacultyViewModelValidator : AbstractValidator<FacultyViewModel>
    {
        public FacultyViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Designation).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
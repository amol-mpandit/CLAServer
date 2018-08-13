using CLAServer.Models;
using FluentValidation;

namespace CLAServer.Validators
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.RollNo).NotEmpty();
            RuleFor(x => x.Mobile).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.ClassId).NotEmpty().NotEqual(0).WithMessage("Please select Course");
        }
    }
}
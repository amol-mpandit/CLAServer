using CLAServer.Models;
using FluentValidation;

namespace CLAServer.Validators
{
    public class TimeTableViewModelValidator : AbstractValidator<TimeTableViewModel>
    {
        public TimeTableViewModelValidator()
        {
            RuleFor(x => x.ClassId).NotNull().NotEqual(0).WithMessage("Please select Class.");
            RuleFor(x => x.SubjectId).NotNull().NotEqual(0).WithMessage("Please select Subject.");
            RuleFor(x => x.FacultyId).NotNull().NotEqual(0).WithMessage("Please select Faculty.");
            RuleFor(x => x.StartTime).NotEmpty().NotNull().WithMessage("Please select date");
        }
    }
}
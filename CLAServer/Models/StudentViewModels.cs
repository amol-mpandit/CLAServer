using System.Collections.Generic;

namespace CLAServer.Models
{
    public class StudentsViewModel
    {
        public IEnumerable<StudentViewModel> Students { get; set; }
    }

    public class StudentViewModel
    {
        public int SId { get; set; }
        public int RollNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + MiddleName + " " + LastName; } }
        public string EnrollmentNo { get; set; }
        public long Mobile { get; set; }
        public long HomePhone { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public string ClassNameToDisplay { get; set; }
    }
}

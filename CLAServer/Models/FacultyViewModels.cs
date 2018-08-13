using System.Collections.Generic;

namespace CLAServer.Models
{
    public class FacultyViewModel
    {
        public int FId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Designation { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
    }

    public class FacultiesViewModels
    {
        public IEnumerable<FacultyViewModel> Faculties { get; set; }
}
}

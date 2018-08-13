using System.Collections.Generic;
using System.Web.Mvc;
using Core;

namespace CLAServer.Models
{
    public class SubjectViewModel
    {
        public int SubId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ClassId { get; set; }
        public string ClassNameToDisplay { get; set; }
    }

    public class SubjectsViewModel
    {
        public IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}

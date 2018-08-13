using System.Collections.Generic;

namespace CLAServer.Models
{
    public class ClassesViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Division { get; set; }
    }

    public class ClassesViewModels
    {
        public IEnumerable<ClassesViewModel> Classes { get; set; }
    }
}

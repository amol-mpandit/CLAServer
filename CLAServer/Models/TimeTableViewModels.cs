using System;
using System.Collections.Generic;

namespace CLAServer.Models
{
    public class TimeTableViewModels
    {
        public IEnumerable<TimeTableViewModel> TimeTable { get; set; }
    }
    public class TimeTableViewModel
    {
        public int TimeTableId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartTime { get; set; }
        public string StartTimeToDisplay { get { return StartTime.ToString("ddd, dd MMM yyyy hh:mm tt"); } }
        public DateTime EndTime { get; set; }
        public string EndTimeToDisplay { get { return EndTime.ToString("ddd, dd MMM yyyy hh:mm tt"); } }
        public int DurationInMin { get; set; }
        public bool IsActive { get; set; }
    }
}
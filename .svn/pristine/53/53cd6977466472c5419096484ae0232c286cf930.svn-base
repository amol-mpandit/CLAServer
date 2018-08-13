using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CLAServer.Models
{
    public class AttendanceViewModels
    {
        private IEnumerable<AttendanceViewModel> Attendance { get; set; }
    }
    public class AttendanceViewModel
    {
        public int AttendanceId { get; set; }
        public int TimeTableId { get; set; }
        public TimeTableViewModel TimeTable { get; set; }
        public bool IsPresent { get; set; }
        public int StudentId { get; set; }
        public StudentViewModel Student { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedDateTimeToDisplay { get { return CreatedDateTime.ToString("ddd, dd MMM yyyy hh:mm tt"); } }
        public string StudentName { get { return Student.FullName; } }
        public long Mobile { get { return Student.Mobile; } }
        public long HomePhone { get { return Student.HomePhone; } }
        public string Email { get { return Student.Email; } }

    }
}
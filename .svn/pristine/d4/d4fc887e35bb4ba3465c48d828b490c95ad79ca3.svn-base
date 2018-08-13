using AutoMapper;
using CLAServer.Models;
using Core;
using persistence;
using System.Collections.Generic;
using System.Linq;

namespace CLAServer.Managers
{
    public class AttendanceManager
    {
        private readonly AttendanceRepository _attendanceRepository;
        private readonly ClassesRepository _classesRepository;
        private readonly SubjectRepository _subjectRepository;
        private readonly FacultyRepository _facultyRepository;
        private readonly StudentRepository _studentRepository;
        private readonly TimeTableManager _timeTableManager;
        public AttendanceManager(AttendanceRepository attendaceRepository, 
                                TimeTableManager tableManager,
                                ClassesRepository classesRepository,
                                SubjectRepository subjectRepository,
                                FacultyRepository facultyRepository,
                                StudentRepository studentRepository)
        {
            _attendanceRepository = attendaceRepository;
            _timeTableManager = tableManager;
            _classesRepository = classesRepository;
            _subjectRepository = subjectRepository;
            _facultyRepository = facultyRepository;
            _studentRepository = studentRepository;
        }
        
        public void RecordAttendance(int studentId, int timeTabelId)
        {
            _attendanceRepository.RecordAttendance(studentId, timeTabelId, true);
        }

        public bool IsStudentPresent(int studentId, int timeTableId)
        {
            return _attendanceRepository.isStudentPreset(studentId, timeTableId);
        }
        public IEnumerable<AttendanceViewModel> GetAttendanceForTimeTable(int timeTableId)
        {
            var attendance = _attendanceRepository.GetAllForTimeTable(timeTableId);
            var attendanceToView = BuildViewModel(attendance);
            return attendanceToView;
        }
        public IEnumerable<AttendanceViewModel> BuildViewModel(IEnumerable<Attendance> attendanceDto)
        {
            var attendanceViewModels = attendanceDto.Select(Mapper.Map<AttendanceViewModel>).ToList();
            foreach (var attendance in attendanceViewModels)
            {
                attendance.TimeTable = _timeTableManager.GetTimeTableViewModel(attendance.TimeTableId);
                var student = _studentRepository.Get(attendance.StudentId);
                attendance.Student = Mapper.Map<StudentViewModel>(student);
            }
            return attendanceViewModels;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CLAServer.Models;
using Core;
using persistence;

namespace CLAServer.Managers
{
    public class TimeTableManager
    {
        private readonly TimeTableRepository _timeTableRepository;
        private readonly ClassesRepository _classesRepository;
        private readonly SubjectRepository _subjectRepository;
        private readonly FacultyRepository _facultyRepository;
        private readonly StudentRepository _studentRepository;
        public TimeTableManager(TimeTableRepository timeTableRepository, 
                                ClassesRepository classesRepository, 
                                SubjectRepository subjectRepository, 
                                FacultyRepository facultyRepository, 
                                StudentRepository studentRepository)
        {
            _timeTableRepository = timeTableRepository;
            _classesRepository = classesRepository;
            _subjectRepository = subjectRepository;
            _facultyRepository = facultyRepository;
            _studentRepository = studentRepository;
        }

        public IEnumerable<TimeTableViewModel> GetTodaysScheduleBy(int rollNo)
        {
            var student = _studentRepository.GetStudentBy(rollNo);
            var timetable = BuildTodaysTimeTable(student);
            return timetable;

        }
        private IEnumerable<TimeTableViewModel> BuildTodaysTimeTable(Student student)
        {
            var schedule = _timeTableRepository.GetTodaysActiveScheduleBy(student.ClassId, student.SId);
            var scheduleViewModel = BuildTimeTableViewModel(schedule);
            return scheduleViewModel;
        }

        public IEnumerable<TimeTableViewModel> BuildTimeTableViewModel(IEnumerable<TimeTable> schedule)
        {
            var scheduleViewModel = schedule.Select(Mapper.Map<TimeTableViewModel>).ToList();
            foreach (var timeTable in scheduleViewModel)
            {
                timeTable.ClassName = _classesRepository.GetClassNameAndDivisionBy(timeTable.ClassId);
                timeTable.SubjectName = _subjectRepository.GetSubjectNameWithCode(timeTable.SubjectId);
                timeTable.FacultyName = _facultyRepository.GetFacultyFullNameBy(timeTable.FacultyId);
            }
            return scheduleViewModel;
        }
        public TimeTableViewModel GetTimeTableViewModel(int timetableId)
        {
            var timeTable = _timeTableRepository.Get(timetableId);
            var timeTableViewModel = Mapper.Map<TimeTableViewModel>(timeTable);
            timeTableViewModel.ClassName = _classesRepository.GetClassNameAndDivisionBy(timeTable.ClassId);
            timeTableViewModel.SubjectName = _subjectRepository.GetSubjectNameWithCode(timeTable.SubjectId);
            timeTableViewModel.FacultyName = _facultyRepository.GetFacultyFullNameBy(timeTable.FacultyId);
            
            return timeTableViewModel;
        }
    }
}
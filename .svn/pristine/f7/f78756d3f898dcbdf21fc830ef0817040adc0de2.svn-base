using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CLAServer.Managers;
using CLAServer.Models;
using CLAServer.Validators;
using Core;
using FluentValidation.Results;
using persistence;
using System.Web.Http.Cors;

namespace CLAServer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TimeTableController : Controller
    {
        private readonly TimeTableManager _timeTableManager;
        private readonly TimeTableRepository _timeTableRepository;
        private readonly SubjectRepository _subjectRepository;
        private readonly FacultyRepository _facultyRepository;
        private readonly ClassesRepository _classesRepository;
        private readonly TimeTableViewModelValidator _tableViewModelValidator;

        public TimeTableController(TimeTableManager timeTableManager, TimeTableRepository timeTableRepository, SubjectRepository subjectRepository, FacultyRepository facultyRepository, ClassesRepository classesRepository, TimeTableViewModelValidator tableViewModelValidator)
        {
            _timeTableManager = timeTableManager;
            _timeTableRepository = timeTableRepository;
            _subjectRepository = subjectRepository;
            _facultyRepository = facultyRepository;
            _classesRepository = classesRepository;
            _tableViewModelValidator = tableViewModelValidator;
        }
        
        public JsonResult Index()
        {
            var timetablesViewModels = _timeTableRepository.GetAll().Select(Mapper.Map<TimeTableViewModel>).ToList();
            foreach (var timeTable in timetablesViewModels)
            {
                timeTable.ClassName = _classesRepository.GetClassNameAndDivisionBy(timeTable.ClassId);
                timeTable.SubjectName = _subjectRepository.GetSubjectNameWithCode(timeTable.SubjectId);
                timeTable.FacultyName = _facultyRepository.GetFacultyFullNameBy(timeTable.FacultyId);
            }
            return Json(new { result = timetablesViewModels }, JsonRequestBehavior.AllowGet);
        }
        
                
        [HttpPost]
        public JsonResult Add(TimeTableViewModel timeTableToAdd)
        {
            var validationResult = _tableViewModelValidator.Validate(timeTableToAdd);
            if (!validationResult.IsValid)
            {
                RecordValidationMessages(validationResult);
                return Json(new { result = validationResult.Errors.Select(x=>x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
            }
            try
            {
                var timetableToSave = Mapper.Map<TimeTable>(timeTableToAdd);
                _timeTableRepository.Add(timetableToSave);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private void RecordValidationMessages(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
            }
            
        }
        
        [HttpPost]
        public JsonResult Edit(TimeTableViewModel timeTableToEdit)
        {
            var validationResult = _tableViewModelValidator.Validate(timeTableToEdit);
            if (!validationResult.IsValid)
            {
                RecordValidationMessages(validationResult);
                return Json(new { result = validationResult.Errors }, JsonRequestBehavior.AllowGet);
            }
            try
            {
                var timetable = Mapper.Map<TimeTable>(timeTableToEdit);
                _timeTableRepository.Update(timetable);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                _timeTableRepository.Delete(id);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Calendar()
        {
            return View();
        }
        public JsonResult GetStudentsSchedule(int rollNo)
        {
            var timetable = _timeTableManager.GetTodaysScheduleBy(rollNo);
            return 
                timetable == null ? 
                    Json(new { result = "No classes to attend Today!! hurray!" }, 
                        JsonRequestBehavior.AllowGet) 
                    : Json(new { result = timetable }, 
                        JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTimeTableSearchCritera(DateTime dateToFind)
        {
            var timetable = _timeTableRepository.GetTimeTablesForDate(dateToFind);
            var timetablesViewModels = timetable.Select(Mapper.Map<TimeTableViewModel>).ToList();
            foreach (var timeTable in timetablesViewModels)
            {
                timeTable.ClassName = _classesRepository.GetClassNameAndDivisionBy(timeTable.ClassId);
                timeTable.SubjectName = _subjectRepository.GetSubjectNameWithCode(timeTable.SubjectId);
                timeTable.FacultyName = _facultyRepository.GetFacultyFullNameBy(timeTable.FacultyId);
            }
            return Json(new { result = timetablesViewModels }, JsonRequestBehavior.AllowGet);
        }
    }
}

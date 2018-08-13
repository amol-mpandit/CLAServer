using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CLAServer.Models;
using Core;
using persistence;
using AutoMapper;
using System.Web.Http.Cors;
using CLAServer.Validators;
using System.Linq;

namespace CLAServer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class SubjectsController : Controller
    {
        private readonly SubjectRepository _subjectRepository;
        private readonly ClassesRepository _classesRepository;
        private readonly SubjectsViewModelValidator _subjectsViewModelValidator;

        public SubjectsController(SubjectRepository subjectRepository, 
                                  ClassesRepository classesRepository,
                                  SubjectsViewModelValidator subjectsViewModelValidator)
        {
            _subjectRepository = subjectRepository;
            _classesRepository = classesRepository;
            _subjectsViewModelValidator = subjectsViewModelValidator;
        }
        
        public JsonResult Index()
        {
            var allSubjects = new List<SubjectViewModel>();
            foreach (var subject in _subjectRepository.GetAll())
            {
                var subjectToView = Mapper.Map<SubjectViewModel>(subject);
                subjectToView.ClassNameToDisplay = _classesRepository.GetClassNameAndDivisionBy(subjectToView.ClassId);
                allSubjects.Add(subjectToView);
            }
            return Json(new { result = allSubjects }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Add(SubjectViewModel subjectToAdd)
        {
            try
            {
                var validationResult = _subjectsViewModelValidator.Validate(subjectToAdd);
                if (!validationResult.IsValid)
                {
                    return Json(new { result = validationResult.Errors.Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
                }
                var subject = Mapper.Map<Subject>(subjectToAdd);
                _subjectRepository.Add(subject);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult Edit(SubjectViewModel subjectToEdit)
        {
            try
            {
                var validationResult = _subjectsViewModelValidator.Validate(subjectToEdit);
                if (!validationResult.IsValid)
                {
                    return Json(new { result = validationResult.Errors.Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
                }
                var subject = Mapper.Map<Subject>(subjectToEdit);
                _subjectRepository.Update(subject);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _subjectRepository.Delete(id);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

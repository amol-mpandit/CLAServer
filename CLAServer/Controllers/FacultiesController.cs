using System;
using System.Web.Mvc;
using Core;
using persistence;
using System.Collections.Generic;
using CLAServer.Models;
using AutoMapper;
using System.Web.Http.Cors;
using CLAServer.Validators;
using System.Linq;

namespace CLAServer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FacultiesController : Controller
    {
        private readonly FacultyRepository _facultyRepository;
        private readonly FacultyViewModelValidator _facultyViewModelValidator;

        public FacultiesController(FacultyRepository facultyRepository, FacultyViewModelValidator facultyViewModelValidator)
        {
            _facultyRepository = facultyRepository;
            _facultyViewModelValidator = facultyViewModelValidator;
        }

        public JsonResult Index()
        {
            var allFaculties = new List<FacultyViewModel>();
            foreach(var faculty in _facultyRepository.GetAll())
            {
                var facultyToView = Mapper.Map<FacultyViewModel>(faculty);
                allFaculties.Add(facultyToView);
            }
            return Json(new { result = allFaculties }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Details(int id)
        {
            var detail = _facultyRepository.Get(id);
            return View(detail);
        }
        
        [HttpPost]
        public JsonResult Add(FacultyViewModel facultyToAdd)
        {
            try
            {
                var validationResult = _facultyViewModelValidator.Validate(facultyToAdd);
                if (!validationResult.IsValid)
                {
                    return Json(new { result = validationResult.Errors.Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
                }
                var facultyAdd = Mapper.Map<Faculty>(facultyToAdd);
                _facultyRepository.Add(facultyAdd);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult Edit(FacultyViewModel facultyToEdit)
        {
            try
            {
                var validationResult = _facultyViewModelValidator.Validate(facultyToEdit);
                if (!validationResult.IsValid)
                {
                    return Json(new { result = validationResult.Errors.Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
                }
                var facultyEdit = Mapper.Map<Faculty>(facultyToEdit);
                _facultyRepository.Update(facultyEdit);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                _facultyRepository.Delete(id);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

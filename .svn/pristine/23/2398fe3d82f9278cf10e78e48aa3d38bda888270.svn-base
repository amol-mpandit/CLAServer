using System;
using System.Web.Mvc;
using Core;
using persistence;
using System.Web.Http.Cors;
using CLAServer.Validators;
using AutoMapper;
using CLAServer.Models;
using System.Linq;

namespace CLAServer.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ClassesController : Controller
    {
        private readonly ClassesRepository ClassesRepository;
        private readonly CourseViewModelValidator _courseViewModelValidator;

        public ClassesController(ClassesRepository classesRepository, CourseViewModelValidator courseViewModelValidator)
        {
            ClassesRepository = classesRepository;
            _courseViewModelValidator = courseViewModelValidator;
        }

        public JsonResult Index()
        {
            var allClasses = ClassesRepository.GetAll();
            return Json(new { result = allClasses }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Add(ClassesViewModel courseToAdd)
        {
            try
            {
                var validationResult = _courseViewModelValidator.Validate(courseToAdd);
                if(!validationResult.IsValid)
                {
                    return Json(new { result = validationResult.Errors.Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
                }
                var ClassToAdd = Mapper.Map<Classes>(courseToAdd);
                ClassesRepository.Add(ClassToAdd);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult Edit(ClassesViewModel classToEdit)
        {
            try
            {
                var validationResult = _courseViewModelValidator.Validate(classToEdit);
                if (!validationResult.IsValid)
                {
                    return Json(new { result = validationResult.Errors.Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
                }
                var courseToEdit = Mapper.Map<Classes>(classToEdit);
                ClassesRepository.Update(courseToEdit);
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
                ClassesRepository.Delete(id);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

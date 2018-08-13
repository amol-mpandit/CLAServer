using CLAServer.Managers;
using System;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CLAServer.Controllers
{
    [EnableCors("*","*","*")]
    public class AttendanceController : Controller
    {
        private readonly AttendanceManager _attendanceManager;
        public AttendanceController(AttendanceManager attandanceManager)
        {
            _attendanceManager = attandanceManager;
        }
        public JsonResult RecordAttendance(int studentId, int timeTableId)
        {
            try
            {
                var isPresent = _attendanceManager.IsStudentPresent(studentId, timeTableId);
                if (isPresent)
                {
                    return Json(new { result = "AlreadyPresent" }, JsonRequestBehavior.AllowGet);
                }
                _attendanceManager.RecordAttendance(studentId, timeTableId);
                return Json(new { result = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult isStudentPresent(int studentId, int timeTableId)
        {
            var isPresent = _attendanceManager.IsStudentPresent(studentId, timeTableId);
            return Json(new { result = isPresent }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAttendance(int timeTableId)
        {
            var attendance =  _attendanceManager.GetAttendanceForTimeTable(timeTableId);
            return Json(new { result = attendance }, JsonRequestBehavior.AllowGet);
        }
    }
}
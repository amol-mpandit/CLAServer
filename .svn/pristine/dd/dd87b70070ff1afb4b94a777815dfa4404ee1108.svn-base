import DashboardLayout from '../components/Dashboard/Layout/DashboardLayout.vue'

// GeneralViews
import NotFound from '../components/GeneralViews/NotFoundPage.vue'

// Admin pages
import Overview from 'src/components/Dashboard/Views/Overview.vue'
import CourseOverview from 'src/components/Dashboard/Views/Course/courses.vue'
import FacultyOverview from 'src/components/Dashboard/Views/Faculty/Faculties.vue'
import StudentOverview from 'src/components/Dashboard/Views/Student/Students.vue'
import SubjectOverview from 'src/components/Dashboard/Views/Subject/Subjects.vue'
import TimeTableOverview from 'src/components/Dashboard/Views/TimeTable/TimeTable.vue'
import AttendanceOverview from 'src/components/Dashboard/Views/Attendance/AttendanceReport.vue'
import Attendance from 'src/components/Dashboard/Views/Attendance/attendance.vue'

const routes = [
  {
    path: '/',
    component: DashboardLayout,
    redirect: '/overview',
    children: [
      {
        path: 'overview',
        name: 'overview',
        component: Overview
      },
      {
        path: 'Course',
        name: 'Courses',
        component: CourseOverview
      },
      {
        path: 'Faculty',
        name: 'Faculties',
        component: FacultyOverview
      },
      {
        path: 'Subject',
        name: 'Subjects',
        component: SubjectOverview
      },
      {
        path: 'Student',
        name: 'Students',
        component: StudentOverview
      },
      {
        path: 'TimeTable',
        name: 'TimeTable',
        component: TimeTableOverview
      },
      {
        path: 'AttendanceReport',
        name: 'AttendanceReport',
        component: AttendanceOverview
      }

    ]
  },
  { path: '/attendance',
    component: Attendance
  },
  { path: '*', component: NotFound }
]

/**
 * Asynchronously load view (Webpack Lazy loading compatible)
 * The specified component must be inside the Views folder
 * @param  {string} name  the filename (basename) of the view to load.
function view(name) {
   var res= require('../components/Dashboard/Views/' + name + '.vue');
   return res;
};**/

export default routes

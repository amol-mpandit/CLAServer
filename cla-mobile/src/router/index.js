import Vue from 'vue'
import Router from 'vue-router'
import Attendance from '@/components/Attendance/Attendance.vue'
import Login from '@/components/Attendance/Login.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Login',
      name: 'Login',
      component: Login
    },
    {
      path: '/',
      name: 'Attendace',
      component: Attendance
    }
  ]
})

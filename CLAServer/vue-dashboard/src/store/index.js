import Vue from 'vue'
import Vuex from 'vuex'
import Store from './store'
import state from './state'
import actions from './actions'
import mutations from './mutations'
import createLogger from 'vuex/dist/logger'
import courseStore from './modules/course/store'
import facultyStore from './modules/faculty/store'
import studentStore from './modules/student/store'
import subjectStore from './modules/subject/store'
import timeTableStore from './modules/timeTable/store'
import attendanceStore from './modules/attendance/store'
import axios from 'axios'
import VueAxios from 'vue-axios'

Vue.use(Vuex)
Vue.use(VueAxios, axios)

Vue.config.debug = true
const debug = process.env.NODE_ENV !== 'production'

var store = new Store()

const modules = {
  course: courseStore,
  faculty: facultyStore,
  student: studentStore,
  subject: subjectStore,
  timeTable: timeTableStore,
  attendance: attendanceStore
}

Object.assign(store.state, state)
Object.assign(store.actions, actions)
Object.assign(store.mutations, mutations)
Object.assign(store.modules, modules)

store.middlewares = debug ? [createLogger()] : []

export default new Vuex.Store(store)

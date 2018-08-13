// var url = process.env.API_ROOT_URL
// const API_ROUTE = 'http://' + url + '/classes/'
import { util } from '../../../shared/util.js'

const API_ROUTE = 'http://' + util.baseUrl + '/attendance/'
const config = util.corsConfig
export default {
  recordAttendance ({commit}, data) {
    const student = data.student
    const timeTableId = data.timeTableId
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'RecordAttendance', { studentId: student.SId, timeTableId: timeTableId }, config).then((response) => {
      if (response.data.result === 'success') {
        commit('attendanceRecorded', student.RollNo)
      }
      commit('loading', false)
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  isStudentPresent ({commit}, data) {
    const studentId = data.studentId
    const timeTableId = data.timeTableId
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'IsStudentPresent', { studentId: studentId, timeTableId: timeTableId }, config).then((response) => {
      if (response.data.result === true) {
        return true
      }
      return false
    }).catch(function (error) {
      console.log(error)
      return false
    })
  },
  loadAttendanceForTimeTable ({ commit }, timeTableId) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'GetAttendance', { timeTableId: timeTableId }, config).then((response) => {
      if (response) {
        commit('load', response.data.result)
      } else {
        commit('load', {})
      }
      return 'loaded'
    },
    error => {
      console.error(error)
      commit('load', {})
      return 'loadingFailed ' + error
    })
  }
}

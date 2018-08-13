// var url = process.env.API_ROOT_URL
// const API_ROUTE = 'http://' + url + '/Students/'
import { util } from '../../../shared/util.js'
const API_ROUTE = 'http://' + util.baseUrl + '/Students/'
const config = util.corsConfig

export default {
  loadAllStudents ({ commit }) {
    commit('loading', true)
    return this._vm.axios.get(API_ROUTE + 'index', config).then((response) => {
      if (response) {
        commit('load', response.data.result)
      } else {
        commit('load', {})
      }
      return 'loaded'
    }).catch(error => {
      console.error(error)
      commit('load', {})
      return 'loading failed ' + error
    })
  },
  getStudentByRollNo ({ commit }, rollNo) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'GetStudentByRollNo', { rollNo: rollNo }, config).then((response) => {
      if (response.data.result === 'Student Not found') {
        commit('loadStudent', {})
        return 'Student not found!! Please try again.'
      } else {
        commit('loadStudent', response.data.result)
        return 'success'
      }
    }).catch(error => {
      console.error(error)
      commit('loadStudent', {})
      return error
    })
  },
  addStudent ({commit}, student) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'add', { studentToAdd: student }, config).then((response) => {
      if (response.data.result === 'success') {
        commit('add')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  deleteStudent ({commit}, id) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'delete', {id: id}, config).then((response) => {
      if (response.data.result === 'success') {
        commit('remove')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  editStudent ({commit}, item) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'edit', { studentToEdit: item }, config).then((response) => {
      if (response.data.result === 'success') {
        commit('edit')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  }
}

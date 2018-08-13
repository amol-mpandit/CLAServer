// var url = process.env.API_ROOT_URL
// const API_ROUTE = 'http://' + url + '/classes/'
import { util } from '../../../shared/util.js'

const API_ROUTE = 'http://' + util.baseUrl + '/classes/'
const config = util.corsConfig
export default {
  loadAllCourses ({ commit }) {
    commit('loading', true)
    return this._vm.axios.get(API_ROUTE + 'index', config).then((response) => {
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
      return 'loading failed ' + error
    })
  },
  addCourse ({commit}, course) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'add', { courseToAdd: course }, config).then((response) => {
      if (response.data.result === 'success') {
        commit('add')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  deleteCourse ({commit}, id) {
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
  editCourse ({commit}, item) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'edit', { classToEdit: item }, config).then((response) => {
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

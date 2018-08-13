// var url = process.env.API_ROOT_URL
// const API_ROUTE = 'http://' + url + '/Faculties/'
import { util } from '../../../shared/util.js'
const API_ROUTE = 'http://' + util.baseUrl + '/Faculties/'
const config = util.corsConfig
export default {
  loadAllFaculties ({ commit }) {
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
      return 'loading failed' + error
    })
  },
  addFaculty ({commit}, faculty) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'add', { facultyToAdd: faculty }).then((response) => {
      if (response.data.result === 'success') {
        commit('add')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  deleteFaculty ({commit}, id) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'delete', {id: id}).then((response) => {
      if (response.data.result === 'success') {
        commit('remove')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  editFaculty ({commit}, item) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'edit', { facultyToEdit: item }).then((response) => {
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

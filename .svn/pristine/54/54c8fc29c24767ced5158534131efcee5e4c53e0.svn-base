// var url = process.env.API_ROOT_URL
// const API_ROUTE = 'http://' + url + '/Subjects/'
import { util } from '../../../shared/util.js'
const API_ROUTE = 'http://' + util.baseUrl + '/Subjects/'
const config = util.corsConfig

export default {
  loadAllSubjects ({ commit }) {
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
  addSubject ({commit}, subject) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'add', { subjectToAdd: subject }, config).then((response) => {
      if (response.data.result === 'success') {
        commit('add')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  deleteSubject ({commit}, id) {
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
  editSubject ({commit}, item) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'edit', { subjectToEdit: item }, config).then((response) => {
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

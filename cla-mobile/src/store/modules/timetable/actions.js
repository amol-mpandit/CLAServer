// var url = process.env.API_ROOT_URL
// const API_ROUTE = 'http://' + url + '/Timetable/'
import { util } from '../../../shared/util.js'
const API_ROUTE = 'http://' + util.baseUrl + '/Timetable/'
const config = util.corsConfig
export default {
  loadTimeTable ({ commit }) {
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
  loadReportSearchCritera ({ commit }, date) {
    var dateToSearch = this._vm.$moment(date).toJSON()
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'GetTimeTableSearchCritera', { dateToFind: dateToSearch }, config).then((response) => {
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
  },
  loadTodaysSchedule ({ commit }, rollNo) {
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'GetStudentsSchedule', { rollNo }, config).then((response) => {
      if (response) {
        commit('loadTodaysTimeTable', response.data.result)
      } else {
        commit('loadTodaysTimeTable', {})
      }
      return 'loaded'
    }).catch(error => {
      console.error(error)
      commit('loadTodaysTimeTable', {})
      return error
    })
  },
  addTimeTable ({commit}, timeTable) {
    if (timeTable.StartTime) {
      timeTable.StartTime = this._vm.$moment(timeTable.StartTime).toJSON()
    }
    if (timeTable.EndTime) {
      timeTable.EndTime = this._vm.$moment(timeTable.EndTime).toJSON()
    }
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'add', { timeTableToAdd: timeTable }, config).then((response) => {
      if (response.data.result === 'success') {
        commit('add')
      }
      return response.data.result
    }).catch(function (error) {
      commit('loading', false)
      return error
    })
  },
  deleteTimeTable ({commit}, id) {
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
  editTimeTable ({commit}, item) {
    if (item.StartTime) {
      item.StartTime = this._vm.$moment(item.StartTime).toJSON()
    }
    if (item.EndTime) {
      item.EndTime = this._vm.$moment(item.EndTime).toJSON()
    }
    commit('loading', true)
    return this._vm.axios.post(API_ROUTE + 'edit', { timeTableToEdit: item }, config).then((response) => {
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

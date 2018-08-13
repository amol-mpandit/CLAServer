export default {
  load (state, result) {
    state.timeTable = result
    state.loading = false
  },
  loadTodaysTimeTable (state, result) {
    state.studentTimeTable = result
    state.loading = false
  },
  add (state) {
    state.loading = false
    this.dispatch('timeTable/loadTimeTable')
  },
  remove (state) {
    state.loading = false
    this.dispatch('timeTable/loadTimeTable')
  },
  edit (state) {
    state.loading = false
    this.dispatch('timeTable/loadTimeTable')
  },
  loading (state, val) {
    state.loading = val
  }
}

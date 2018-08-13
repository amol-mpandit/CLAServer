export default {
  load (state, result) {
    state.subjects = result
    state.loading = false
  },
  add (state) {
    state.loading = false
    this.dispatch('subject/loadAllSubjects')
  },
  remove (state) {
    state.loading = false
    this.dispatch('subject/loadAllSubjects')
  },
  edit (state) {
    state.loading = false
    this.dispatch('subject/loadAllSubjects')
  },
  loading (state, val) {
    state.loading = val
  }
}

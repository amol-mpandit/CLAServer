export default {
  load (state, result) {
    state.faculties = result
    state.loading = false
  },
  add (state) {
    state.loading = false
    this.dispatch('faculty/loadAllFaculties')
  },
  remove (state) {
    state.loading = false
    this.dispatch('faculty/loadAllFaculties')
  },
  edit (state) {
    state.loading = false
    this.dispatch('faculty/loadAllFaculties')
  },
  loading (state, val) {
    state.loading = val
  }
}

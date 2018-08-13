export default {
  load (state, result) {
    state.students = result
    state.loading = false
  },
  loadStudent (state, result) {
    state.student = result
    state.loading = false
  },
  add (state) {
    state.loading = false
    this.dispatch('student/loadAllStudents')
  },
  remove (state) {
    state.loading = false
    this.dispatch('student/loadAllStudents')
  },
  edit (state) {
    state.loading = false
    this.dispatch('student/loadAllStudents')
  },
  loading (state, val) {
    state.loading = val
  }
}

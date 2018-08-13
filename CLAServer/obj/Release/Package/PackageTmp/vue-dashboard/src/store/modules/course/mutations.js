export default {
  load (state, result) {
    state.courses = result
    state.loading = false
  },
  add (state) {
    state.loading = false
    this.dispatch('course/loadAllCourses')
  },
  remove (state) {
    state.loading = false
    this.dispatch('course/loadAllCourses')
  },
  edit (state) {
    state.loading = false
    this.dispatch('course/loadAllCourses')
  },
  loading (state, val) {
    state.loading = val
  }
}

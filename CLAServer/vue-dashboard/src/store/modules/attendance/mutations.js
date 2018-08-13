export default {
  attendanceRecorded (state, rollno) {
    state.loading = false
    this.dispatch('timeTable/loadTodaysSchedule', rollno)
  },
  load (state, result) {
    state.attendance = result
    state.loading = false
  },
  loading (state, val) {
    state.loading = val
  }
}

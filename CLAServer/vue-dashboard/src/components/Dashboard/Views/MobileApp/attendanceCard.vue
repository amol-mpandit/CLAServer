<template>
  <div v-loading="loadingTimeTable">
    <div class="card" v-model="student">
        <h2 class="container">Today's Attendance</h2>
        <div v-for="(info,index) in timeTable" :class="getClasses(index)">
          <h5>Lecture
            <br>
            <small>{{ info.ClassName }}</small>
          </h5>
          <h5>Faculty
            <br>
            <small>{{ info.FacultyName }}</small>
          </h5>
          <h5>Subject
            <br>
            <small>{{ info.SubjectName }}</small>
          </h5>
          <h5>Start Time
            <br>
            <small>{{ info.StartTimeToDisplay }}</small>
          </h5>
          <h5>End Time
            <br>
            <small>{{ info.EndTimeToDisplay }}</small>
          </h5>
          <el-button type="primary" v-loading="loading" @click="present(student, info)">
              Present
            </el-button>
          <!-- <div v-model="IsAttended">
            <div v-if="IsAttended">
              <h5>Attendance
              <br>
              <small>Maked As Present</small>
            </h5>
            </div>
            <div v-else>
            <el-button type="primary" v-loading="loading" @click="present(student, info)">
              Present
            </el-button>
            </div>
          </div> -->
        </div>
    </div>
  </div>
</template>
<script>

import { mapState, mapActions } from 'vuex'
export default {
  props: {
    student: {}
  },
  data () {
    return {
      attended: false
    }
  },
  computed: {
    ...mapState({
      timeTable: state => state.timeTable.studentTimeTable,
      attendance: state => state.attendance.attendance,
      loadingTimeTable: state => state.timeTable.loading,
      loading: state => state.attendance.loading
    }),
    IsAttended: {
      get: function () {
      },
      set: function () {
      }
    }
  },
  methods: {
    ...mapActions('timeTable', ['loadTodaysSchedule']),
    ...mapActions('attendance', ['recordAttendance', 'isStudentPresent']),
    getClasses (index) {
      var remainder = index % 3
      if (remainder === 0) {
        return 'col-md-3 col-md-offset-1'
      } else if (remainder === 2) {
        return 'col-md-4'
      } else {
        return 'col-md-3'
      }
    },
    present (student, info) {
      if (student && info) {
        let data = {
          student: student,
          timeTableId: info.TimeTableId
        }
        this.recordAttendance(data)
      }
    },
    isPresent (studentId, timeTableId) {
      const data = {
        studentId: studentId,
        timeTableId: timeTableId
      }
      return this.isStudentPresent(data).then((result) => {
        if (result) {
          this.attended = true
        }
        return result
      }).catch((error) => {
        console.log(error)
        return false
      })
    }
  }
}
</script>

<style>

</style>

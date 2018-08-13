<template>
  <el-container v-loading="loadingTimeTable">
    <el-container :student="student">
        <el-header><h2>Today's Attendance</h2></el-header>

        <el-main>
          <el-row :span=24 :gutter=10 v-for="(info,index) in timeTable" :key="index">
            <el-col :span=24>
              <span>Subject:</span>
              <h3><span>{{ info.SubjectName }}</span></h3>
            </el-col>
            <el-col :span=12>
              <span>Faculty:</span>
              <span>{{ info.FacultyName }}</span>
            </el-col>
            <el-col :span=12>
              <span>Course:</span>
              <span>{{ info.ClassName }}</span>
            </el-col>
            <el-col :span="24">
              <hr>
            </el-col>
            <el-col :span=24>
              <span>Start Time:</span>
              <span>{{ info.StartTimeToDisplay }}</span>
            </el-col>
            <el-col :span=24>
              <span>End Time:</span>
              <span>{{ info.EndTimeToDisplay }}</span>
            </el-col>
            <el-col :span="24">
              <hr>
            </el-col>
            <el-row :span=24>
              <el-button type="primary" style="width: 100%;" v-loading="loading" icon="el-icon-check" @click="present(student, info)">
                Present
              </el-button>
            </el-row>
            <br>
            <hr>
          </el-row>

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
        </el-main>
    </el-container>
  </el-container>
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
    })
    // IsAttended: {
    //   get: function () {
    //   },
    //   set: function () {
    //   }
    // }
  },
  methods: {
    ...mapActions('timeTable', ['loadTodaysSchedule']),
    ...mapActions('attendance', ['recordAttendance', 'isStudentPresent']),
    getClasses (index) {
      console.log('index is : ' + index)
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
        this.recordAttendance(data).then((result) => {
          if (result === 'success') {
            this.$toaster.success('Attendance Recorded.')
            this.loadTodaysSchedule(this.student.RollNo)
          } else if (result === 'AlreadyPresent') {
            this.$toaster.info('You are already marked as present')
          } else {
            this.$toaster.error('Fail to record Attendance!')
            this.$toaster.error(result)
          }
        })
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
.el-row {
    margin-bottom: 20px;
    &:last-child {
      margin-bottom: 0;
    }
  }
  .el-col {
    border-radius: 4px;
  }
</style>

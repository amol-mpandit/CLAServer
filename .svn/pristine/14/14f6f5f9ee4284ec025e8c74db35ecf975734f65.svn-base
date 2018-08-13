<template>
    <div class="card container" v-loading="loading"
        element-loading-text="Loading..."
        element-loading-spinner="el-icon-loading"
        element-loading-background="rgba(0, 0, 0, 0.5)">
      <student-card :item="student">
      </student-card>
      <attendance-card :student="student"></attendance-card>
      <modal :show="showLogin"
          @close="showLogin=true">
          <template slot="header">
            <span>Login</span>
          </template>
            <template slot="body">
              <span>Please Enter Roll no to login</span>
              <div class="item-input">
                <input type="text" placeholder="Enter Roll No here" @keyup.enter="login" v-model="inputRollNo">
              </div>
            </template>
            <template slot="footer">
              <el-button class="item-input-button" type="primay" placeholder="RollNo" @click.prevent="login">Login</el-button>
            </template>
      </modal>
    </div>
</template>

<script>
import StudentCard from './StudentCard.vue'
import AttendanceCard from './AttendanceCard.vue'
import Modal from '../Modal.vue'
import { mapState, mapActions } from 'vuex'

export default {
  components: {
    StudentCard,
    AttendanceCard,
    Modal
  },
  data () {
    return {
      showLogin: true,
      studentToView: {},
      inputRollNo: ''
    }
  },
  computed: mapState({
    student: state => state.student.student,
    loading: state => state.student.loading
  }),
  methods: {
    ...mapActions('student', ['getStudentByRollNo']),
    ...mapActions('timeTable', ['loadTodaysSchedule']),
    login () {
      this.showLogin = false
      this.getStudentByRollNo(this.inputRollNo).then((result) => {
        if (result === 'success') {
          var msg = 'Student login successfull.'
          this.$toaster.success(msg)
          this.loadTodaysSchedule(this.student.RollNo)
        } else {
          this.showLogin = true
          this.$toaster.error(result)
        }
      })
    }
  }
}
</script>

<style>

</style>

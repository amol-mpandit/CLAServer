<template>
    <div v-loading="loading" 
        element-loading-text="Loading..."
        element-loading-spinner="el-icon-loading"
        element-loading-background="rgba(0, 0, 0, 0.8)">
      <student-card :item="student">
      </student-card>
      <attendance-card :student="student"></attendance-card>
      <row-modal :action="'Login'"
          :hideTitle="true"
          :message="'Please enter Roll No To proceed'"
          :show="showLogin"
          @close="showLogin=true"
          @executeAction="login">
            <template slot="slotedModalBody">
              <el-input @keyup.enter="login" v-model="inputRollNo" style="width:30px, height=150px;" />
            </template>
      </row-modal>
    </div>
</template>

<script>
import StudentCard from './StudentCard.vue'
import AttendanceCard from './AttendanceCard.vue'
import 

export default {
  components: {
    StudentCard,
    AttendanceCard
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
          this.$notifications.notifyVue('success', msg)
          this.loadTodaysSchedule(this.student.RollNo)
        } else {
          this.showLogin = true
          this.$notifications.notifyVue('denger', result)
        }
      })
    }
  }
}
</script>

<style>

</style>

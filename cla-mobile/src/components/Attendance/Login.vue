<template>
  <f7-page no-toolbar no-navbar no-swipeback login-screen :opened="showLogin">
    <f7-login-screen-title>CLA Student Login</f7-login-screen-title>
    <f7-list form>
      <f7-list-item>
        <f7-label>Roll No</f7-label>
        <f7-input type="text" placeholder="Roll No" @input="inputRollNo = $event.target.value"></f7-input>
      </f7-list-item>
    </f7-list>
    <f7-list>
      <f7-list-button @click="login">Login</f7-list-button>
      <f7-block-footer>Please Enter Roll no to Proceed.</f7-block-footer>
    </f7-list>
  </f7-page>
</template>

<script>
import { mapState, mapActions } from 'vuex'
export default {
  data () {
    return {
      showLogin: true,
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
      const app = self.$f7
      this.getStudentByRollNo(this.inputRollNo).then((result) => {
        if (result === 'success') {
          const msg = 'Student login successfull.'
          app.dialog.alert(msg, () => {
            this.loadTodaysSchedule(this.student.RollNo)
          })
          app.loginScreen.close()
        } else {
          const message = 'Student login failed.'
          app.dialog.alert(message, () => {
            this.$toaster.error(result)
          })
        }
      })
    }
  }
}
</script>

<style>

</style>

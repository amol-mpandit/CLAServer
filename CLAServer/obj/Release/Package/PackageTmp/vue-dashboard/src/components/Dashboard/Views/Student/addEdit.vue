<template>
    <div v-model="item">
        <div class="col-md-3">
            <fg-input type="text"
                        label="Student Id"
                        :disabled="true"
                        placeholder="Automactically Assigned"
                        v-model="item.SId">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="number"
                        label="Roll no"
                        placeholder="Roll No"
                        v-model="item.RollNo">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="First Name"
                        placeholder="First Name"
                        v-model="item.FirstName">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                      label="Middle Name"
                      placeholder="Middle Name"
                      v-model="item.MiddleName">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                      label="Last Name"
                      placeholder="Last Name"
                      v-model="item.LastName">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                      label="Enrollment No"
                      placeholder="Enrollment No"
                      v-model="item.EnrollmentNo">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="number"
                      label="Mobile"
                      placeholder="Mobile"
                      v-model="item.Mobile">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="number"
                      label="Home Phone"
                      placeholder="Home Phone"
                      v-model="item.HomePhone">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                      label="Email"
                      placeholder="Email"
                      v-model="item.Email">
            </fg-input>
        </div>
        <div class="col-md-3">
            <label>Course Name</label>
            <select placeholder="Course Name" class="form-control border-input" v-model="item.ClassId">
               <option value="" hidden>Select Course</option>
               <option v-for="course in courses" v-bind:value="course.ClassId">
                   {{ course.ClassName }} - {{ course.Division  }}
               </option>
            </select>            
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex'
export default {
  props: {
    item: {}
  },
  computed: {
    ...mapState({
      courses: state => state.course.courses
    })
  },
  created () {
    this.$store.dispatch('course/loadAllCourses')
  }
}
</script>

<style>

</style>

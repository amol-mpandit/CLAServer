<template>
    <div v-model="item">
        <div class="col-md-3">
            <fg-input type="text"
                        label="Subject Id"
                        :disabled="true"
                        placeholder="Automactically Assigned"
                        v-model="item.SubId">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="Subject Name"
                        placeholder="Subject Name"
                        v-model="item.Name">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="Subject Code"
                        placeholder="Subject Code"
                        v-model="item.Code">
            </fg-input>
        </div>
        <div class="col-md-3">
            <label>Course Name</label>
            <select class="form-control border-input" v-model="item.ClassId">
               <option value="" hidden>Select Course</option>
               <option v-for="course in courses" v-bind:value="course.ClassId">
                   {{ course.ClassName }} - {{ course.Division }}
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

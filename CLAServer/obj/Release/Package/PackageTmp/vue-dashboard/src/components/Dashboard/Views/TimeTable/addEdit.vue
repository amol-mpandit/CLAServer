<template>
    <div v-model="item">
        <div class="col-md-1">
            <fg-input type="text"
                        label="Id"
                        :disabled="true"
                        placeholder="Automactically Assigned"
                        v-model="item.TimeTableId">
            </fg-input>
        </div>
        <div class="col-md-3">
            <label>Course Name</label>
            <select class="form-control border-input" v-model="item.ClassId">
                <option value="" hidden>Select Course</option>
                <option v-for="course in courses" v-bind:value="course.ClassId">
                    {{ course.ClassName }} - {{ course.Division  }}
                </option>
            </select>
        </div>
        <div class="col-md-3">
            <label>Faculty Name</label>
            <select class="form-control border-input" v-model="item.FacultyId">
                <option value="" hidden>Select Faculty</option>
                <option v-for="faculty in faculties" v-bind:value="faculty.FId">
                    {{ faculty.FullName }}
                </option>
            </select>
        </div>
        <div class="col-md-3">
            <label>Subject Name</label>
            <select class="form-control border-input" v-model="item.SubjectId">
                <option value="" hidden>Select Faculty</option>
                <option v-for="subject in subjects" v-bind:value="subject.SubId">
                    {{ subject.Code }} - {{ subject.Name }}
                </option>
            </select>
        </div>
        <div class="col-md-6">
            <label>Lecture Start-End DateTime</label>
            <start-end-datetime :startDateTime="item.StartTime" :endDateTime="item.EndTime" @dateChanged="setDateTime"></start-end-datetime>
        </div>
        <div class="col-md-3">
            <label>Is Scheduled</label>
            <br>
            <input type="checkbox" id="checkbox" v-model="item.IsActive">
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
      courses: state => state.course.courses,
      subjects: state => state.subject.subjects,
      faculties: state => state.faculty.faculties
    })
  },
  methods: {
    setDateTime: function (dateValues) {
      if (dateValues.startDate) {
        this.item.StartTime = this.$moment(dateValues.startDate)
      }
      if (dateValues.endDate) {
        this.item.EndTime = this.$moment(dateValues.endDate)
      }
    }
  },
  created () {
    this.$store.dispatch('course/loadAllCourses')
    this.$store.dispatch('faculty/loadAllFaculties')
    this.$store.dispatch('subject/loadAllSubjects')
  }
}
</script>

<style>

</style>

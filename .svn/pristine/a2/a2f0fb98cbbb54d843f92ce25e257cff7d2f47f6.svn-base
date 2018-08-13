<template>
<div>
    <div>
        <label>Select Date</label>
        <el-date-picker type="date" v-model="date" @change="dateChnaged" :minvalue="new Date()" ></el-date-picker>
    </div>
    <div v-loading="loadingTimeTable">
        <label>Select from list to view Attendance Report</label>
        <select class="form-control border-input" v-model="searchCritera" aria-placeholder="Please Select">
                <option value="0" hidden>Please Select</option>
                <option v-for="timeTable in timeTable" v-bind:value="timeTable">
                    {{ timeTable.ClassName }} - {{timeTable.SubjectName}} - {{timeTable.FacultyName}}
                </option>
        </select>
    <br>
    <div>
        <el-button type="primary" @click="loadAttendanceForTimeTable(searchCritera.TimeTableId)"> Generate Report</el-button>
    </div>
    </div>
    <div v-loading="loading">
        <paper-table :columnsToDisplay="studentsTableColumnsToDisaplay"
                    :columns="columns"
                    :data="attendance">
            <template slot="header">
                <h4> Attendance For </h4>
                <div> 
                    <label>Course: </label>
                    <span></span>
                    <span>{{ searchCritera.ClassName }}</span>
                </div>
                <div> 
                    <label>Subject: </label>
                    <span></span>
                    <span>{{ searchCritera.SubjectName }}</span>
                </div>
                <div> 
                    <label>Faculty: </label>
                    <span></span>
                    <span>{{ searchCritera.FacultyName }}</span>
                </div>
            </template>
        </paper-table>
    </div>
</div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
const studentsTableColumnsToDisaplay = ['Student Name', 'Phone', 'Home Phone', 'Email', 'Is Present', 'Attended DateTime']
const columns = ['StudentName', 'Mobile', 'HomePhone', 'Email', 'IsPresent', 'CreatedDateTimeToDisplay']
export default {
  data () {
    return {
      selectedTimeTableId: 0,
      date: new Date(),
      searchCritera: {
        TimeTableId: 0,
        ClassName: '',
        SubjectName: '',
        FacultyName: ''
      },
      studentsTableColumnsToDisaplay: studentsTableColumnsToDisaplay,
      columns: columns
    }
  },
  computed: {
    ...mapState({
      timeTable: state => state.timeTable.timeTable,
      attendance: state => state.attendance.attendance,
      loadingTimeTable: state => state.timeTable.loading,
      loading: state => state.attendance.loading
    })
  },
  methods: {
    ...mapActions('timeTable', ['loadReportSearchCritera']),
    ...mapActions('attendance', ['loadAttendanceForTimeTable']),
    dateChnaged: function (newValue) {
      this.date = newValue
      this.loadReportSearchCritera(this.date)
    },
    generateReport: function () {
    }
  }
}
</script>

<style>

</style>

<template>
    <div class="form-group">
        <div class="block">
            <el-date-picker 
               ref="addEditDate"
               class="form-control border-input"
               v-model="dates" 
               type="datetimerange"
               range-separator="-" 
               start-placeholder="Start date" 
               end-placeholder="End date"
               format="yyyy-MM-dd HH:mm A" 
               align="right"
               :picker-options="datePickerOptions"
               @change="dateTimeChanged"
               >
            </el-date-picker>
            <!--<el-date-picker
                type="date"
                v-model="dates[0]" 
                placeholder="Pick a lecture date"
                :picker-options="datePickerOptions"
                @change="dateTimeChanged">
            </el-date-picker>
            <el-time-select placeholder="Start time"
                            v-model="dates[0]"
                            format="HH:mm A"
                            :picker-options="{
                              start: '06:00',
                              step: '00:10',
                              end: '21:30'
                            }"
                            @change="dateTimeChanged">
            </el-time-select>
            <el-time-select placeholder="End time"
                            v-model="dates[1]"
                            format="HH:mm A"
                            :picker-options="{
                                start: '06:00',
                                step: '00:10',
                                end: '21:30',
                                minTime: dates[0]
                            }"
                            @change="dateTimeChanged">
            </el-time-select>-->
        </div>
    </div>
</template>

<script>
export default {
  props: {
    startDateTime: {},
    endDateTime: {}
  },
  data () {
    let self = this
    return {
      dates: this.getDates(),
      datePickerOptions: {
        disabledDate (date) {
          return !self.$moment(date).isSameOrAfter(self.$moment(), 'day')
        }
      }
    }
  },
  methods: {
    dateTimeChanged: function (dateValues) {
      if (dateValues) {
        this.$emit('dateChanged', { startDate: dateValues[0], endDate: dateValues[1] })
      }
    },
    getDates: function () {
      let arr = []
      if (this.startDateTime) {
        arr[0] = this.$moment(this.startDateTime).toDate()
      }
      if (this.endDateTime) {
        arr[1] = this.$moment(this.endDateTime).toDate()
      }
      return arr
    }
  }
}
</script>
<style>

</style>

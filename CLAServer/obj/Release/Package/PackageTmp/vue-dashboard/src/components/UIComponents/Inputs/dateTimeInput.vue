<template>
    <div class="form-group">
        <label v-if="label">
            {{label}}
        </label>
        <input class="form-control border-input" type="date" v-model="dateValue" :min="minDate" :max="maxDate">
        <input class="form-control border-input" type="time" v-model="timeValue" :min="minTime" :max="maxTime">
    </div>
</template>
<script>
export default {
  props: {
    date: {},
    label: String,
    minDate: String,
    maxDate: String,
    minTime: String,
    maxTime: String
  },
  data () {
    return {
      bindedDate: this.date
    }
  },
  computed: {
    dateValue: {
      get: function () {
        if (this.bindedDate) {
          return this.$moment(this.bindedDate).format('YYYY-MM-DD')
        }
        return this.$moment().format('YYYY-MM-DD')
      },
      set: function (val) {
        if (this.timeValue) {
          let stringDate = val + ' ' + this.timeValue
          this.bindedDate = this.$moment(stringDate).format('YYYY-MM-DD HH:mm')
        }
      }
    },
    timeValue: {
      get: function () {
        if (this.bindedDate) {
          return this.$moment(this.bindedDate).format('HH:mm')
        }
        return this.$moment().format('HH:mm')
      },
      set: function (val) {
        if (this.dateValue) {
          let stringDate = this.dateValue + ' ' + val
          this.bindedDate = this.$moment(stringDate).format('YYYY-MM-DD HH:mm')
        }
      }
    }
  }
}
</script>
<style>

</style>

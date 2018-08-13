import fgInput from './components/UIComponents/Inputs/formGroupInput.vue'
import dateTimeInput from './components/UIComponents/Inputs/dateTimeInput.vue'
import DropDown from './components/UIComponents/Dropdown.vue'
import PaperTable from './components/UIComponents/PaperTable.vue'
import RowModal from './components/UIComponents/RowModal.vue'
import StartEndDateTime from './components/UIComponents/StartEndDatetime.vue'
import { DatePicker, TimeSelect, TimePicker } from 'element-ui'
import ChartCard from './components/UIComponents/Cards/ChartCard.vue'
import StatsCard from './components/UIComponents/Cards/StatsCard.vue'
import UserCard from './components/Dashboard/Views/UserProfile/UserCard.vue'

/**
 * You can register global components here and use them as a plugin in your main Vue instance
 */

const GlobalComponents = {
  install (Vue) {
    Vue.component('fg-input', fgInput)
    Vue.component('drop-down', DropDown)
    Vue.component('paper-table', PaperTable)
    Vue.component('row-modal', RowModal)
    Vue.component('date-time-input', dateTimeInput)
    Vue.component('start-end-datetime', StartEndDateTime)
    Vue.component(DatePicker)
    Vue.component(TimeSelect)
    Vue.component(TimePicker)
    Vue.component('chart-card', ChartCard)
    Vue.component('stats-card', StatsCard)
    Vue.component('user-card', UserCard)
  }
}

export default GlobalComponents

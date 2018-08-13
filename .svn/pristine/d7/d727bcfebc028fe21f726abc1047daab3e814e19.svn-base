import Vue from 'vue'
import VueRouter from 'vue-router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import vClickOutside from 'v-click-outside'
import store from './store/index'

// Plugins
import GlobalComponents from './gloablComponents'
import Notifications from './components/UIComponents/NotificationPlugin'
import SideBar from './components/UIComponents/SidebarPlugin'
import App from './App'
import lodash from 'lodash'
import VueLodash from 'vue-lodash'
import moment from 'moment'
import VueMomentJS from 'vue-momentjs'
import FullCalendar from 'vue-full-calendar'
import ToggleButton from 'vue-js-toggle-button'
import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale/lang/en'

// router setup
import routes from './routes/routes'

// library imports
import Chartist from 'chartist'
import 'bootstrap/dist/css/bootstrap.css'
import './assets/sass/paper-dashboard.scss'
import 'es6-promise/auto'
import 'fullcalendar/dist/fullcalendar.css'
import 'element-ui/lib/theme-chalk/index.css'

// plugin setup
Vue.use(VueRouter)
Vue.use(GlobalComponents)
Vue.use(vClickOutside)
Vue.use(Notifications)
Vue.use(SideBar)
Vue.use(VueAxios, axios)
Vue.use(VueLodash, lodash)
Vue.use(VueMomentJS, moment)
Vue.use(FullCalendar)
Vue.use(ToggleButton)
Vue.use(ElementUI, { locale })

// configure router
const router = new VueRouter({
  routes, // short for routes: routes
  linkActiveClass: 'active'
})

// global library setup
Object.defineProperty(Vue.prototype, '$Chartist', {
  get () {
    return this.$root.Chartist
  }
})

/* eslint-disable no-new */
new Vue({
  el: '#app',
  render: h => h(App),
  router,
  store,
  data: {
    Chartist: Chartist
  }
})

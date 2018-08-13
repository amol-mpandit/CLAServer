// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store/index'

// import Framework7Vue from 'framework7-vue'
import Vuex from 'vuex'
import axios from 'axios'
import VueAxios from 'vue-axios'
import lodash from 'lodash'
import VueLodash from 'vue-lodash'
import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale/lang/en'
import Toaster from 'v-toaster'
import 'v-toaster/dist/v-toaster.css'
import 'element-ui/lib/theme-chalk/index.css'
// import Framework7 from 'framework7'
// import Framework7Vue from 'framework7-vue'
// import 'framework7/css/framework7.md.min.css'

Vue.config.productionTip = false

Vue.use(Vuex)
Vue.use(VueAxios, axios)
Vue.use(VueLodash, lodash)
Vue.use(ElementUI, { locale })
Vue.use(Toaster, {timeout: 5000})
// Vue.use(Framework7Vue, Framework7)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  framework7: {
    root: '#app',
    routes: router
  },
  router,
  store,
  components: { App },
  template: '<App/>'
})

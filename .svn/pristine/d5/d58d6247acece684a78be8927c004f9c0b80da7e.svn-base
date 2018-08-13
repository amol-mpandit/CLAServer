import Notifications from './Notifications.vue'

const NotificationStore = {
  state: [], // here the notifications will be added

  removeNotification (index) {
    this.state.splice(index, 1)
  },
  notify (notification) {
    this.state.push(notification)
  },
  notifyVue (notifyType, message) {
      // const notifyType = ['', 'info', 'success', 'warning', 'danger']
    this.notify(
      {
        message: message,
        icon: 'ti-save',
        horizontalAlign: 'center',
        verticalAlign: 'top',
        type: notifyType
      })
  },
  showSaved (entity, action, result) {
    if (result === 'success') {
      let notifyType = 'success'
      if (action === 'delete') { notifyType = 'warning' }
      let msg = '<b>Success</b> <br>' + entity + ' ' + action + 'ed successfully.</br>'
      this.notifyVue(notifyType, msg)
    } else {
      let errMsg = '<b>Failed to ' + action + ' ' + entity + '!</b><br>' + result
      this.notifyVue('danger', errMsg)
    }
  }
}

var NotificationsPlugin = {

  install (Vue) {
    Object.defineProperty(Vue.prototype, '$notifications', {
      get () {
        return NotificationStore
      }
    })
    Vue.component('Notifications', Notifications)
  }
}

export default NotificationsPlugin

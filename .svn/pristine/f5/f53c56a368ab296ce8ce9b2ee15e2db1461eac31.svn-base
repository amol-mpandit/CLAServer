import Sidebar from './SideBar.vue'

const SidebarStore = {
  showSidebar: false,
  sidebarLinks: [
    {
      name: 'Courses',
      icon: 'ti-panel',
      path: '/Course'
    },
    {
      name: 'Faculties',
      icon: 'ti-user',
      path: '/Faculty'
    },
    {
      name: 'Subjects',
      icon: 'ti-view-list-alt',
      path: '/Subject'
    },
    {
      name: 'Students',
      icon: 'ti-text',
      path: '/Student'
    },
    {
      name: 'TimeTable',
      icon: 'ti-pencil-alt2',
      path: '/TimeTable'
    },
    {
      name: 'Attendance',
      icon: 'ti-map',
      path: '/AttendanceReport'
    }
  ],
  displaySidebar (value) {
    this.showSidebar = value
  }
}

const SidebarPlugin = {

  install (Vue) {
    Vue.mixin({
      data () {
        return {
          sidebarStore: SidebarStore
        }
      }
    })

    Object.defineProperty(Vue.prototype, '$sidebar', {
      get () {
        return this.$root.sidebarStore
      }
    })
    Vue.component('side-bar', Sidebar)
  }
}

export default SidebarPlugin

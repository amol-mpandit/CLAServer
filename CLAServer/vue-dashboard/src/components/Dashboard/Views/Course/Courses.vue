<template>
  <div>
      <div class="row">
          <div class="col-md-12">
                <add-edit :item="itemToAdd">
                </add-edit>
              <div class="col-md-3">
                  <button type="submit" class="btn btn-info btn-fill btn-wd" style='margin-top: 25px;' @click.prevent="add">Add</button>
              </div>
          </div>
      </div>
      <div class="row">
          <div class="col-md-12">
              <div class="card" v-loading="loading">
                  <paper-table type="hover" 
                               :title="title" 
                               :sub-title="subTitle" 
                               :data="courses" 
                               :columns="columns"
                               :columnsToDisplay="columnsToDisplay">
                    <th slot="actionHeader">Actions</th>
                    <template slot="actionButtons" slot-scope="{ item }">
                        <td>
                            <button type="submit" 
                                    class="btn btn-sm btn-fill ti-pencil" 
                                    @click.prevent="showEditModal(item)">
                                Edit
                            </button>
                            <button type="submit"
                                    class="btn btn-sm btn-fill ti-trash"
                                    @click.prevent="showDeleteModal(item)">
                                Delete
                            </button>
                        </td>
                    </template>
                  </paper-table>
              </div>
          </div>
      </div>
      <div>
          <row-modal :action="action"
                     :message="message"
                     :show="editShow"
                     @close="editShow=false"
                     @executeAction="edit(itemToEdit)">
                <template slot="slotedModalBody">
                    <add-edit :item="itemToEdit">
                    </add-edit>
                </template>
          </row-modal>
          <row-modal :action="action"
                     :message="message"
                     :show="deleteShow"
                     @close="deleteShow=false"
                     @executeAction="removeitem(itemToDelete)">
              <template slot="slotedModalBody">
                  <paper-table :data="itemToDelete" :columns="columns">
                  </paper-table>
              </template>
          </row-modal>
      </div>
  </div>
</template>
<script>
    import addEdit from './addEdit.vue'
    import { mapState, mapActions } from 'vuex'

    const tableColumns = ['ClassId', 'ClassName', 'Division']
    const tableColumnsToDisplay = ['Id', 'Course Name', 'Division']
    const deleteMessage = 'Are you sure want to delete?'
    const editMessage = 'Please edit following'

    let itemToAdd = {
      ClassName: '',
      Division: ''
    }
export default {
  components: {
        addEdit
  },
  data () {
        return {
          title: 'Avilable Courses',
          subTitle: 'All courses in system are list here.',
          columns: [...tableColumns],
          columnsToDisplay: [...tableColumnsToDisplay],
          itemToAdd: itemToAdd,
          editShow: false,
          deleteShow: false,
          itemToEdit: {},
          itemToDelete: {},
          action: '',
          message: '',
          rowToDispaly: {}
        }
  },
      computed: mapState({
        courses: state => state.course.courses,
        loading: state => state.course.loading
      }),
      methods: {
        ...mapActions('course', ['loadAllCourses', 'addCourse', 'deleteCourse', 'editCourse']),
        add () {
          this.addCourse(this.itemToAdd).then(result => {
            if (result === 'success') { this.itemToAdd = {} }
            this.$notifications.showSaved('Course', 'add', result)
          })
        },
        removeitem (item) {
          if (item) {
            let itemToRemoveId = JSON.parse(JSON.stringify(item))[0].ClassId
            this.deleteCourse(itemToRemoveId).then(result => {
              this.$notifications.showSaved('Course', 'delete', result)
            })
            this.deleteShow = false
          }
        },
        edit (item) {
          if (item) {
            this.editCourse(item).then(result => {
              this.$notifications.showSaved('Course', 'edit', result)
            })
            this.editShow = false
          }
        },
        showDeleteModal (item) {
          this.action = 'Delete Course'
          this.message = deleteMessage
          let arr = []
          arr[0] = item
          this.itemToDelete = arr
          this.deleteShow = true
        },
        showEditModal (item) {
          this.action = 'Edit Course'
          this.message = editMessage
          this.itemToEdit = item
          this.editShow = true
        }
      },
      created () {
        this.$store.dispatch('course/loadAllCourses')
      }
}
</script>
<style>
.btn {
    
}
</style>

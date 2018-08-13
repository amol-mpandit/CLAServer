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
                               :data="subjects" 
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

    const tableColumns = ['SubId', 'Name', 'Code', 'ClassNameToDisplay']
    const tableColumnsToDisplay = ['Id', 'Subject Name', 'Code', 'ClassNameToDisplay']
    const deleteMessage = 'Are you sure want to delete?'
    const editMessage = 'Please edit following'

export default {
  components: {
        addEdit
  },
  data () {
        return {
          title: 'Avilable Subjects',
          subTitle: 'All Subjects in system are list here.',
          columns: [...tableColumns],
          columnsToDisplay: [...tableColumnsToDisplay],
          itemToAdd: {},
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
        subjects: state => state.subject.subjects,
        loading: state => state.student.loading
      }),
      methods: {
        ...mapActions('subject', ['loadAllSubjects', 'addSubject', 'deleteSubject', 'editSubject']),
        add () {
          this.addSubject(this.itemToAdd).then(result => {
            if (result === 'success') { this.itemToAdd = {} }
            this.$notifications.showSaved('Subject', 'add', result)
          })
        },
        removeitem (item) {
          if (item) {
            let itemToRemoveId = JSON.parse(JSON.stringify(item))[0].SubId
            this.deleteSubject(itemToRemoveId).then(result => {
              this.$notifications.showSaved('Subject', 'delete', result)
            })
            this.deleteShow = false
          }
        },
        edit (item) {
          if (item) {
            this.editSubject(item).then(result => {
              this.$notifications.showSaved('Subject', 'edit', result)
            })
            this.editShow = false
          }
        },
        showDeleteModal (item) {
          this.action = 'Delete Subject'
          this.message = deleteMessage
          let arr = []
          arr[0] = item
          this.itemToDelete = arr
          this.deleteShow = true
        },
        showEditModal (item) {
          this.action = 'Edit subject'
          this.message = editMessage
          this.itemToEdit = item
          this.editShow = true
        }
      },
      created () {
        this.$store.dispatch('subject/loadAllSubjects')
      }
}
</script>
<style>
.btn {
    
}
</style>

<template>
    <div v-if="show" transition="modal">
        <div class="modal-mask">
            <div class="modal-wrapper">
                <div class="modal-container">
                    <div v-if="!hideTitle" class="modal-header">
                        <div class="float-left">{{action}}
                            <button class="btn btn-sm btn-fill ti-close float-right" @click.prevent="close">
                            </button>
                       </div>
                    </div>
                    <div class="modal-body">
                        <div class="header">
                            <h4 class="title">{{action}}</h4>
                            <p class="category">{{message}}</p>
                        </div>
                        <slot name="slotedModalBody">Modal body is empty</slot>
                    </div>
                    <div class="modal-footer">
                      <button class="btn btn-sm btn-fill float-left" @click.prevent="close">Close</button>
                      <button class="btn btn-sm btn-fill float-right" @click.prevent="execute">{{action}}</button>
                    </div>
                </div>
            </div>
        </div>
      </div>
</template>

<script>
  import PaperTable from './PaperTable.vue'
  export default {
    components: {
      PaperTable
    },
    props: {
      action: '',
      message: '',
      show: false,
      hideTitle: {
        type: Boolean,
        default: false
      }
    },
    methods: {
      execute () {
        this.$emit('executeAction')
      },
      close () {
        this.$emit('close')
      }
    }
  }
</script>
<style>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, .5);
  display: table;
  transition: opacity .3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-container {
  width: 50%;
  margin: 0px auto;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, .33);
  transition: all .3s ease;
  font-family: Helvetica, Arial, sans-serif;
  flex-flow: column;
}

.modal-header h3 {
  margin-top: 0;
  color: #42b983;
}

.modal-body {
  margin: 20px 0;
}

.modal-default-button {
  float: right;
}

/*
 * The following styles are auto-applied to elements with
 * transition="modal" when their visibility is toggled
 * by Vue.js.
 *
 * You can easily play with the modal transition by editing
 * these styles.
 */

.modal-enter {
  opacity: 0;
}

.modal-leave-active {
  opacity: 0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}
</style>

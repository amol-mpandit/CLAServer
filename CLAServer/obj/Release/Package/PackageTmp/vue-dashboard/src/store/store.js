import state from './state'
import actions from './actions'
import mutations from './mutations'

class store {
  constructor () {
    this.state = Object.assign({}, state)
    this.actions = Object.assign({}, actions)
    this.mutations = Object.assign({}, mutations)
    this.modules = {}
  }
}

export default store

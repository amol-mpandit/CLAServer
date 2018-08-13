<template>
    <div v-model="item">
        <div class="col-md-2">
            <fg-input type="text"
                        label="Faculty Id"
                        :disabled="true"
                        placeholder="Automactically Assigned"
                        v-model="item.FId">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="First Name"
                        placeholder="First Name"
                        v-model="item.FirstName">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="Last Name"
                        placeholder="Last Name"
                        v-model="item.LastName">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                      label="Designation"
                      placeholder="Designation"
                      v-model="item.Designation">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="number"
                      label="Phone"
                      placeholder="Phone"
                      v-model="item.Phone">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                      label="Email"
                      placeholder="Email"
                      v-model="item.Email">
            </fg-input>
        </div>
    </div>
</template>

<script>
export default {
  props: {
    item: {}
  }
}
</script>

<style>

</style>

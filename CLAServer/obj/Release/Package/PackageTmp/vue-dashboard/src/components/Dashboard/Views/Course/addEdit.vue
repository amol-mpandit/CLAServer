<template>
    <div v-model="item">
        <div class="col-md-3">
            <fg-input type="text"
                        label="Course Id"
                        :disabled="true"
                        placeholder="Automactically Assigned"
                        v-model="item.ClassId">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="Course Name"
                        placeholder="Course Name"
                        v-model="item.ClassName">
            </fg-input>
        </div>
        <div class="col-md-3">
            <fg-input type="text"
                        label="Division"
                        placeholder="Division"
                        v-model="item.Division">
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

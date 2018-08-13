<template>
  <div class="card card-user" v-model="item">
    <div class="image">
      <img src="static/img/background.jpg" alt="...">
    </div>
    <div class="content">
      <div class="author">
        <img class="avatar border-white" src="static/img/faces/face-2.jpg" alt="...">
        <h4 class="title">
          <span>{{item.FullName}}</span>
          <span></span>
          <br>
          <a href="#">
            <span>Roll No: {{item.RollNo}}</span>
          </a>
        </h4>
      </div>
    </div>
    <hr>
    <div class="text-center">
      <div class="row">
        <div class="col-md-3 col-md-offset-1">
          <h5>Course
            <br>
            <small>{{item.ClassNameToDisplay}}</small>
          </h5>
        </div>
        <div class="col-md-3 col-md-offset-1">
          <h5>Mobile
            <br>
            <small>{{item.Mobile}}</small>
          </h5>
        </div>
        <div class="col-md-3 col-md-offset-1">
          <h5>Home Phone
            <br>
            <small>{{item.HomePhone}}</small>
          </h5>
        </div>
        <div class="col-md-3 col-md-offset-1">
          <h5>Email
            <br>
            <small>{{item.Email}}</small>
          </h5>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
  export default {
    props: {
      item: {}
    },
    methods: {
      getClasses (index) {
        var remainder = index % 3
        if (remainder === 0) {
          return 'col-md-3 col-md-offset-1'
        } else if (remainder === 2) {
          return 'col-md-4'
        } else {
          return 'col-md-3'
        }
      }
    }
  }

</script>
<style>
  
</style>

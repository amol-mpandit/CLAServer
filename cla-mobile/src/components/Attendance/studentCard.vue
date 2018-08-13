<template>
  <el-container :item="item">
    <el-header>
      <h3>Student Profile</h3>
    </el-header>
    <hr>
    <el-main>
      <h4>
        <el-row :span=24>
          <el-col :span=24>
            <span>Name: </span>
            <span>{{item.FullName}}</span>
          </el-col>
        </el-row>
        <el-col :span=12>
            <span>Roll No:</span>
            <span>{{item.RollNo}}</span>
          </el-col>
        <el-row :span=24>
          <el-col :span=12>
          Course:
            <span>{{item.ClassNameToDisplay}}</span>
        </el-col>
        </el-row>
      </h4>
      <el-row :span=24 :gutter=10>
          <el-col :span=12>
            <h5>Mobile</h5>
              <span>{{item.Mobile}}</span>
          </el-col>
          <el-col :span=12>
            <h5>Home Phone</h5>
              <span>{{item.HomePhone}}</span>
          </el-col>
          <el-col :span=24>
            <h5>Email</h5>
              <span>{{item.Email}}</span>
          </el-col>
      </el-row>
    </el-main>
    <hr>
  </el-container>
</template>
<script>
export default {
  props: {
    item: {}
  }
}
</script>
<style>
 .el-header{
    background-color: #b3c0d3;
    color: #333;
    text-align: center;
  }
  .el-main {
    background-color: #E9EEF3;
    color: #333;
    text-align: center;
  }

</style>

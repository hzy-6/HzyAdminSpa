<template>
  <div class="cct-container">
    <div class="left">
      <ul>
        <li v-for="item in 60" :key="item">TableName{{item}}</li>
      </ul>
    </div>
    <div class="center">
      <ul>
        <li v-for="item in 20" :key="item">TableName_Name{{item}}</li>
      </ul>
    </div>
    <div class="right">
      <div class="top">
        <ul>
          <li>Model</li>
          <li>Logic</li>
          <li>Controller</li>
          <li>Form</li>
        </ul>
      </div>
      <div class="content">
        <el-input type="textarea" placeholder="请输入内容" v-model="textarea"></el-input>
        <!-- <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>卡片名称</span>
            <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
          </div>
          <div v-for="o in 4" :key="o" class="text item">{{'列表内容 ' + o }}</div>
        </el-card>-->
      </div>
      <div class="bottom">
        <ul>
          <li>下载所有</li>
          <li>下载当前</li>
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import "../../css/cct.scss";

export default {
  name: "CCT",
  data() {
    return {
      textarea: ""
    };
  }
};
</script>
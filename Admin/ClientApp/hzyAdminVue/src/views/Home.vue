<template>
  <div>
    <el-row :gutter="20">
      <el-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12" class="mb-20">
        <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>V-Charts</span>
            <el-link
              type="success"
              target="_blank"
              href="https://v-charts.js.org"
              style="float: right; padding: 3px 0"
            >查看文档</el-link>
          </div>
          <Charts height="400px" />
        </el-card>
      </el-col>
      <el-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12" class="mb-20">
        <el-card>
          <div slot="header" class="clearfix">
            <span>K 线图</span>
            <el-link
              type="success"
              target="_blank"
              href="https://v-charts.js.org"
              style="float: right; padding: 3px 0"
            >查看文档</el-link>
          </div>
          <Charts1 height="400px" />
        </el-card>
      </el-col>
    </el-row>

    <el-row :gutter="20">
      <el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="mb-20">
        <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>Carousel 走马灯</span>
            <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
          </div>
          <el-carousel :interval="2000" type="card" height="400px">
            <el-carousel-item>
              <img src="../assets/images/login.jpg" alt width="100%" height="100%" />
            </el-carousel-item>
            <el-carousel-item>
              <img src="../assets/images/login1.jpg" alt width="100%" height="100%" />
            </el-carousel-item>
            <el-carousel-item>
              <img src="../assets/images/login2.jpg" alt width="100%" height="100%" />
            </el-carousel-item>
            <el-carousel-item>
              <img src="../assets/images/login3.jpg" alt width="100%" height="100%" />
            </el-carousel-item>
          </el-carousel>
        </el-card>
      </el-col>
    </el-row>

    <el-row :gutter="20">
      <el-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12" class="mb-20">
        <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>Button 按钮</span>
            <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
          </div>
          <el-row class="mb-20">
            <el-button>默认按钮</el-button>
            <el-button type="primary">主要按钮</el-button>
            <el-button type="success">成功按钮</el-button>
            <el-button type="info">信息按钮</el-button>
            <el-button type="warning">警告按钮</el-button>
            <el-button type="danger">危险按钮</el-button>
          </el-row>

          <el-row class="mb-20">
            <el-button plain>朴素按钮</el-button>
            <el-button type="primary" plain>主要按钮</el-button>
            <el-button type="success" plain>成功按钮</el-button>
            <el-button type="info" plain>信息按钮</el-button>
            <el-button type="warning" plain>警告按钮</el-button>
            <el-button type="danger" plain>危险按钮</el-button>
          </el-row>

          <el-row class="mb-20">
            <el-button round>圆角按钮</el-button>
            <el-button type="primary" round>主要按钮</el-button>
            <el-button type="success" round>成功按钮</el-button>
            <el-button type="info" round>信息按钮</el-button>
            <el-button type="warning" round>警告按钮</el-button>
            <el-button type="danger" round>危险按钮</el-button>
          </el-row>

          <el-row>
            <el-button icon="el-icon-search" circle></el-button>
            <el-button type="primary" icon="el-icon-edit" circle></el-button>
            <el-button type="success" icon="el-icon-check" circle></el-button>
            <el-button type="info" icon="el-icon-message" circle></el-button>
            <el-button type="warning" icon="el-icon-star-off" circle></el-button>
            <el-button type="danger" icon="el-icon-delete" circle></el-button>
          </el-row>
        </el-card>
      </el-col>
      <el-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12" class="mb-20">
        <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>Alert</span>
            <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
          </div>
          <el-alert
            title="成功提示的文案"
            type="success"
            description="文字说明文字说明文字说明文字说明文字说明文字说明"
            show-icon
            class="mb-10"
          ></el-alert>
          <el-alert
            title="消息提示的文案"
            type="info"
            description="文字说明文字说明文字说明文字说明文字说明文字说明"
            show-icon
            class="mb-10"
          ></el-alert>
          <el-alert
            title="警告提示的文案"
            type="warning"
            description="文字说明文字说明文字说明文字说明文字说明文字说明"
            show-icon
            class="mb-10"
          ></el-alert>
          <el-alert
            title="错误提示的文案"
            type="error"
            description="文字说明文字说明文字说明文字说明文字说明文字说明"
            show-icon
            class="mb-10"
          ></el-alert>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import axios from "axios";
import Charts from "../components/Charts";
import Charts1 from "../components/Charts1";

export default {
  name: "Home",
  data() {
    return {};
  },
  components: { Charts, Charts1 },
  mounted() {},
  methods: {}
};
</script>
//
<style>
.el-carousel__item h3 {
  color: #475669;
  font-size: 14px;
  opacity: 0.75;
  line-height: 200px;
  margin: 0;
}

.el-carousel__item:nth-child(2n) {
  background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n + 1) {
  background-color: #d3dce6;
}
</style>
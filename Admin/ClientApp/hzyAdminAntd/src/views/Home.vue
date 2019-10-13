<template>
  <div class="home">
    <!-- k 线图 、饼状图 -->
    <a-row :gutter="20" class="mb-20">
      <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12">
        <a-card title="K 线图" :bordered="false">
          <a href="https://v-charts.js.org/#/candle" slot="extra" target="_black">更多</a>
          <div style="    width: 100%;
    position: relative;
    display: inline-block;">
            <Chart1 />
          </div>
          
        </a-card>
      </a-col>
      <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12">
        <a-card title="地图" :bordered="false">
          <a href="https://v-charts.js.org/#/candle" slot="extra" target="_black">更多</a>
          <Chart3 />
        </a-card>
      </a-col>
    </a-row>
    <!-- 地图 -->
    <a-row :gutter="20" class="mb-20">
      <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12">
        <a-card title="饼状图" :bordered="false">
          <a href="https://v-charts.js.org/#/pie" slot="extra" target="_black">更多</a>
          <Chart2 />
        </a-card>
      </a-col>
      <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12">
        <a-card title="日历" :bordered="false">
          <a href="https://v-charts.js.org/#/pie" slot="extra" target="_black">更多</a>
          <div :style="{ width: '100%', border: '1px solid #d9d9d9', borderRadius: '4px' }">
            <a-calendar :fullscreen="false" @panelChange="onPanelChange" />
          </div>
        </a-card>
      </a-col>
    </a-row>
    <!-- Antd Vue 部分展示组件 -->
    <a-row :gutter="20" class="mb-20">
      <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12">
        <a-card title="步骤条" :bordered="false">
          <a href="https://vue.ant.design/components/steps-cn/" slot="extra" target="_black">更多</a>
          <div class="mb-20">
            <a-steps :current="1">
              <a-step>
                <!-- <span slot="title">Finished</span> -->
                <template slot="title">Finished</template>
                <span slot="description">This is a description.</span>
              </a-step>
              <a-step title="In Progress" description="This is a description." />
              <a-step title="Waiting" description="This is a description." />
            </a-steps>
          </div>
          <div>
            <a-steps direction="vertical" size="small" :current="1">
              <a-step title="Finished" description="This is a description." />
              <a-step title="In Progress" description="This is a description." />
              <a-step title="Waiting" description="This is a description." />
            </a-steps>
          </div>
        </a-card>
      </a-col>
      <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12">
        <a-card title="Alert" :bordered="false">
          <a href="https://vue.ant.design/components/alert-cn/" slot="extra" target="_black">更多</a>
          <div>
            <a-alert message="Success Tips" type="success" showIcon />
            <a-alert message="Informational Notes" type="info" showIcon />
            <a-alert message="Warning" type="warning" showIcon />
            <a-alert message="Error" type="error" showIcon />
            <a-alert
              message="Success Tips"
              description="Detailed description and advices about successful copywriting."
              type="success"
              showIcon
            />
            <a-alert
              message="Informational Notes"
              description="Additional description and informations about copywriting."
              type="info"
              showIcon
            />
            <a-alert
              message="Warning"
              description="This is a warning notice about copywriting."
              type="warning"
              showIcon
            />
            <a-alert
              message="Error"
              description="This is an error message about copywriting."
              type="error"
              showIcon
            />
          </div>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script>
import Chart1 from "../components/charts/Chart1";
import Chart2 from "../components/charts/Chart2";
import Chart3 from "../components/charts/Chart3";

export default {
  name: "Home",
  data() {
    return {};
  },
  components: {
    Chart1,
    Chart2,
    Chart3
  },
  mounted() {},
  methods: {
    onPanelChange(value, mode) {
      console.log(value, mode);
    }
  }
};
</script>
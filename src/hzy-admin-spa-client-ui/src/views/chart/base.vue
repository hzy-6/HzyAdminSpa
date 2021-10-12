<template>
  <div class="p-15">
    <a-alert message="图表" type="success">
      <template #description>
        <p>
          <router-link :to="{ name: 'chart_more' }"
            >查看 AntV G2 更多示例</router-link
          >
        </p>
      </template>
    </a-alert>

    <a-row :gutter="[15, 15]" class="pt-15">
      <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
        <a-card hoverable>
          <char1 />
        </a-card>
      </a-col>
      <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
        <a-card hoverable>
          <char2 />
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import char1 from "@/components/chart/index1.vue";
import char2 from "@/components/chart/index2.vue";

export default defineComponent({
  name: "chart_base",
  components: {
    char1,
    char2,
  },
  setup() {
    return {};
  },
});
</script>

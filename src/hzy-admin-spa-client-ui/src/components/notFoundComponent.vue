<template>
  <a-result status="404" title="404" sub-title="对不起，您访问的页面不存在。">
    <template #extra>
      <a-button type="primary" @click="handleBack"> Back Home </a-button>
    </template>
  </a-result>
</template>
<script>
import { defineComponent } from "vue";
export default defineComponent({
  name: "notFoundComponent",
  setup() {
    const handleBack = () => {
      window.history.back();
    };
    return { handleBack };
  },
});
</script>

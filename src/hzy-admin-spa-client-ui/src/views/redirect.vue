<template>
  <div class="p-15">
    <a-spin />
  </div>
</template>
<script>
import { defineComponent } from "vue";
import router from "@/router/index";

export default defineComponent({
  setup() {
    const { params, query } = router.currentRoute.value;
    const { path } = params;
    router.replace({ path: "/" + path, query });
  },
});
</script>

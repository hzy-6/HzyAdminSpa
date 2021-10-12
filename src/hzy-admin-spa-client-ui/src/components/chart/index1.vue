<template>
  <div id="container1"></div>
</template>

<script>
import { defineComponent, onMounted, reactive } from "vue";
import { Chart } from "@antv/g2";

export default defineComponent({
  name: "index1",
  setup() {
    const data = reactive([
      { year: "1951 年", sales: 38 },
      { year: "1952 年", sales: 52 },
      { year: "1956 年", sales: 61 },
      { year: "1957 年", sales: 145 },
      { year: "1958 年", sales: 48 },
      { year: "1959 年", sales: 38 },
      { year: "1960 年", sales: 38 },
      { year: "1962 年", sales: 38 },
    ]);

    /**
     * 初始化 chart
     */
    const chartInit = () => {
      const chartObject = new Chart({
        container: "container1",
        autoFit: true,
        height: 500,
      });

      chartObject.data(data);
      chartObject.scale("sales", {
        nice: true,
      });

      chartObject.tooltip({
        showMarkers: false,
      });
      chartObject.interaction("active-region");

      chartObject.interval().position("year*sales");

      chartObject.render();
    };

    onMounted(() => {
      chartInit();
    });

    return {
      data,
    };
  },
});
</script>

<style scoped></style>

<template>
  <!-- 本组件用于 常用的 增删改查组件 -->
  <div>
    <el-card class="box-card">
      <slot name="tools"></slot>
      <!--表格控件  style="height:calc(100vh - 340px)"  height="100%" -->
      <div>
        <el-table
          v-loading="dataTable.loading"
          ref="table"
          tooltip-effect="dark"
          :data="dataTable.list"
          :row-key="handleRowKey"
          @selection-change="selectionChange"
          @row-click="handleRowClick"
          border
        >
          <!--表格列头 插槽-->
          <slot name="tableCols">
            <el-table-column type="index" width="50px" fixed></el-table-column>
            <el-table-column type="selection" width="50px" fixed :reserve-selection="true"></el-table-column>
            <template v-for="(item,index) in dataTable.cols">
              <el-table-column
                v-if="item.Show"
                :prop="item.ColName"
                :label="item.Title"
                :key="index"
              ></el-table-column>
            </template>
          </slot>
          <!-- 操作列 插槽 -->
          <slot name="tableColsAdd"></slot>
        </el-table>
      </div>
      <!--分页控件-->
      <div class="pt-20 text-center">
        <el-pagination
          background
          layout="prev, pager, next, total, sizes"
          @size-change="sizeChange"
          @current-change="currentChange"
          :current-page="dataTable.currentPage"
          :page-sizes="[20, 100, 500, 1000]"
          :page-size="dataTable.rows"
          :total="dataTable.total"
        ></el-pagination>
      </div>
    </el-card>
    <!--表单信息区域 插槽-->
    <slot name="form"></slot>
  </div>
</template>
<!--脚本-->
<script>
//业务
export default {
  name: "CRUDCom",
  props: {
    //dataTable 表格信息
    dataTable: Object,
    //点击行事件
    rowClick: Function,
    //复选框改变事件
    selectionChange: Function,
    //分页下拉框改变事件
    sizeChange: Function,
    //页码改变事件
    currentChange: Function,
    //每行的 key 值
    rowKey: Function
  },
  data() {
    return {};
  },
  //计算属性
  computed: {},
  mounted() {},
  methods: {
    //获取每行Key
    handleRowKey(row) {
      if (this.rowKey) return this.rowKey();
      return row._ukid;
    },
    handleRowClick(row, column, event) {
      if (this.rowClick) this.rowClick(row, column, event);
    }
  }
};
</script>
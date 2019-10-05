<template>
<!-- 本组件用于 常用的 增删改查组件 -->
  <div>
    <!--检索表单区域 插槽-->
    <el-collapse-transition>
      <el-card class="box-card mb-20" v-show="formSearch.state">
        <slot name="formSearch"></slot>
      </el-card>
    </el-collapse-transition>
    <!--表格区域-->
    <el-card class="box-card" body-style="padding:15px;">
      <slot name="tools"></slot>
      <!--表格控件-->
      <div style="height:calc(100vh - 250px)">
        <el-table
          v-loading="dataTable.loading"
          height="100%"
          ref="table"
          tooltip-effect="dark"
          :data="dataTable.list"
          :row-key="rowKey"
          @selection-change="selectionChange"
          @row-click="rowClick"
        >
          <!--表格列头 插槽-->
          <slot name="tableCols">
            <el-table-column type="index" width="50"></el-table-column>
            <el-table-column type="selection" width="50" :reserve-selection="true"></el-table-column>
            <template v-for="(item,index) in dataTable.cols">
              <el-table-column
                v-if="item.Show"
                :prop="item.ColName"
                :label="item.Title"
                :key="index"
              ></el-table-column>
            </template>
          </slot>
        </el-table>
      </div>
      <!--分页控件-->
      <div class="pt-5">
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
    //formSearch 检索表单状态和模型
    formSearch: Object,
    //dataTable 表格信息
    dataTable: Object,
    //返回行key
    rowKey: Function,
    //点击行事件
    rowClick: Function,
    //复选框改变事件
    selectionChange: Function,
    //分页下拉框改变事件
    sizeChange: Function,
    //页码改变事件
    currentChange: Function
  },
  data() {
    return {};
  },
  //计算属性
  computed: {},
  mounted() {},
  methods: {}
};
</script>
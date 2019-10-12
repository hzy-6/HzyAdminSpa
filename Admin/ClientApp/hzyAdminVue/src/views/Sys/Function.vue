<template>
  <div>
    <!--检索表单区域-->
    <el-collapse-transition>
      <el-card class="box-card mb-20" v-show="formSearch.state">
        <h4>检索</h4>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-input v-model="formSearch.vm.Function_Name" placeholder="请输入 功能名称"></el-input>
          </el-col>
        </el-row>
        <div>
          <el-button type="primary" plain @click="findList">检索</el-button>
          <el-button type="primary" plain @click="resetSearch();findList()">重置</el-button>
          <el-button type="danger" plain @click="formSearch.state=false">关闭</el-button>
        </div>
      </el-card>
    </el-collapse-transition>
    <!--表格区域-->
    <el-card class="box-card" body-style="padding:15px;">
      <el-row :gutter="20">
        <el-col :xs="24" :sm="24" :md="18" :lg="18" :xl="18" class="pb-5">
          <el-button
            type="primary"
            icon="el-icon-plus"
            v-if="power.Insert"
            @click="loadForm('add');"
          >添加</el-button>
          <el-button
            type="primary"
            icon="el-icon-edit"
            v-if="power.Update"
            @click="loadForm('update');"
            :disabled="!buttonState.update"
          >查看/编辑</el-button>
          <el-button
            type="danger"
            icon="el-icon-delete"
            v-if="power.Delete"
            @click="_remove"
            :disabled="!buttonState.delete"
          >删除</el-button>
          <el-button
            type="primary"
            icon="el-icon-search"
            v-if="power.Search"
            @click="formSearch.state=!formSearch.state"
          >检索(收/展)</el-button>
        </el-col>
        <el-col :xs="24" :sm="24" :md="6" :lg="6" :xl="6" class="pb-5 text-right">
          <el-button type="primary" icon="el-icon-document">&nbsp;导出 Excel</el-button>
          <el-button type="primary" icon="el-icon-printer">&nbsp;打印</el-button>
        </el-col>
      </el-row>
      <div style="height:calc(100vh - 250px)">
        <el-table
          v-loading="dataTable.loading"
          height="100%"
          ref="table"
          tooltip-effect="dark"
          :data="dataTable.list"
          :row-key="_getRowKey"
          @selection-change="selectionChange"
          @row-click="_rowClick"
        >
          <el-table-column type="index" width="50"></el-table-column>
          <el-table-column type="selection" width="50" :reserve-selection="true"></el-table-column>
          <template v-for="(item,index) in dataTable.cols">
            <el-table-column v-if="item.Show" :prop="item.ColName" :label="item.Title" :key="index"></el-table-column>
          </template>
        </el-table>
      </div>
      <div class="pt-5">
        <el-pagination
          background
          layout="prev, pager, next, total, sizes"
          @size-change="_sizeChange"
          @current-change="findList"
          :current-page="dataTable.currentPage"
          :page-sizes="[20, 100, 500, 1000]"
          :page-size="dataTable.rows"
          :total="dataTable.total"
        ></el-pagination>
      </div>
    </el-card>
    <!--表单信息区域-->
    <el-dialog
      :close-on-click-modal="false"
      :title.sync="form.vm.Id?'编辑/查看':'添加'"
      :visible.sync="form.state"
      top="5vh"
      width="400px"
      center
      custom-class="hzy-w90"
    >
      <div>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
            <h4>编号</h4>
            <el-input v-model="form.vm.Function_Num" type="number"></el-input>
          </el-col>
          <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
            <h4>功能名称</h4>
            <el-input v-model="form.vm.Function_Name"></el-input>
          </el-col>
          <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
            <h4>功能别名</h4>
            <el-input v-model="form.vm.Function_ByName"></el-input>
          </el-col>
        </el-row>
      </div>
      <span slot="footer" class="dialog-footer">
        <el-button type="primary" @click="save" v-if="power.Save">提交</el-button>
        <el-button @click="form.state=false">取消</el-button>
      </span>
    </el-dialog>
  </div>
</template>
<!--脚本-->
<script>
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
var _controllerName = "Function";
//components
//业务
export default {
  name: _controllerName,
  props: {
    findBackCall: Function
  },
  data() {
    return {
      grid: 24,
      power: global.$power
    };
  },
  //components: {  },
  //计算属性
  computed: {
    ...mapState(_controllerName + "_Vuex", {
      //buttonState 按钮状态
      buttonState: state => state.buttonState,
      //formSearch 检索表单状态和模型
      formSearch: state => state.formSearch,
      //dataTable 表格信息
      dataTable: state => state.dataTable,
      //form 编辑表单状态和模型
      form: state => state.form
    })
  },
  mounted() {
    //元素创建完成
    this.init();
  },
  methods: {
    //获取数据
    ...mapActions(_controllerName + "_Vuex", {
      findList: "findList",
      //加载表单
      loadForm: "loadForm",
      //保存表单数据
      save: "save",
      //移除数据
      remove: "remove"
    }),
    //状态管理事件
    ...mapMutations(_controllerName + "_Vuex", {
      //勾选复选框改变事件
      selectionChange: "selectionChange",
      //重置检索文本框
      resetSearch: "resetSearch"
    }),
    init() {
      //初始化表单
      this.loadForm();
      //加载数据列表
      this.findList();
      //这里是解决页面切换 导致 按钮状态无法变更
      var _table = this.$refs.table;
      this.$nextTick(() => {
        _table.clearSelection();
        this.selectionChange([]);
      });
    },
    //获取每行Key
    _getRowKey(row) {
      return row._ukid;
    },
    //点击表格行数据
    _rowClick(row, column, event) {
      var _table = this.$refs.table;
      _table.clearSelection();
      _table.toggleRowSelection(row);
    },
    //分页 每页显示条数 改变事件
    _sizeChange(size) {
      this.dataTable.rows = size;
      this.findList();
    },
    //删除数据
    _remove() {
      var _this = this;
      var _table = this.$refs.table;
      this.remove(function() {
        _table.clearSelection();
      });
    }
  }
};
</script>
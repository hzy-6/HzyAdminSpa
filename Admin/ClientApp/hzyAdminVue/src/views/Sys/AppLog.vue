
<template>
  <div>
    <CRUDCom
      ref="refCRUDCom"
      :formSearch="formSearch"
      :dataTable="dataTable"
      :rowKey="_getRowKey"
      :rowClick="_rowClick"
      :selectionChange="selectionChange"
      :sizeChange="_sizeChange"
      :currentChange="findList"
    >
      <!-- 检索 -->
      <div slot="formSearch">
        <h4>检索</h4>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-input v-model="formSearch.vm.AppLog_Api" placeholder="请输入 Api"></el-input>
          </el-col>
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-input v-model="formSearch.vm.AppLog_IP" placeholder="请输入 IP"></el-input>
          </el-col>
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-input v-model="formSearch.vm.AppLog_Parameter" placeholder="请输入 参数"></el-input>
          </el-col>
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-date-picker
              v-model="formSearch.vm.AppLog_CreateTime"
              type="daterange"
              range-separator="至"
              start-placeholder="开始日期"
              end-placeholder="结束日期"
            ></el-date-picker>
          </el-col>
        </el-row>
        <div>
          <el-button type="primary" plain @click="findList">检索</el-button>
          <el-button type="primary" plain @click="resetSearch();findList()">重置</el-button>
          <el-button type="danger" plain @click="formSearch.state=false">关闭</el-button>
        </div>
      </div>
      <!-- 工具栏 -->
      <div slot="tools">
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
          <!-- <el-col :xs="24" :sm="24" :md="6" :lg="6" :xl="6" class="pb-5 text-right">
            <el-button type="primary" icon="el-icon-document">&nbsp;导出 Excel</el-button>
            <el-button type="primary" icon="el-icon-printer">&nbsp;打印</el-button>
          </el-col>-->
        </el-row>
      </div>
      <!-- 表单 -->
      <div slot="form">
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
                <h4>Api</h4>
                <el-input v-model="form.vm.AppLog_Api" :disabled="true"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>IP</h4>
                <el-input v-model="form.vm.AppLog_IP" :disabled="true"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>操作人</h4>
                <el-input v-model="form.vm.UserName" :disabled="true"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>参数</h4>
                <el-input
                  type="textarea"
                  v-model="form.vm.AppLog_Parameter"
                  :disabled="true"
                  :rows="10"
                ></el-input>
              </el-col>
            </el-row>
          </div>
          <span slot="footer" class="dialog-footer">
            <!-- <el-button type="primary" @click="save" v-if="power.Save">提交</el-button> -->
            <el-button @click="form.state=false">取消</el-button>
          </span>
        </el-dialog>
      </div>
    </CRUDCom>
  </div>
</template>
<!--脚本-->
<script>
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
var _controllerName = "AppLog";
//components
import CRUDCom from "../../components/CRUD";
//业务
export default {
  name: _controllerName,
  data() {
    return {
      grid: 24,
      power: global.$power
    };
  },
  components: {
    CRUDCom
  },
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
  activated() {
    //缓存页面被激活后此函数会被调用
    //加载数据列表
    this.findList();
  },
  mounted() {
    //元素创建完成
    this.init();
  },
  methods: {
    //获取数据
    ...mapActions(_controllerName + "_Vuex", {
      //查询列表
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
      var _table = this.$refs.refCRUDCom.$refs.table;
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
      var _table = this.$refs.refCRUDCom.$refs.table;
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
      var _table = this.$refs.refCRUDCom.$refs.table;
      this.remove(function() {
        _table.clearSelection();
      });
    }
  }
};
</script>
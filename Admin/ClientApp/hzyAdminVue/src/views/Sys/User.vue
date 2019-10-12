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
      <template slot="formSearch">
        <h4>检索</h4>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-input v-model="formSearch.vm.User_Name" placeholder="请输入 用户名称"></el-input>
          </el-col>
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-input v-model="formSearch.vm.User_LoginName" placeholder="请输入 登录名称"></el-input>
          </el-col>
        </el-row>
        <div>
          <el-button type="primary" plain @click="findList">检索</el-button>
          <el-button type="primary" plain @click="resetSearch();findList()">重置</el-button>
          <el-button type="danger" plain @click="formSearch.state=false">关闭</el-button>
        </div>
      </template>
      <!-- 工具栏 -->
      <template slot="tools">
        <el-row :gutter="20">
          <el-col :xs="24" :sm="24" :md="18" :lg="18" :xl="18" class="pb-5">
            <el-button type="primary" icon="el-icon-plus" v-if="power.Insert" @click="loadForm('add');">添加</el-button>
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
      </template>
      <!-- 表格 表头插槽 -->
      <!-- <div slot="tableCols"></div> -->
      <!-- 表单 -->
      <template slot="form">
        <el-dialog
          :close-on-click-modal="false"
          :title.sync="form.vm.Id?'编辑/查看':'添加'"
          :visible.sync="form.state"
          top="5vh"
          width="800px"
          center
          custom-class="hzy-w90"
        >
          <div>
            <el-row :gutter="20">
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>用户名</h4>
                <el-input v-model="form.vm.User_Name"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>登录名称</h4>
                <el-input v-model="form.vm.User_LoginName"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>登录密码</h4>
                <el-input v-model="form.vm.User_Pwd" type="password"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                <h4>邮箱地址</h4>
                <el-input v-model="form.vm.User_Email"></el-input>
              </el-col>
              <el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24">
                <h4>请选择角色</h4>
                <el-checkbox-group v-model="form.vm.RoleIds">
                  <el-checkbox
                    v-for="(item,index) in form.vm.AllRoleList"
                    :label="item.Role_ID"
                    :key="index"
                  >{{item.Role_Name}}</el-checkbox>
                </el-checkbox-group>
              </el-col>
            </el-row>
          </div>
          <span slot="footer" class="dialog-footer">
            <el-button type="primary" @click="save" v-if="power.Save">提交</el-button>
            <el-button @click="form.state=false">取消</el-button>
          </span>
        </el-dialog>
      </template>
    </CRUDCom>
  </div>
</template>
<!--脚本-->
<script>
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
var _controllerName = "User";
//components
import CRUDCom from "../../components/CRUD";
import RoleCom from "./Role";
//业务
export default {
  name: _controllerName,
  data() {
    return {
      grid: 12,
      power: global.$power
    };
  },
  components: {
    CRUDCom,
    RoleCom
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
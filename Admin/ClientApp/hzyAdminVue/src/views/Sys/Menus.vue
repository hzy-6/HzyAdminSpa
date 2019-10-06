<template>
  <div>
    <el-row :gutter="20">
      <el-col :xs="24" :sm="24" :md="5" :lg="5" :xl="5">
        <el-card :body-style="{ height:'calc(100vh - 245px)','overflow-y':'auto' }">
          <div slot="header" class="clearfix">
            <span>菜单树</span>
            <el-button
              style="float: right; padding: 3px 0"
              type="text"
              @click="formSearch.vm.Menu_ID=null;findList();getTree()"
            >查看一级菜单</el-button>
          </div>
          <el-tree
            :data="tree.tree"
            show-checkbox
            node-key="id"
            :default-expanded-keys="tree.defaultExpandedKeys"
            :default-checked-keys="tree.defaultCheckedKeys"
            @node-click="_nodeClick"
            :expand-on-click-node="false"
          ></el-tree>
        </el-card>
      </el-col>
      <el-col :xs="24" :sm="24" :md="19" :lg="19" :xl="19">
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
                <el-input v-model="formSearch.vm.Menu_Name" placeholder="请输入 菜单名称"></el-input>
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
          </template>
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
                    <h4>编号</h4>
                    <el-input v-model="form.vm.Menu_Num"></el-input>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>名称</h4>
                    <el-input v-model="form.vm.Menu_Name"></el-input>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>地址</h4>
                    <el-input v-model="form.vm.Menu_Url"></el-input>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>图标</h4>
                    <el-input v-model="form.vm.Menu_Icon"></el-input>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>是否显示</h4>
                    <el-switch
                      v-model="form.vm.Menu_IsShow"
                      active-text="是"
                      inactive-text="否"
                      :active-value="1"
                      :inactive-value="2"
                    ></el-switch>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24">
                    <h4>功能</h4>
                    <el-checkbox-group v-model="form.vm.FunctionIds">
                      <el-checkbox
                        v-for="(item,index) in form.vm.AllFunctionList"
                        :label="item.Function_ID"
                        :key="index"
                      >{{item.Function_Name}}</el-checkbox>
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
      </el-col>
    </el-row>
  </div>
</template>
<!--脚本-->
<script>
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
var _controllerName = "Menus";
//components
import CRUDCom from "../../components/CRUD";
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
      form: state => state.form,
      //树
      tree: state => state.tree
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
      remove: "remove",
      //
      getTree: "getTree"
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
      //
      this.getTree();
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
    },
    //
    _nodeClick(p1, p2, p3) {
      //console.log(p1, p2, p3);
      this.formSearch.vm.Menu_ID = p1.id;
      this.findList();
    }
  }
};
</script>
<template>
  <div>
    <CRUDCom
      ref="refCRUDCom"
      :dataTable="dataTable"
      :selectionChange="selectionChange"
      :sizeChange="sizeChange"
      :currentChange="findList"
    >
      <!-- 检索、 工具栏 -->
      <template slot="tools">
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
          <div v-show="formSearch.state">
            <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
              <el-date-picker
                v-model="formSearch.vm.AppLog_CreateTime"
                type="daterange"
                range-separator="至"
                start-placeholder="开始日期"
                end-placeholder="结束日期"
              ></el-date-picker>
            </el-col>
          </div>
          <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
            <el-button type="primary" @click="findList">检 索</el-button>
            <el-button @click="resetSearch();findList()">重 置</el-button>
            <el-link
              class="ml-10"
              icon="el-icon-plus"
              v-show="!formSearch.state"
              @click="formSearch.state=true"
            >展开</el-link>
            <el-link
              class="ml-10"
              icon="el-icon-minus"
              v-show="formSearch.state"
              @click="formSearch.state=false"
            >收起</el-link>
          </el-col>
        </el-row>
        <el-row :gutter="20">
          <el-col :xs="24" :sm="24" :md="18" :lg="18" :xl="18" class="pb-20">
            <!-- <el-button type="primary" @click="loadForm();" v-if="power.Insert">新 建</el-button> -->
            <el-button type="danger" plain @click="remove()" v-if="power.Delete">批量删除</el-button>
          </el-col>
          <el-col :xs="24" :sm="24" :md="6" :lg="6" :xl="6" class="pb-20 text-right">
            <el-button icon="el-icon-document">导 出 Excel</el-button>
            <el-button icon="el-icon-printer">打 印</el-button>
          </el-col>
        </el-row>
      </template>
      <!-- 表格 表头插槽 -->
      <!-- <div slot="tableCols"></div> -->
      <div slot="tableColsAdd">
        <!-- 添加操作列插槽 -->
        <el-table-column label="操作" fixed="right" width="160px">
          <template slot-scope="prop">
            <div>
              <el-button type="primary" @click="loadForm(prop.row._ukid);" v-if="power.Update">编 辑</el-button>
              <el-button type="danger" plain @click="remove(prop.row._ukid)" v-if="power.Delete">删 除</el-button>
            </div>
          </template>
        </el-table-column>
      </div>
      <!-- 表单 -->
      <template slot="form">
        <el-dialog
          :close-on-click-modal="false"
          :title.sync="form.vm.Id?'编辑/查看':'添加'"
          :visible.sync="form.state"
          top="20px"
          width="400px"
          center
          custom-class="hzy-w90"
        >
          <div>
            <el-form label-position="top" :model="form.vm">
              <el-row :gutter="20">
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="Api">
                    <el-input v-model="form.vm.AppLog_Api" placeholder="请输入 Api"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="IP">
                    <el-input v-model="form.vm.AppLog_IP" :disabled="true"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="操作人">
                    <el-input v-model="form.vm.UserName" :disabled="true"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="备注">
                    <el-input
                      type="textarea"
                      v-model="form.vm.AppLog_Parameter"
                      :disabled="true"
                      :rows="10"
                    ></el-input>
                  </el-form-item>
                </el-col>
              </el-row>
            </el-form>
          </div>
          <span slot="footer" class="dialog-footer">
            <!-- <el-button type="primary" @click="save" v-if="power.Save">提交</el-button> -->
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
  created() {
    //加载数据列表
    this.findList();
  },
  mounted() {
    //元素创建完成
    // this.init();
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
      resetSearch: "resetSearch",
      //分页下拉框行数改变
      sizeChange: "sizeChange"
    }),
    init() {
      //加载数据列表
      // this.findList();
      //这里是解决页面切换 导致 按钮状态无法变更
      // var _table = this.$refs.refCRUDCom.$refs.table;
      // this.$nextTick(() => {});
    }
  }
};
</script>
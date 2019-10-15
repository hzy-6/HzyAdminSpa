<template>
  <div>
    <el-card class="box-card">
      <el-row :gutter="20">
        <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
          <el-input v-model="formSearch.vm.Function_Name" placeholder="请输入 功能名称"></el-input>
        </el-col>
        <el-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="mb-20">
          <el-button type="primary" @click="findList">检 索</el-button>
          <el-button @click="resetSearch();findList()">重 置</el-button>
          <!-- <el-link
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
          >收起</el-link>-->
        </el-col>
      </el-row>
      <el-row :gutter="20">
        <el-col :xs="24" :sm="24" :md="18" :lg="18" :xl="18" class="pb-20">
          <el-button type="primary" @click="loadForm();" v-if="power.Insert">新 建</el-button>
          <el-button type="danger" plain @click="remove()" v-if="power.Delete">批量删除</el-button>
        </el-col>
        <el-col :xs="24" :sm="24" :md="6" :lg="6" :xl="6" class="pb-20 text-right">
          <el-button icon="el-icon-document">导 出 Excel</el-button>
          <el-button icon="el-icon-printer">打 印</el-button>
        </el-col>
      </el-row>
      <!--表格控件  style="height:calc(100vh - 340px)"  height="100%" -->
      <div>
        <el-table
          v-loading="dataTable.loading"
          ref="table"
          tooltip-effect="dark"
          :data="dataTable.list"
          :row-key="rowKey"
          @selection-change="selectionChange"
          border
        >
          <!--表格列头 插槽-->
          <el-table-column type="index" width="50px" fixed></el-table-column>
          <el-table-column type="selection" width="50px" fixed :reserve-selection="true"></el-table-column>
          <template v-for="(item,index) in dataTable.cols">
            <el-table-column v-if="item.Show" :prop="item.ColName" :label="item.Title" :key="index"></el-table-column>
          </template>
          <el-table-column label="操作" fixed="right" width="160px">
            <template slot-scope="prop">
              <div>
                <el-button type="primary" @click="loadForm(prop.row._ukid);" v-if="power.Update">编 辑</el-button>
                <el-button
                  type="danger"
                  plain
                  @click="remove(prop.row._ukid)"
                  v-if="power.Delete"
                >删 除</el-button>
              </div>
            </template>
          </el-table-column>
        </el-table>
      </div>
      <!--分页控件-->
      <div class="pt-20 text-center">
        <el-pagination
          background
          layout="prev, pager, next, total, sizes"
          @size-change="sizeChange"
          @current-change="findList"
          :current-page="dataTable.currentPage"
          :page-sizes="[20, 100, 500, 1000]"
          :page-size="dataTable.rows"
          :total="dataTable.total"
        ></el-pagination>
      </div>
    </el-card>
    <!--表单信息区域 插槽-->
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
        <el-form label-position="top" :model="form.vm">
          <el-row :gutter="20">
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <el-form-item label="编号">
                <el-input v-model="form.vm.Function_Num" type="number"></el-input>
              </el-form-item>
            </el-col>
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <el-form-item label="功能名称">
                <el-input v-model="form.vm.Function_Name"></el-input>
              </el-form-item>
            </el-col>
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <el-form-item label="功能别名">
                <el-input v-model="form.vm.Function_ByName"></el-input>
              </el-form-item>
            </el-col>
            <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
              <el-form-item label="备注">
                <el-input type="textarea" v-model="form.vm.Role_Remark"></el-input>
              </el-form-item>
            </el-col>
          </el-row>
        </el-form>
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
      // var _table = this.$refs.table;
    },
    //获取每行Key
    rowKey(row) {
      return row._ukid;
    },
  }
};
</script>
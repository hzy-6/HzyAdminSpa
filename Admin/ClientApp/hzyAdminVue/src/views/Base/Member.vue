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
            <el-input v-model="formSearch.vm.Member_Name" placeholder="请输入 会员名称"></el-input>
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
      </template>
      <!-- 表格 表头插槽 -->
      <template slot="tableCols">
        <el-table-column type="index" width="50px" fixed></el-table-column>
        <el-table-column type="selection" width="50" fixed :reserve-selection="true"></el-table-column>
        <template v-for="(item,index) in dataTable.cols">
          <template v-if="item.ColName=='Member_Photo'">
            <el-table-column :label="item.Title" :key="index">
              <template slot-scope="scope">
                <el-avatar :src="scope.row.Member_Photo"></el-avatar>
              </template>
            </el-table-column>
          </template>
          <template v-else>
            <el-table-column v-if="item.Show" :prop="item.ColName" :label="item.Title" :key="index"></el-table-column>
          </template>
        </template>
      </template>
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
          top="5vh"
          width="1200px"
          center
          custom-class="hzy-w90"
        >
          <div>
            <el-form label-position="top" :model="form.vm">
              <el-row :gutter="20">
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="头像">
                    <UploadImageCom ref="ref_Member_Photo" :imageUrl.sync="form.vm.Member_Photo" />
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="编号">
                    <el-input v-model="form.vm.Member_Num"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="会员名称">
                    <el-input v-model="form.vm.Member_Name"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="联系电话">
                    <el-input v-model="form.vm.Member_Phone" type="number"></el-input>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="生日">
                    <el-date-picker
                      v-model="form.vm.Member_Birthday"
                      type="date"
                      style="width:100%"
                    ></el-date-picker>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="性别">
                    <el-radio-group v-model="form.vm.Member_Sex" class="mt-10 mb-10">
                      <el-radio label="男">男</el-radio>
                      <el-radio label="女">女</el-radio>
                    </el-radio-group>
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                  <el-form-item label="文件">
                    <UploadFilesCom
                      ref="ref_Member_FilePath"
                      :imageUrl.sync="form.vm.Member_FilePath"
                    />
                  </el-form-item>
                </el-col>
                <el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24">
                  <el-form-item label="介绍">
                    <EditorCom :text.sync="form.vm.Member_Introduce" />
                  </el-form-item>
                </el-col>
              </el-row>
            </el-form>
          </div>
          <span slot="footer" class="dialog-footer">
            <el-button type="primary" @click="_save" v-if="power.Save">提交</el-button>
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
var _controllerName = "Member";
//components
import CRUDCom from "../../components/CRUD";
import UploadImageCom from "../../components/upload/Image";
import UploadFilesCom from "../../components/upload/Files";
import EditorCom from "../../components/Editor";
//业务
export default {
  name: _controllerName,
  data() {
    return {
      grid: 8,
      power: global.$power
    };
  },
  components: {
    CRUDCom,
    UploadImageCom,
    UploadFilesCom,
    EditorCom
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
      resetSearch: "resetSearch",
      //分页下拉框行数改变
      sizeChange: "sizeChange"
    }),
    init() {
      //加载数据列表
      // this.findList();
      //这里是解决页面切换 导致 按钮状态无法变更
      // var _table = this.$refs.refCRUDCom.$refs.table;
    },
    _save() {
      //对文件处理
      var file = this.$refs.ref_Member_Photo.upfile;
      var files = this.$refs.ref_Member_FilePath.upfile;
      // console.log(files,this.form.vm);
      this.save(_FormData => {
        if (file) _FormData.append("Member_Photo_Files", file.raw);
        if (files.length > 0) {
          for (var i = 0; i < files.length; i++) {
            var item = files[i];
            console.log(item);
            _FormData.append("Member_FilePath_Files", item.raw);
          }
        }
      });
    }
  }
};
</script>
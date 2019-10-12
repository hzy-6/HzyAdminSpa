  <template>
  <div>
    <el-row :gutter="20">
      <el-col :xs="24" :sm="24" :md="10" :lg="10" :xl="10">
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
                <el-input v-model="formSearch.vm.Role_Name" placeholder="请输入 角色名称"></el-input>
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
                  icon="el-icon-search"
                  v-if="power.Search"
                  @click="formSearch.state=!formSearch.state"
                >检索(收/展)</el-button>
              </el-col>
            </el-row>
          </template>
          <!-- 表单 -->
          <!-- <template slot="form">
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
                <el-row :gutter="20">
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>编号</h4>
                    <el-input v-model="form.vm.Role_Num" type="number"></el-input>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>角色名称</h4>
                    <el-input v-model="form.vm.Role_Name"></el-input>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>是否可删除</h4>
                    <el-radio-group v-model="form.vm.Role_IsDelete">
                      <el-radio :label="1">是</el-radio>
                      <el-radio :label="2">否</el-radio>
                    </el-radio-group>
                  </el-col>
                  <el-col :xs="24" :sm="24" :md="grid" :lg="grid" :xl="grid">
                    <h4>备注</h4>
                    <el-input type="textarea" v-model="form.vm.Role_Remark"></el-input>
                  </el-col>
                </el-row>
              </div>
              <span slot="footer" class="dialog-footer">
                <el-button type="primary" @click="save">提交</el-button>
                <el-button @click="form.state=false">取消</el-button>
              </span>
            </el-dialog>
          </template>-->
        </CRUDCom>
      </el-col>
      <el-col :xs="24" :sm="24" :md="14" :lg="14" :xl="14">
        <el-card class="box-card">
          <div style="height:calc(100vh - 185px)">
            <el-table
              :data="tree.tree"
              style="width: 100%;margin-bottom: 20px;"
              row-key="id"
              border
              default-expand-all
              :tree-props="{children: 'children', hasChildren: 'hasChildren'}"
              height="100%"
            >
              <el-table-column prop="label" label="菜单名称" width="180"></el-table-column>
              <el-table-column label="权限">
                <template slot-scope="scope">
                  <el-checkbox-group
                    v-model="scope.row.checkFunction"
                    @change="item=>functionsChange(item,scope.row.id)"
                  >
                    <el-checkbox
                      v-for="(item,index) in scope.row.functions"
                      :label="item.id"
                      :key="index"
                    >{{item.label}}</el-checkbox>
                  </el-checkbox-group>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </el-card>
      </el-col>
    </el-row>
  </div>
</template>
<!--脚本-->
<script>
//vuex
import { mapState, mapMutations, mapActions } from "vuex";
var _controllerName = "RoleFunction";
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
      form: state => state.form,
      tree: state => state.tree
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
      remove: "remove",
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
      //   this.loadForm();
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
      this.getTree();
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
    functionsChange(p, menuid) {
      console.log("p", p, menuid);
      this.save({
        RoleId: this.dataTable.multipleSelection[0]._ukid,
        MenuId: menuid,
        FunctionIds: p
      });
    }
  }
};
</script>
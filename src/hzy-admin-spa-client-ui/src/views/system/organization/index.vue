<template>
  <div class="p-15">
    <a-card class="w100 mb-15" bodyStyle="padding:0" v-show="table.search.state">
      <a-row :gutter="[15, 15]" class="p-15">
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="table.search.vm.name" placeholder="名称" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" class="pt-12">
          <a-radio-group v-model:value="table.search.vm.state">
            <a-radio :value="1"> 正常 </a-radio>
            <a-radio :value="2"> 停用 </a-radio>
          </a-radio-group>
        </a-col>
        <!--button-->
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" style="float: right">
          <a-button type="primary" class="mr-10" @click="findList">查询</a-button>
          <a-button class="mr-10" @click="onResetSearch">重置</a-button>
        </a-col>
      </a-row>
    </a-card>
    <a-card class="w100" bodyStyle="padding:0">
      <a-row :gutter="20" class="p-15 pb-0">
        <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12" class="pb-15">
          <template v-if="power.search">
            <a-button class="mr-10" @click="table.search.state = !table.search.state">
              <div v-if="table.search.state">
                <AppIcons iconName="UpOutlined" />&nbsp;&nbsp;收起
              </div>
              <div v-else><AppIcons iconName="DownOutlined" />&nbsp;&nbsp;展开</div>
            </a-button>
          </template>
          <template v-if="power.insert">
            <a-button type="primary" class="mr-10" @click="openForm()">
              <template #icon>
                <AppIcons iconName="PlusOutlined" />
              </template>
              新建
            </a-button>
          </template>
        </a-col>
      </a-row>
      <a-table
        :columns="table.columns"
        :data-source="table.data"
        :loading="table.loading"
        :pagination="false"
        tableLayout="fixed"
        rowKey="id"
        v-model:expandedRowKeys="table.expandedRowKeys"
      >
        <template #state="{ text }">
          <a-tag color="success" v-if="text == 1">正常</a-tag>
          <a-tag color="warning" v-else>停用</a-tag>
        </template>
        <template #updateTime="{ text }">
          {{ formatDate(text) }}
        </template>
        <template #createTime="{ text }">
          {{ formatDate(text) }}
        </template>
        <template #id="{ record }">
          <div>
            <template v-if="power.insert">
              <a href="javascript:void(0)" @click="openForm(null, record.id)">新建</a>
            </template>
            <a-divider type="vertical" />
            <template v-if="power.update">
              <a href="javascript:void(0)" @click="openForm(record.id)">修改</a>
            </template>
            <a-divider type="vertical" />
            <template v-if="power.delete">
              <a-popconfirm
                title="您确定要删除吗?"
                @confirm="deleteList(record.id)"
                okText="确定"
                cancelText="取消"
              >
                <a class="text-danger">删除</a>
              </a-popconfirm>
            </template>
          </div>
        </template>
      </a-table>
    </a-card>

    <!--表单弹层-->
    <info ref="formRef" @onSuccess="() => findList()" />
  </div>
</template>
<script>
import { computed, defineComponent, onMounted, reactive, toRefs, ref } from "vue";
import { useStore } from "vuex";
import AppIcons from "@/components/appIcons";
import info from "./info";
import tools from "@/scripts/tools";
import service from "@/service/system/organizationService";
import moment from "moment";

//列头
const columns = [
  {
    title: "部门名称",
    dataIndex: "name",
    ellipsis: true,
    width: 300,
  },
  {
    title: "排序号",
    dataIndex: "orderNumber",
    ellipsis: true,
    width: 200,
  },
  {
    title: "状态",
    dataIndex: "state",
    ellipsis: true,
    width: 200,
    slots: { customRender: "state" },
  },
  {
    title: "更新时间",
    dataIndex: "updateTime",
    ellipsis: true,
    width: 200,
    slots: { customRender: "updateTime" },
  },
  {
    title: "创建时间",
    dataIndex: "createTime",
    ellipsis: true,
    width: 200,
    slots: { customRender: "createTime" },
  },
  {
    title: "操作",
    dataIndex: "id",
    width: 200,
    fixed: "right",
    slots: { customRender: "id" },
  },
];

export default defineComponent({
  name: "system_organization",
  components: { AppIcons, info },
  setup() {
    const store = useStore();
    const state = reactive({
      table: {
        //检索
        search: {
          state: false,
          vm: {
            name: null,
            state: 1,
            parentId: null,
          },
        },
        loading: false,
        columns,
        data: [],
        expandedRowKeys: null,
      },
    });
    //表单 ref 对象
    const formRef = ref(null);

    //权限
    const power = computed(() => store.getters["app/getMenuPowerById"]);

    const methods = {
      //重置检索条件
      onResetSearch() {
        let searchVm = state.table.search.vm;
        for (let key in searchVm) {
          searchVm[key] = null;
        }
        searchVm.state = 1;
        methods.findList();
      },
      //获取列表数据
      findList() {
        state.table.loading = true;
        service.findList(state.table.search.vm).then((res) => {
          let data = res.data;
          state.table.loading = false;
          state.table.data = data.rows;
          state.table.expandedRowKeys = data.expandedRowKeys;
        });
      },
      //删除数据
      deleteList(id) {
        let ids = [];
        if (id) {
          ids.push(id);
        }
        service.deleteList(ids).then((res) => {
          if (res.code != 1) return;
          tools.message("删除成功!", "成功");
          methods.findList();
        });
      },
      //打开表单页面
      openForm(id, parentId) {
        state.table.search.vm.parentId = parentId;

        formRef.value.openForm({
          visible: true,
          key: id,
          parentId: state.table.search.vm.parentId,
        });
      },
      formatDate(time) {
        return moment(time).format("YYYY-MM-DD");
      },
    };

    onMounted(() => {
      methods.findList();
    });

    return {
      ...toRefs(state),
      ...methods,
      power,
      formRef,
    };
  },
});
</script>

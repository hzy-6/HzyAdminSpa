<template>
  <div class="p-15">
    <a-card class="w100 mb-15" bodyStyle="padding:0" v-show="table.search.state">
      <a-row :gutter="[15, 15]" class="p-15">
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="table.search.vm.api" placeholder="接口地址" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="table.search.vm.browser" placeholder="浏览器" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="table.search.vm.ip" placeholder="ip地址" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="table.search.vm.os" placeholder="操作系统" />
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
          <template v-if="power.insert"> </template>
          <template v-if="power.delete">
            <a-popconfirm
              title="您确定要删除吗?"
              @confirm="deleteList()"
              okText="确定"
              cancelText="取消"
            >
              <a-button type="danger" class="mr-10">
                <template #icon>
                  <AppIcons iconName="DeleteOutlined" />
                </template>
                清空所有数据
              </a-button>
            </a-popconfirm>
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
      >
        <template #takeUpTime="{ text }">
          <a-tag v-if="text >= 1000" color="orange">{{ text }}(毫秒)</a-tag>
          <a-tag v-else-if="text >= 5000" color="red">{{ text }}(毫秒)</a-tag>
          <a-tag v-else>{{ text }}(毫秒)</a-tag>
        </template>
        <template #id="{ record }">
          <a href="javascript:void(0)" @click="openForm(record.id)">详情</a>
        </template>
      </a-table>
      <a-pagination
        class="p-20"
        size="small"
        showSizeChanger
        showQuickJumper
        :pageSizeOptions="table.pageSizeOptions"
        v-model:total="table.total"
        v-model:defaultCurrent="table.page"
        v-model:pageSize="table.rows"
        :showTotal="(total) => `共计 ${total} 条`"
        @showSizeChange="onShowSizeChange"
        @change="onChange"
      >
      </a-pagination>
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
import service from "@/service/system/sys_operation_log_serivce";

//列头
const columns = [
  {
    title: "接口地址",
    dataIndex: "api",
  },
  {
    title: "浏览器",
    dataIndex: "browser",

    width: 120,
  },
  {
    title: "ip地址",
    dataIndex: "ip",

    width: 120,
  },
  {
    title: "操作系统",
    dataIndex: "os",

    width: 120,
  },
  {
    title: "接口耗时",
    dataIndex: "takeUpTime",
    slots: { customRender: "takeUpTime" },
    width: 120,
  },
  {
    title: "操作人姓名",
    dataIndex: "userName",

    width: 120,
  },
  {
    title: "操作人账号",
    dataIndex: "loginName",

    width: 120,
  },
  {
    title: "创建时间",
    dataIndex: "createTime",
    width: 200,
  },
  {
    title: "操作",
    dataIndex: "id",
    width: 120,
    slots: { customRender: "id" },
  },
];
export default defineComponent({
  name: "sys_operation_log",
  components: { AppIcons, info },
  setup() {
    const store = useStore();
    const state = reactive({
      table: {
        //检索
        search: {
          state: false,
          fieldCount: 2,
          vm: {
            name: null,
          },
        },
        loading: false,
        pageSizeOptions: ["10", "20", "30", "40", "50", "100", "500"],
        rows: 10,
        page: 1,
        total: 0,
        selectedRowKeys: [],
        columns,
        data: [],
      },
      form: {
        visible: false,
        key: "",
      },
    });
    //表单 ref 对象
    const formRef = ref(null);

    //权限
    const power = computed(() => store.getters["app/getMenuPowerById"]);

    //事件 函数
    const methods = {
      onChange(page, rows) {
        page = page == 0 ? 1 : page;
        state.table.page = page;
        state.table.rows = rows;
        methods.findList();
      },
      onShowSizeChange(page, rows) {
        page = page == 0 ? 1 : page;
        state.table.page = page;
        state.table.rows = rows;
        methods.findList();
      },
      //重置检索条件
      onResetSearch() {
        let searchVm = state.table.search.vm;
        for (let key in searchVm) {
          searchVm[key] = null;
        }
        methods.findList();
      },
      //获取列表数据
      findList() {
        state.table.loading = true;
        service
          .findList(state.table.rows, state.table.page, state.table.search.vm)
          .then((res) => {
            let data = res.data;
            state.table.loading = false;
            state.table.page = data.page;
            state.table.rows = data.size;
            state.table.total = data.total;
            state.table.data = data.dataSource;
          });
      },
      //删除数据
      deleteList() {
        service.deleteAllData().then((res) => {
          if (res.code != 1) return;
          tools.message("删除成功!", "成功");
          methods.findList();
        });
      },
      //打开表单页面
      openForm(id) {
        formRef.value.openForm({ visible: true, key: id });
      },
      exportExcel() {
        service.exportExcel(state.table.search.vm);
      },
    };

    onMounted(() => {
      methods.findList();
    });

    return {
      ...toRefs(state),
      formRef,
      power,
      ...methods,
    };
  },
});
</script>

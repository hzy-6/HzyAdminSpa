<template>
  <div class="p-15">
    <a-card class="w100 mb-15" bodyStyle="padding:0" v-show="fromSearch.state">
      <a-row :gutter="[15, 15]" class="p-15">
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="用户名" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="年龄" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="地址" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="用户名" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="地址" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="地址1" />
        </a-col>
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4">
          <a-input v-model:value="fromSearch.vm.value" placeholder="地址2" />
        </a-col>
        <!--button-->
        <a-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" style="float: right">
          <a-button type="primary" class="mr-10">查询</a-button>
          <a-button class="mr-10">重置</a-button>
        </a-col>
      </a-row>
    </a-card>
    <a-card class="w100" bodyStyle="padding:0">
      <a-row :gutter="20" class="p-15 pb-0">
        <a-col :xs="24" :sm="24" :md="12" :lg="12" :xl="12" class="pb-15">
          <a-button class="mr-15" @click="fromSearch.state = !fromSearch.state">
            <div v-if="fromSearch.state">
              <AppIcons iconName="UpOutlined" />&nbsp;&nbsp;收起
            </div>
            <div v-else>
              <AppIcons iconName="DownOutlined" />&nbsp;&nbsp;展开
            </div>
          </a-button>
          <a-button type="primary" class="mr-15" @click="from.visible = true">
            <template #icon>
              <AppIcons iconName="PlusOutlined" />
            </template>
            新建
          </a-button>
          <a-popconfirm
            title="您确定要删除?"
            @confirm="confirm"
            okText="确定"
            cancelText="取消"
          >
            <a-button type="danger" class="mr-15">
              <template #icon>
                <AppIcons iconName="DeleteOutlined" />
              </template>
              批量删除
            </a-button>
          </a-popconfirm>
        </a-col>
        <a-col
          :xs="24"
          :sm="24"
          :md="12"
          :lg="12"
          :xl="12"
          class="pb-15 text-right"
        >
          <a-button type="primary" class="mr-15" @click="exportExcel"
            >导出 Excel</a-button
          >
          <a-button type="primary" class="mr-15" @click="exportExcel"
            >导出 Pdf</a-button
          >
        </a-col>
      </a-row>
      <a-table
        :columns="table.columns"
        :data-source="table.data"
        :pagination="{ pageSize: 20 }"
        :loading="table.loading"
        size="middle"
      >
        <!-- <template #id="{ record }"> -->
        <template #id>
          <span>
            <a href="javascript:;" @click="from.visible = true">修改</a>
            <a-divider type="vertical" />
            <a class="text-danger">删除</a>
          </span>
        </template>
      </a-table>
    </a-card>
    <info v-model:propVisible="from.visible" />
  </div>
</template>
<script>
import { defineComponent, reactive, toRefs } from "vue";

import AppIcons from "@/components/appIcons.vue";
import info from "./info.vue";
import tools from "@/scripts/tools";

export default defineComponent({
  name: "list",
  components: { AppIcons, info },
  setup() {
    const state = reactive({
      fromSearch: {
        state: false,
        fieldCount: 7,
        vm: {
          value: "",
        },
      },
      from: {
        visible: false,
      },
      table: {
        loading: false,
        columns: [],
        data: [],
      },
    });

    const methods = {
      findList() {
        state.table.loading = true;
        setTimeout(() => {
          const columns = [
            {
              title: "姓名",
              dataIndex: "name",
              width: 130,
            },
            {
              title: "年龄",
              dataIndex: "age",
              width: 80,
            },
            {
              title: "地址",
              dataIndex: "address",
            },
            {
              title: "操作",
              dataIndex: "id",
              width: 200,
              slots: { customRender: "id" },
            },
          ];

          const data = [];
          for (let i = 0; i < 100; i++) {
            data.push({
              key: i,
              name: `Hzy ${i + 1}`,
              age: 18 + i,
              address: `addr. ${i + 1}`,
              id: i,
            });
          }
          state.table.columns = columns;
          state.table.data = data;
          state.table.loading = false;
        }, 100);
      },
      exportExcel() {
        tools.notice("导出Excel成功!", "成功", "提醒");
      },
      confirm() {
        tools.message("删除成功!", "成功");
      },
    };

    methods.findList();

    return {
      ...toRefs(state),
      ...methods,
    };
  },
});
</script>

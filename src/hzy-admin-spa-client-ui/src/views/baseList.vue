<template>
  <div class="p-15">
    <a-table
      :row-selection="rowSelection"
      :columns="columns"
      :data-source="data"
    >
      <template #name="{ text }">
        <a>{{ text }}</a>
      </template>
    </a-table>
  </div>
</template>
<script>
import { defineComponent, reactive, toRefs } from "vue";

const columns = [
  {
    title: "Name",
    dataIndex: "name",
    slots: { customRender: "name" },
  },
  {
    title: "Age",
    dataIndex: "age",
  },
  {
    title: "Address",
    dataIndex: "address",
  },
];
const data = [
  {
    key: "1",
    name: "John Brown",
    age: 32,
    address: "New York No. 1 Lake Park",
  },
  {
    key: "2",
    name: "Jim Green",
    age: 42,
    address: "London No. 1 Lake Park",
  },
  {
    key: "3",
    name: "Joe Black",
    age: 32,
    address: "Sidney No. 1 Lake Park",
  },
  {
    key: "4",
    name: "Disabled User",
    age: 99,
    address: "Sidney No. 1 Lake Park",
  },
];

export default defineComponent({
  name: "base_list",
  setup() {
    const state = reactive({
      columns,
      data,
    });

    // const rowSelection = computed(() => {
    //   return {
    //     onChange: (selectedRowKeys, selectedRows) => {
    //       console.log(
    //         `selectedRowKeys: ${selectedRowKeys}`,
    //         "selectedRows: ",
    //         selectedRows
    //       );
    //     },
    //     getCheckboxProps: (record) => ({
    //       disabled: record.name === "Disabled User", // Column configuration not to be checked
    //       name: record.name,
    //     }),
    //   };
    // });

    const rowSelection = {
      onChange: (selectedRowKeys, selectedRows) => {
        console.log(
          `selectedRowKeys: ${selectedRowKeys}`,
          "selectedRows: ",
          selectedRows
        );
      },
      getCheckboxProps: (record) => ({
        disabled: record.name === "Disabled User", // Column configuration not to be checked
        name: record.name,
      }),
    };

    return {
      ...toRefs(state),
      rowSelection,
    };
  },
});
</script>

<template>
  <a-modal
    v-model:visible="visible"
    title="编辑"
    centered
    @ok="visible = false"
    :width="500"
  >
    <template #footer>
      <a-button type="primary" @click="saveForm()" :loading="saveLoading">提交</a-button>
      <a-button type="danger" ghost @click="visible = false">关闭</a-button>
    </template>
    <a-spin :spinning="saveLoading">
      <a-form layout="vertical" :model="vm.form">
        <a-row :gutter="[15, 15]">
          <a-col :xs="24">
            <a-form-item label="序号">
              <a-input-number
                id="inputNumber"
                v-model:value="vm.form.sort"
                :min="0"
                :max="50"
                class="w100"
              />
              <!-- <a-input v-model:value="vm.form.sort" placeholder="请输入" readonly /> -->
            </a-form-item>
          </a-col>
          <a-col :xs="24">
            <a-form-item label="编码">
              <a-input v-model:value="vm.form.code" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24">
            <a-form-item label="分组名称/键">
              <a-input v-model:value="vm.form.name" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24">
            <a-form-item label="值">
              <a-input v-model:value="vm.form.value" placeholder="请输入" />
            </a-form-item>
          </a-col>
        </a-row>
      </a-form>
    </a-spin>
  </a-modal>
</template>
<script>
import { defineComponent, reactive, toRefs } from "vue";
import tools from "@/scripts/tools";
import service from "@/service/system/dictionary_service";

export default defineComponent({
  props: {
    onSuccess: Function,
  },
  setup(props, context) {
    const state = reactive({
      vm: {
        id: "",
        form: {},
        allFunctions: [],
        functionIds: [],
      },
      visible: false,
      saveLoading: false,
      parentId: null,
    });

    const methods = {
      async findForm() {
        state.saveLoading = true;
        const res = await service.findForm(state.vm.id);
        state.saveLoading = false;
        if (res.code != 1) return;
        state.vm = res.data;
        state.vm.form.sort = state.vm.form.sort == 0 ? 1 : state.vm.form.sort;
      },
      saveForm() {
        state.saveLoading = true;
        state.vm.form.parentId = state.parentId ? state.parentId : null;
        service.saveForm(state.vm.form).then((res) => {
          state.saveLoading = false;
          if (res.code != 1) return;
          tools.message("操作成功!", "成功");
          context.emit("onSuccess", res.data);
          state.visible = false;
        });
      },
      //打开表单初始化
      openForm({ visible, key, parentId }) {
        state.visible = visible;
        if (visible) {
          state.vm.id = key;
          state.parentId = parentId;
          methods.findForm();
        }
      },
    };

    context.expose({ ...methods });

    return {
      ...toRefs(state),
      ...methods,
    };
  },
});
</script>
<style lang="less" scoped>
.ant-form-item {
  margin-bottom: 0;
}
</style>

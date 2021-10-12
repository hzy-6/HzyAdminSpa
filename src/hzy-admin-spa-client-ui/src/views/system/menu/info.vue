<template>
  <a-modal
    v-model:visible="visible"
    title="编辑"
    centered
    @ok="visible = false"
    :width="1000"
  >
    <template #footer>
      <a-button type="primary" @click="saveForm()" :loading="saveLoading">提交</a-button>
      <a-button type="danger" ghost @click="visible = false">关闭</a-button>
    </template>
    <a-spin :spinning="saveLoading">
      <a-form layout="vertical" :model="vm.form">
        <a-row :gutter="[15, 15]">
          <a-col :xs="24">
            <a-form-item label="Id">
              <a-input v-model:value="vm.form.id" placeholder="请输入" readonly />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="编号">
              <a-input v-model:value="vm.form.number" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="菜单名称">
              <a-input v-model:value="vm.form.name" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="组件名称">
              <a-input v-model:value="vm.form.componentName" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="菜单物理地址">
              <a-input v-model:value="vm.form.url" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="菜单路由地址">
              <a-input v-model:value="vm.form.router" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="跳转地址（不填默认使用 菜单路由地址）支持 http、https">
              <a-input v-model:value="vm.form.jumpUrl" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item>
              <template #label>
                <a href="https://2x.antdv.com/components/icon-cn" target="black">
                  图标（请使用AntdV 2.0 官方icon）
                </a>
              </template>
              <a-input v-model:value="vm.form.icon" placeholder="请输入" />
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="是否显示">
              <a-radio-group v-model:value="vm.form.show">
                <a-radio :value="1">是</a-radio>
                <a-radio :value="0">否</a-radio>
              </a-radio-group>
            </a-form-item>
          </a-col>
          <a-col :xs="24" :sm="12" :md="12" :lg="12" :xl="12">
            <a-form-item label="选项卡能否关闭">
              <a-radio-group v-model:value="vm.form.close">
                <a-radio :value="1">是</a-radio>
                <a-radio :value="0">否</a-radio>
              </a-radio-group>
            </a-form-item>
          </a-col>
          <a-col :xs="24">
            <a-form-item label="拥有功能">
              <a-checkbox-group v-model:value="vm.functionIds" class="w100">
                <a-row>
                  <a-col :span="6" v-for="(item, index) in vm.allFunctions" :key="index">
                    <a-checkbox :value="item.id">
                      {{ item.name }}
                    </a-checkbox>
                  </a-col>
                </a-row>
              </a-checkbox-group>
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
import service from "@/service/system/menuService";

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
      },
      saveForm() {
        state.saveLoading = true;
        state.vm.form.ParentId = state.parentId ? state.parentId : null;
        service.saveForm(state.vm).then((res) => {
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

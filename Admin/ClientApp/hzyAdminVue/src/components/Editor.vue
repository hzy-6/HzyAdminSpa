<template>
  <div>
    <!-- 工具栏容器 -->
    <div :id="editorid+'-tools'"></div>
    <!-- 编辑器容器 -->
    <div :id="editorid"></div>
  </div>
</template>
<script>
import CKEditor from "@ckeditor/ckeditor5-build-decoupled-document";
import "@ckeditor/ckeditor5-build-decoupled-document/build/translations/zh-cn";

export default {
  name: "Editor",
  props: {
    text: String,
    id: String
  },
  data() {
    return {
      editorid: this.id ? this.id : "editor",
      editor: null,
      editorData: this.text
    };
  },
  watch: {
    text(newV) {
      // this.editorData = newV ? newV : "";
      this.setContent(newV);
    },
    editorData(newV) {
      this.$emit("update:text", newV);
      // this.setContent(newV);
    }
  },
  //计算属性
  computed: {},
  mounted() {
    this.initCKEditor();
  },
  methods: {
    //初始化编辑器
    initCKEditor() {
      CKEditor.create(document.querySelector(`#${this.editorid}`), {
        language: "zh-cn",
        fontFamily: {
          options: ["宋体", "黑体", "楷体", "微软雅黑"]
        },
        ckfinder: {
          uploadUrl: "/admin/Upload/uploadUrl"
          //后端处理上传逻辑返回json数据,包括uploaded(选项true/false)和url两个字段
        }
      })
        .then(editor => {
          const toolbarContainer = document.querySelector(
            `#${this.editorid}-tools`
          );
          toolbarContainer.appendChild(editor.ui.view.toolbar.element);
          this.editor = editor; //将编辑器保存起来，用来随时获取编辑器中的内容等，执行一些操作
          this.setContent(this.editorData);
          // this.onChangeContent();
          this.onBlur();
        })
        .catch(error => {
          console.error(error);
        });
    },
    //设置内容
    setContent(content) {
      content = content ? content : "";
      this.editor.setData(content);
    },
    //获取内容
    getContent() {
      return this.editor.getData();
    },
    //内容变化监听
    onChangeContent() {
      var _this = this;
      // this.editor.model.document.on("change:data", () => {
      //   _this.editorData = _this.getContent();
      //   console.log(_this.editorData);
      // });
    },
    onBlur() {
      var _this = this;
      document.querySelector(`#${this.editorid}`).addEventListener(
        "blur",
        function() {
          _this.editorData = _this.getContent();
        },
        false
      );
    }
  }
};
</script>
<style lang="scss">
.ck-editor__editable {
  border: 1px solid #dcdfe6 !important;
  border-top: 0 !important;
  min-height: 300px;
}
</style>
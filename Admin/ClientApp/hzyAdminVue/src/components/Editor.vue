<template>
  <div>
    <ckeditor :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor>
  </div>
</template>
<script>
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";

export default {
  name: "Editor",
  props: {
    text: String
  },
  data() {
    return {
      editor: ClassicEditor,
      editorData: this.text,
      editorConfig: {
        // The configuration of the editor.
        height: "500px"
      }
    };
  },
  watch: {
    text(newV) {
      this.editorData = newV;
    },
    editorData(newV) {
      this.$emit("update:text", newV);
    }
  }
};
</script>
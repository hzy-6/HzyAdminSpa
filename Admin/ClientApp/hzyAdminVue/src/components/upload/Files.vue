<template>
  <div>
    <el-upload
      class="upload-demo"
      action="/Upload/Multiple"
      ref="upload"
      :on-preview="handlePreview"
      :on-remove="handleRemove"
      :file-list="fileList"
      :auto-upload="false"
      :on-change="onChange"
    >
      <el-button slot="trigger" size="small" type="primary">选取文件</el-button>
      <!-- <el-button style="margin-left: 10px;" size="small" type="success" @click="submitUpload">上传到服务器</el-button>
      <div slot="tip" class="el-upload__tip">只能上传jpg/png文件，且不超过500kb</div>-->
    </el-upload>
  </div>
</template>
<script>
export default {
  name: "FilesCom",
  props: {
    imageUrl: String
  },
  data() {
    return {
      fileList: this.imageUrl ? JSON.parse(this.imageUrl) : [],
      upfile: []
    };
  },
  watch: {
    imageUrl(newV) {
      this.fileList = newV ? JSON.parse(newV) : [];
    }
  },
  //计算属性
  computed: {},
  mounted() {
    this.upfile = [];
  },
  methods: {
    submitUpload() {
      //   this.$refs.upload.submit();
    },
    handleRemove(file, _fileList) {
      this.$emit("update:imageUrl", JSON.stringify(_fileList));
    },
    handlePreview(file) {
      if (file.status === "success") {
        var url = file.url;
        let a = document.createElement("a");
        a.style.display = "none";
        a.href = url;
        a.setAttribute("download", url);
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a); // 下载完成移除元素
      }
    },
    onChange(file, fileList) {
      // console.log("conchange", fileList);
      //this.fileUrl = URL.createObjectURL(file.raw);
      this.upfile = fileList;
    },
    clearUpFile() {
      this.upfile = [];
    }
  }
};
</script>
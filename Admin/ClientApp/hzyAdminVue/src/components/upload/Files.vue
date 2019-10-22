<template>
  <div>
    <el-upload
      class="upload-demo"
      action="/Upload/Multiple"
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
      // console.log(newV);
      this.fileList = newV ? JSON.parse(newV) : [];
    }
  },
  //计算属性
  computed: {},
  mounted() {
    // console.log(this.imageUrl);
  },
  methods: {
    submitUpload() {
      //   this.$refs.upload.submit();
    },
    handleRemove(file, _fileList) {
      this.$emit("update:imageUrl", JSON.stringify(_fileList));
    },
    handlePreview(file) {
      //   console.log(file);
    },
    onChange(file, fileList) {
      //console.log(fileList);
      //this.fileUrl = URL.createObjectURL(file.raw);
      this.upfile = fileList;
      //   this.fileList = fileList;
    }
  }
};
</script>
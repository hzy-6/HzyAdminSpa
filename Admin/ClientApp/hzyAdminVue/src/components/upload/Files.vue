<template>
  <div>
    <el-upload
      class="upload-demo"
      action="/Upload/Multiple"
      :on-preview="handlePreview"
      :on-remove="handleRemove"
      :file-list="fileList?JSON.parse(fileList):[]"
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
      fileList: this.imageUrl,
      upfile: []
    };
  },
  watch: {
    imageUrl(newV) {
      this.fileList = newV;
    }
  },
  methods: {
    submitUpload() {
      //   this.$refs.upload.submit();
    },
    handleRemove(file, fileList) {
      //   console.log(file, fileList);
      var _fileList = JSON.parse(this.fileList);
      //
      for (var i = 0; i < _fileList.length; i++) {
        var item = _fileList[i];
        var _file = fileList.find(w => w.name == item.name);
        if (!_file) {
          _fileList.splice(i, 1);
        }
      }
      console.log("this.fileList.remove", _fileList);
      //this.imageUrl = JSON.stringify(this.findList);
      this.$emit("update:imageUrl", JSON.stringify(_fileList));
      //this.fileList = fileList;
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
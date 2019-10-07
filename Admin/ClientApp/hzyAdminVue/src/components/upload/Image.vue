<template>
  <div>
    <el-upload
      name="files"
      class="avatar-uploader"
      action="/Upload/Single"
      :show-file-list="false"
      :auto-upload="false"
      :on-change="onChange"
      accept="image/png, image/jpeg"
    >
      <img v-if="fileUrl" :src="fileUrl" class="avatar" />
      <i v-else class="el-icon-plus avatar-uploader-icon"></i>
    </el-upload>
  </div>
</template>
<!--脚本-->
<script>
//上传单个图片组件
export default {
  name: "ImageCom",
  props: {
    imageUrl: String
  },
  data() {
    return {
      upfile: null,
      fileUrl: this.imageUrl
    };
  },
  //计算属性
  computed: {},
  mounted() {},
  methods: {
    onChange(file, fileList) {
      this.fileUrl = URL.createObjectURL(file.raw);
      this.upfile = file;
    }
  }
};
</script>
<style lang="scss">
.avatar-uploader .el-upload {
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  cursor: pointer;
  position: relative;
  overflow: hidden;
}
.avatar-uploader .el-upload:hover {
  border-color: #409eff;
}
.avatar-uploader-icon {
  font-size: 28px;
  color: #8c939d;
  width: 178px;
  height: 178px;
  line-height: 178px;
  text-align: center;
}
.avatar {
  width: 178px;
  height: 178px;
  display: block;
}
</style>
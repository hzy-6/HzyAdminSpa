<template>
  <div class="cct-container">
    <div class="left">
      <ul>
        <li
          v-for="(item,index) in tableNames"
          :key="index"
          @click="eventSelectedTableName(item)"
          :class="{'active':selectedTableName==item}"
        >{{item}}</li>
      </ul>
    </div>
    <div class="center">
      <ul>
        <li
          v-for="(item,index) in tableFields"
          :key="index"
          @click="eventSelectedField(item.COLUMN_NAME)"
        >
          <div class="col-1">{{item.COLUMN_NAME}}</div>
          <div class="col-2">
            <el-divider direction="vertical"></el-divider>
            {{item.DATA_TYPE}}
            <el-tag type="success" v-if="item.COLUMN_KEY=='YES'" class="ml-10">主键</el-tag>
          </div>
        </li>
      </ul>
    </div>
    <div class="right">
      <div class="top">
        <ul>
          <li
            @click="eventSelectedCodeType('Model')"
            :class="{'active':selectedCodeType=='Model'}"
          >Model</li>
          <li
            @click="eventSelectedCodeType('RegisterModel')"
            :class="{'active':selectedCodeType=='RegisterModel'}"
          >RegisterModel</li>
          <li
            @click="eventSelectedCodeType('Logic')"
            :class="{'active':selectedCodeType=='Logic'}"
          >Logic</li>
          <li
            @click="eventSelectedCodeType('Controller')"
            :class="{'active':selectedCodeType=='Controller'}"
          >Controller</li>
          <li
            @click="eventSelectedCodeType('Form')"
            :class="{'active':selectedCodeType=='Form'}"
          >Form</li>
        </ul>
      </div>
      <div class="content">
        <el-input type="textarea" placeholder="code" v-model="codeArea"></el-input>
        <!-- <el-card class="box-card">
          <div slot="header" class="clearfix">
            <span>卡片名称</span>
            <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
          </div>
          <div v-for="o in 4" :key="o" class="text item">{{'列表内容 ' + o }}</div>
        </el-card>-->
      </div>
      <div class="bottom" v-show="selectedCodeType!='RegisterModel'">
        <ul>
          <li @click="download">下载当前</li>
          <li @click="downloadAll">下载所有</li>
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import "../../css/cct.scss";

export default {
  name: "CCT",
  data() {
    return {
      codeArea: "",
      selectedTableName: "",
      selectedCodeType: "",
      selectedField: [],
      tableNameAndFields: {},
      tableNames: [],
      tableFields: []
    };
  },
  created() {
    this.getTableNameAndFields(() => {
      this.selectedCodeType = "Model";
      this.getModelCode();
    });
  },
  mounted() {},
  methods: {
    eventSelectedTableName(text) {
      this.selectedTableName = text;
      this.tableFields = this.tableNameAndFields[text];
      if (this.selectedCodeType == "Model") {
        this.getModelCode();
      }
      if (this.selectedCodeType == "RegisterModel") {
        this.getDbSetCode();
      }
      if (this.selectedCodeType == "Logic") {
        this.getLogicCode();
      }
      if (this.selectedCodeType == "Controller") {
        this.getControllersCode();
      }
    },
    //选中字段
    eventSelectedField(text) {
      var item = `${this.selectedTableName}/${text}`;
      var any = this.selectedField.find(w => w == item);
      if (any) return;
      this.selectedField.push(item);
    },
    //选择代码类型
    eventSelectedCodeType(text) {
      this.selectedCodeType = text;
      if (this.selectedCodeType == "Model") {
        this.getModelCode();
      }
      if (this.selectedCodeType == "RegisterModel") {
        this.getDbSetCode();
      }
      if (this.selectedCodeType == "Logic") {
        this.getLogicCode();
      }
      if (this.selectedCodeType == "Controller") {
        this.getControllersCode();
      }
    },
    //获取所有的 表名 及对应的 字段
    getTableNameAndFields(call) {
      global.post("/Admin/CCT/GetTableNameAndFields", {}, true).then(res => {
        var data = res.data;
        this.tableNameAndFields = data.data;
        for (var item in this.tableNameAndFields) {
          this.tableNames.push(item);
        }
        this.eventSelectedTableName(this.tableNames[0]);
        if (call) call();
      });
    },
    //获取 Model 代码
    getModelCode() {
      global
        .post(
          "/Admin/CCT/GetModelCode",
          { TableName: this.selectedTableName },
          true
        )
        .then(res => {
          var data = res.data;
          this.codeArea = data.data;
        });
    },
    //获取 注册表 代码
    getDbSetCode() {
      global.post("/Admin/CCT/GetDbSetCode", {}, true).then(res => {
        var data = res.data;
        this.codeArea = data.data;
      });
    },
    //获取 Logic 代码
    getLogicCode() {
      global
        .post(
          "/Admin/CCT/GetLogicCode",
          { TableName: this.selectedTableName },
          true
        )
        .then(res => {
          var data = res.data;
          this.codeArea = data.data;
        });
    },
    //获取 Controllers 代码
    getControllersCode() {
      global
        .post(
          "/Admin/CCT/GetControllersCode",
          { TableName: this.selectedTableName },
          true
        )
        .then(res => {
          var data = res.data;
          this.codeArea = data.data;
        });
    },
    //下载当前
    download() {
      global.download(
        "/Admin/CCT/Download",
        {
          TableName: this.selectedTableName,
          CodeType: this.selectedCodeType,
          Content: this.codeArea
        },
        true
      );
    },
    //下载所有代码文件
    downloadAll() {
      global.download(
        "/Admin/CCT/DownloadAll",
        {
          CodeType: this.selectedCodeType
        },
        true
      );
    }
  }
};
</script>
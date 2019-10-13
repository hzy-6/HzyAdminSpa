<template>
  <div>
    <a-card :bordered="false">
      <a-row :gutter="20">
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20">
          <a-input placeholder="请输入 用户名" v-model="input" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20">
          <a-input placeholder="请输入 用户名"  v-model="input" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20">
          <a-input placeholder="请输入 用户名"  v-model="input" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20" v-show="fromSearch.state">
          <a-input placeholder="请输入 用户名"  v-model="input" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20" v-show="fromSearch.state">
          <a-input placeholder="请输入 用户名" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20" v-show="fromSearch.state">
          <a-input placeholder="请输入 用户名" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20" v-show="fromSearch.state">
          <a-input placeholder="请输入 用户名" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20" v-show="fromSearch.state">
          <a-input placeholder="请输入 用户名" />
        </a-col>
        <a-col :xs="24" :sm="24" :md="12" :lg="6" :xl="6" class="pb-20" style="float:right">
          <a-button type="primary" class="mr-10">查询</a-button>
          <a-button class="mr-10">重置</a-button>
          <a-button type="link" @click="fromSearch.state=!fromSearch.state">
            <div v-show="!fromSearch.state">
              <a-icon type="down" />展开
            </div>
            <div v-show="fromSearch.state">
              <a-icon type="up" />收起
            </div>
          </a-button>
        </a-col>
      </a-row>
      <a-row :gutter="20">
        <a-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24" class="pb-20">
          <a-button type="primary" class="mr-10" @click="visible=true">新建</a-button>
          <a-popconfirm title="您确定要删除?" @confirm="confirm" okText="确定" cancelText="取消">
            <a-button type="danger" class="mr-10">批量删除</a-button>
          </a-popconfirm>
        </a-col>
      </a-row>
      <a-table :columns="columns" :dataSource="data" size="middle" :pagination="false">
        <template slot="name" slot-scope="text">
          <a href="javascript:;">{{text}}</a>
        </template>
        <template slot="operation">
          <!-- slot-scope="text, record, index" -->
          <a href="javascript:;" @click="visible=true">编辑</a>
          <a-divider type="vertical" />
          <a-popconfirm title="您确定要删除?" @confirm="confirm" okText="确定" cancelText="取消">
            <a href="javascript:;">删除</a>
          </a-popconfirm>
        </template>
        <!-- <template slot="title" slot-scope="currentPageData">Header</template>
        <template slot="footer" slot-scope="currentPageData">Footer</template>-->
      </a-table>
      <div class="text-center mt-20">
        <a-pagination v-model="current" :total="50" showSizeChanger showQuickJumper />
      </div>
    </a-card>
    <!-- 表单 -->
    <a-drawer
      title="Create a new account"
      :width="720"
      @close="visible=false"
      :visible="visible"
      :wrapStyle="{height: 'calc(100% - 108px)',overflow: 'auto',paddingBottom: '108px'}"
    >
      <a-form :form="form" layout="vertical" hideRequiredMark>
        <a-row :gutter="16">
          <a-col :span="12">
            <a-form-item label="Name">
              <a-input
                v-decorator="['name', {
                  rules: [{ required: true, message: 'Please enter user name' }]
                }]"
                placeholder="Please enter user name"
              />
            </a-form-item>
          </a-col>
          <a-col :span="12">
            <a-form-item label="Url">
              <a-input
                v-decorator="['url', {
                  rules: [{ required: true, message: 'please enter url' }]
                }]"
                style="width: 100%"
                addonBefore="http://"
                addonAfter=".com"
                placeholder="please enter url"
              />
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="16">
          <a-col :span="12">
            <a-form-item label="Owner">
              <a-select
                v-decorator="['owner', {
                  rules: [{ required: true, message: 'Please select an owner' }]
                }]"
                placeholder="Please a-s an owner"
              >
                <a-select-option value="xiao">Xiaoxiao Fu</a-select-option>
                <a-select-option value="mao">Maomao Zhou</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="12">
            <a-form-item label="Type">
              <a-select
                v-decorator="['type', {
                  rules: [{ required: true, message: 'Please choose the type' }]
                }]"
                placeholder="Please choose the type"
              >
                <a-select-option value="private">Private</a-select-option>
                <a-select-option value="public">Public</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="16">
          <a-col :span="12">
            <a-form-item label="Approver">
              <a-select
                v-decorator="['approver', {
                  rules: [{ required: true, message: 'Please choose the approver' }]
                }]"
                placeholder="Please choose the approver"
              >
                <a-select-option value="jack">Jack Ma</a-select-option>
                <a-select-option value="tom">Tom Liu</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="12">
            <a-form-item label="DateTime">
              <a-date-picker
                v-decorator="['dateTime', {
                  rules: [{ required: true, message: 'Please choose the dateTime' }]
                }]"
                style="width: 100%"
                :getPopupContainer="trigger => trigger.parentNode"
              />
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="16">
          <a-col :span="24">
            <a-form-item label="Description">
              <a-textarea
                v-decorator="['description', {
                  rules: [{ required: true, message: 'Please enter url description' }]
                }]"
                :rows="4"
                placeholder="please enter url description"
              />
            </a-form-item>
          </a-col>
        </a-row>
      </a-form>
      <div
        :style="{
          position: 'absolute',
          left: 0,
          bottom: 0,
          width: '100%',
          borderTop: '1px solid #e9e9e9',
          padding: '10px 16px',
          background: '#fff',
          textAlign: 'right',
        }"
      >
        <a-button :style="{marginRight: '8px'}" @click="visible=false">Cancel</a-button>
        <a-button @click="visible=false" type="primary">Submit</a-button>
      </div>
    </a-drawer>
  </div>
</template>

<script>
import axios from "axios";

const columns = [
  {
    title: "姓名",
    dataIndex: "name",
    scopedSlots: { customRender: "name" }
  },
  {
    title: "金额",
    className: "column-money",
    dataIndex: "money"
  },
  {
    title: "详细地址",
    dataIndex: "address"
  },
  {
    title: "操作",
    dataIndex: "operation",
    scopedSlots: { customRender: "operation" }
  }
];

const data = [
  {
    key: "1",
    name: "John Brown",
    money: "￥300,000.00",
    address: "New York No. 1 Lake Park"
  },
  {
    key: "2",
    name: "Jim Green",
    money: "￥1,256,000.00",
    address: "London No. 1 Lake Park"
  },
  {
    key: "3",
    name: "Joe Black",
    money: "￥120,000.00",
    address: "Sidney No. 1 Lake Park"
  }
];

export default {
  name: "User",
  data() {
    return {
      data,
      columns,
      searchState: false,
      current: 1,
      centerDialogVisible: false,
      msg: "我是Home",
      tableData: [],
      fromSearch: {
        state: false
      },
      input:null,
      form: this.$form.createForm(this),
      visible: false
    };
  },
  mounted() {
    for (var i = 4; i <= 15; i++) {
      this.data.push({
        key: "" + i,
        name: "Joe Black" + i,
        money: "￥" + i + "20,000.00",
        address: "Sidney No. " + i + " Lake Park"
      });
    }
  },
  methods: {
    confirm() {
      global.tools.confirm("确定要删除?", () => {
        global.tools.msg("删除成功!");
        global.tools.alert("删除成功!", () => {
          global.tools.notice("好的我知道你知道了");
        });
      });
    },
    showDrawer() {
      this.visible = true;
    },
    onClose() {
      this.visible = false;
    },
    handleSizeChange(val) {
      console.log(`每页 ${val} 条`);
    },
    handleCurrentChange(val) {
      console.log(`当前页: ${val}`);
    },
    getServerMsg() {
      axios.post("https://192.168.3.22:10002/" + "api/home/get", {}).then(
        response => {
          if (response != undefined) {
            console.log(response.data);
            this.msg = response.data.msg;
          }
        },
        err => {
          // console.log("err", err);
        }
      );
    }
  }
};
</script>


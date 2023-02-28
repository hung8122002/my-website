<template>
  <div @click="optionCLoseAll(null)">
    <!-- content-header -->
    <div class="content-header">
      Nhân viên
      <MButton label="Thêm mới nhân viên" @click="btnAddOnClick"></MButton>
    </div>

    <!-- content body -->
    <div class="content-body">
      <div class="loading" v-show="showLoading">
        <object
          :data="require('../../../assets/loading.svg')"
          src=""
          type=""
        ></object>
      </div>
      <div class="notFound" v-show="showNotFound">
        <p>Không tìm thấy bản ghi nào phù hợp, xin thử lại</p>
      </div>
      <!-- table header -->
      <div class="table-header">
        <div style="margin-left: 12px" v-show="checkSelectAll.length > 1">
          Đã chọn: <b>{{ checkSelectAll.length }}</b>
        </div>
        <MButton
          class="white"
          style="margin: 0 12px"
          label="Bỏ chọn"
          @click="removeDeleteEmployee"
          v-show="checkSelectAll.length > 1"
        ></MButton>
        <MButton
          style="margin-right: auto"
          class="background-red"
          label="Xóa"
          @click="deleteEmployee"
          v-show="checkSelectAll.length > 1"
        ></MButton>
        <div class="m-row m-input-box">
          <MIconButton
            title="Tìm"
            label="fa-solid fa-magnifying-glass"
            @click="searchClick"
          ></MIconButton>
          <MInput
            label="Tìm kiếm"
            v-model="search"
            @keydown="keyDown"
            @input="onSearch"
            :isReLoad="isReLoad"
            v-if="!showLoading"
          ></MInput>
        </div>
        <MIconButton
          style="position: unset; margin-left: 16px"
          label="fa-solid fa-rotate-right"
          @click="reRender"
        ></MIconButton>
        <MfileXlsx @click="exportExcel"></MfileXlsx>
      </div>
      <!-- table body -->
      <div class="table-body">
        <table>
          <thead style="z-index: 2">
            <tr>
              <td
                class="padding-0"
                style="width: 56px; position: sticky; left: 0"
              >
                <button class="checkbox-btn">
                  <label class="slider">
                    <input
                      type="checkbox"
                      @click="selectAllOnClick"
                      :checked="checkAll"
                    />
                    <div class="checked"></div>
                  </label>
                </button>
              </td>
              <td style="width: 120px">MÃ NHÂN VIÊN</td>
              <td>TÊN NHÂN VIÊN</td>
              <td style="width: 80px">GIỚI TÍNH</td>
              <td>NGÀY SINH</td>
              <td>CHỨC DANH</td>
              <td>TÊN ĐƠN VỊ</td>
              <td style="width: 120px">THU NHẬP</td>
              <td style="width: 120px; position: sticky; right: 0">
                CHỨC NĂNG
              </td>
              <td style="border-left: none"></td>
            </tr>
          </thead>
          <tbody>
            <tr
              :class="{ gray: checkSelectAll.includes(item.EmployeeId) }"
              style="position: relative"
              v-for="(item, index) in employees"
              :key="index"
              @dblclick="showDetail(item)"
            >
              <td
                class="padding-0"
                style="position: sticky; left: 0; background-color: #fff"
              >
                <button class="checkbox-btn">
                  <label class="slider">
                    <input
                      type="checkbox"
                      :checked="checked"
                      v-model="checkSelectAll"
                      :value="item.EmployeeId"
                    />
                    <div class="checked"></div>
                  </label>
                </button>
              </td>
              <td>{{ item.EmployeeCode }}</td>
              <td>{{ item.FullName }}</td>
              <td>{{ formatGender(item.Gender) }}</td>
              <td style="text-align: center">
                {{
                  item.DateOfBirth !== null ? formatDate(item.DateOfBirth) : ""
                }}
              </td>
              <td>{{ item.PositionName }}</td>
              <td>{{ item.DepartmentName }}</td>
              <td style="text-align: end">
                {{ item.Salary !== null ? formatMoney(item.Salary) : "" }}
              </td>

              <td
                class="text-center blue c-p"
                style="position: sticky; right: 0; background-color: #fff"
              >
                <b>Sửa</b>
                <button
                  class="pd-8 option-btn"
                  @click.stop="optionCLose(index)"
                >
                  <i class="fa-solid fa-caret-down"> </i>
                </button>
              </td>
              <td
                style="
                  border-left: none;
                  position: sticky;
                  right: 0;
                  z-index: 1;
                "
              >
                <div v-show="code == index" class="table-body-option">
                  <ul>
                    <li @click="clone(item)">Nhân bản</li>
                    <li @click="deleteEmployee(item)">Xóa</li>
                  </ul>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <!-- table footer -->
      <div class="table-footer">
        <div class="table-footer-left" v-show="!showNotFound">
          Tổng số: <b>{{ pagesize }}</b> bản ghi
        </div>
        <div class="table-footer-right" v-show="!showNotFound">
          <MPaging
            ref="combobox"
            v-model="perPage"
            style="float: left"
          ></MPaging>
          <div class="paging-box">
            <button v-show="currentPage > 3 && totalPage > 5" @click="pre">
              Trước
            </button>
            <button
              v-show="currentPage > 3 && totalPage > 5 && range[0] != 1"
              @click="handlePaging(1)"
            >
              1
            </button>
            <button
              v-show="currentPage > 3 && totalPage > 5 && range[0] != 1"
              @click="handleRangeBefore"
            >
              ...
            </button>
            <button
              v-for="item in range"
              :key="item"
              :ref="`page${item}`"
              @click="handlePaging(item)"
              :class="{ paging: currentPage == item }"
            >
              {{ item }}
            </button>
            <button
              v-show="
                currentPage <= totalPage - 3 &&
                totalPage > 5 &&
                range[range.length - 1] != totalPage
              "
              @click="handleRangeNext"
            >
              ...
            </button>
            <button
              v-show="
                currentPage <= totalPage - 3 &&
                totalPage > 5 &&
                range[range.length - 1] != totalPage
              "
              @click="handlePaging(totalPage)"
            >
              {{ totalPage }}
            </button>
            <button
              v-show="currentPage <= totalPage - 3 && totalPage > 5"
              @click="next"
            >
              Sau
            </button>
          </div>
        </div>
      </div>
    </div>
    <MDialog
      :count="
        checkSelectAll && !deleleItem.EmployeeCode ? checkSelectAll.length : ''
      "
      :text="deleleItem.EmployeeCode"
      @close="showDialogDelete = false"
      @accept="checkSelectAll.length > 1 ? deleteMany() : deleteAccept()"
      v-show="showDialogDelete"
    ></MDialog>
    <EmployeeDetail
      :employeeDetail="employeeDetail"
      v-if="showDialog"
      @close="showDialog = false"
      @edit="edit"
      @add="add"
      @openNew="btnAddOnClick()"
      @error="handerError"
    ></EmployeeDetail>
    <MToastMessage
      v-show="showToast"
      @close="showToast = false"
      :label="toastText"
      :addClass="toastClass"
      :text="toastLabel"
    ></MToastMessage>
  </div>
</template>
<script>
import MButton from "@/components/button/MButton.vue";
import MInput from "@/components/input/MInput.vue";
import resource from "@/js/resource";
import _ from "lodash";
import EmployeeDetail from "../employeeDetail/EmployeeDetail.vue";
import MPaging from "@/components/paging/MPaging.vue";
import MIconButton from "@/components/iconBtn/MIconButton.vue";
import commonJS from "@/js/common";
import MDialog from "@/components/dialog/MDialog.vue";
import MToastMessage from "@/components/toastMessage/MToastMessage.vue";
import MfileXlsx from "@/components/fileXlsx/MfileXlsx.vue";
import methods from "@/js/method";
import employeesApi from "@/js/employeeApi";
export default {
  extends: employeesApi,
  name: "EmployeeList",
  props: ["showData"],
  components: {
    EmployeeDetail,
    MButton,
    MInput,
    MPaging,
    MIconButton,
    MDialog,
    MToastMessage,
    MfileXlsx,
  },
  methods: {
    /**
     * Chức năng tìm kiếm
     * CreateBy: NMHUNG (26/12/2022)
     */
    searchClick() {
      this.searchReal = this.search;
      this.currentPage = 1;
      this.reRender();
    },

    /**
     * Hiện form EmployeeDetail
     * CreateBy: NMHUNG (26/12/2022)
     */
    btnAddOnClick() {
      this.employeeDetail = {};
      const data = methods.get(employeesApi.getNewEmployeeCode());
      data.then((data) => {
        this.employeeDetail.EmployeeCode = data;
        this.showDialog = true;
      });
    },

    /**
     * Lập trình sự kiện cho nút select All
     * CreateBy: NMHUNG (26/12/2022)
     */
    selectAllOnClick() {
      this.checked = !this.checkAll;
      this.checkAll = !this.checkAll;
      if (!this.checkAll) {
        this.employees.forEach((employee) => {
          this.checkSelectAll = this.checkSelectAll.filter(
            (item) => item != employee.EmployeeId
          );
        });
      }
      if (this.checked && this.checkSelectAll) {
        this.employees.forEach((employee) => {
          this.checkSelectAll.push(employee.EmployeeId);
        });
      }
    },

    /**
     * xuất ra file excel
     * @param {*} employees dữ liệu truyền vào
     */
    exportExcel() {
      commonJS.exportExcel(this.employees);
    },

    /**
     * Lập trình sự kiện cho nút load lại employeeList
     CreateBy: NMHUNG (26/12/2022)
     */
    reRender(e) {
      this.isReLoad = false;
      try {
        if (e.target) {
          this.searchReal = "";
          this.handlePaging(1);
          this.isReLoad = true;
        }
      } catch (error) {
        error;
      }
      this.showLoading = true;
      this.employees = {};
      this.getData();
    },

    /**
     * Gọi hàm formatDate từ file commonJS
     * CreateBy: NMHUNG (26/12/2022)
     */
    formatDate(date) {
      return commonJS.formatDate(date);
    },

    /**
     * Gọi hàm formatMoney từ file commonJS
     * CreateBy: NMHUNG (26/12/2022)
     */
    formatMoney(money) {
      return commonJS.formatmoney(money);
    },

    /**
     * Gọi hàm formatGender từ file commonJS
     * CreateBy: NMHUNG (26/12/2022)
     */
    formatGender(genders) {
      return commonJS.formatGender(genders);
    },

    /**
     * Lấy dữ liệu từ api
     * CreateBy: NMHUNG (26/12/2022)
     */
    getData() {
      const data = methods.get(
        employeesApi.getEmployeefilter(),
        employeesApi.filterQuery(
          parseInt(localStorage.getItem("perPage")),
          (this.currentPage - 1) * parseInt(localStorage.getItem("perPage")),
          this.searchReal
        )
      );
      data.then((data) => {
        if (data.data.length) {
          this.employees = data.data;
          this.pagesize = data.totalRecord;
          this.totalPage = data.totalPage;
          this.showLoading = false;
          this.showNotFound = false;
        } else {
          this.showLoading = false;
          this.showNotFound = true;
        }
      });
    },

    /**
     * Đóng thẻ option ở mỗi row
     * CreateBy: NMHUNG (26/12/2022)
     */
    optionCLose(index) {
      this.code = index;
    },

    /**
     * Khi click vào thẻ cha thì đóng thẻ con
     * CreateBy: NMHUNG (26/12/2022)
     */
    optionCLoseAll(index) {
      this.code = index;
      this.$refs.combobox.$el.click();
    },

    /**
     * Lấy thông tin nhân viên để chuyền vào employeeDetail
     * CreateBy: NMHUNG (26/12/2022)
     */
    showDetail(item) {
      this.employeeDetail = item;
      this.showDialog = true;
    },

    /**
     * Lấy current để phân trang
     * CreateBy: NMHUNG (26/12/2022)
     */
    handlePaging(item) {
      this.range = [];
      this.currentPage = item;
      this.reRender();
      this.range = commonJS.pagingRange(this.totalPage, this.currentPage);
    },

    /**
     * Hiện ra 3 trang tiếp theo khi click vào nút ...
     * @param {*} currentPage Trang hiện tại
     */
    handleRangeNext() {
      var currentPage = this.range[this.range.length - 1];
      this.range = [];
      this.range = commonJS.pagingRange(this.totalPage, currentPage);
    },

    /**
     * Hiện ra 3 trang trước đó khi click vào nút ...
     * @param {*} currentPage Trang hiện tại
     */
    handleRangeBefore() {
      var currentPage = this.range[0];
      this.range = [];
      this.range = commonJS.pagingRange(this.totalPage, currentPage);
    },
    /**
     * Trở về trước 1 trang
     CreateBy: NMHUNG (26/12/2022)
     */
    pre() {
      this.handlePaging(this.currentPage - 1);
    },

    /**
     * Về trang đầu tiên
     CreateBy: NMHUNG (26/12/2022)
     */
    home() {
      this.handlePaging(1);
    },

    /**
     * Lên trước 1 trang
     CreateBy: NMHUNG (26/12/2022)
     */
    next() {
      this.handlePaging(this.currentPage + 1);
    },

    /**
     * Về trang cuối
     CreateBy: NMHUNG (26/12/2022)
     */
    end() {
      this.handlePaging(this.totalPage);
    },

    /**
     * Nhân bản
     * CreateBy: NMHUNG (26/12/2022)
     */
    clone(item) {
      const data = methods.get(employeesApi.getNewEmployeeCode());
      data.then((data) => {
        const clone = _.cloneDeep(item);
        clone.EmployeeCode = data;
        this.showDetail(clone);
      });
    },

    /**
     * Bỏ chọn
     * CreateBy: NMHUNG (26/12/2022)
     */
    removeDeleteEmployee() {
      this.checkSelectAll = [];
    },

    /**
     * Xóa nhân viên
     CreateBy: NMHUNG (26/12/2022)
     */
    deleteEmployee(item) {
      this.deleleItem = item;
      this.showDialogDelete = true;
    },

    /**
     * Xóa nhân viên
     CreateBy: NMHUNG (26/12/2022)
     */
    deleteAccept() {
      const data = methods.get(
        employeesApi.getEmployee(),
        this.deleleItem.EmployeeCode
      );
      data.then((data) => {
        if (data) {
          const deleleItem = methods.delete(
            employeesApi.getEmployee(),
            employeesApi.filterById(this.deleleItem.EmployeeId)
          );
          deleleItem.then(() => {
            this.toastText = this.toastMessage.delete;
            this.toastLabel = resource.VI.MSG.SUCCESS;
            this.toastClass = "m-toast-icon-green";
            this.showDialogDelete = false;
            this.reRender();
            this.isShowToast = true;
            this.$emit("notification", this.deleleItem, "xóa");
          });
        } else {
          this.toastText = resource.VI.MSG.DELETE_ALLREADY;
          this.toastLabel = resource.VI.MSG.FAIL;
          this.toastClass = "m-toast-icon-red";
          this.showDialogDelete = false;
          this.reRender();
          this.isShowToast = true;
          this.$emit("notification", this.deleleItem, "xóa");
        }
      });
    },

    /**
     * thông báo sửa thành công
      CreateBy: NMHUNG (26/12/2022)
     */
    edit(newData) {
      this.$emit("notification", newData, "sửa");
      this.handlePaging(1);
      this.reRender();
      this.toastText = this.toastMessage.edit;
      this.toastLabel = resource.VI.MSG.SUCCESS;
      this.toastClass = "m-toast-icon-green";
      this.isShowToast = true;
    },

    /**
     * Xử lý lỗi
     * @param {*} error lỗi
     */
    handerError(error) {
      this.reRender();
      this.toastText = error;
      this.toastLabel = resource.VI.MSG.FAIL;
      this.toastClass = "m-toast-icon-red";
      this.isShowToast = true;
    },

    /**
     * thông báo thêm thành công
     * CreateBy: NMHUNG (26/12/2022)
     */
    add(newData) {
      this.$emit("notification", newData, "thêm");
      this.handlePaging(1);
      this.reRender();
      this.toastText = this.toastMessage.add;
      this.toastLabel = resource.VI.MSG.SUCCESS;
      this.toastClass = "m-toast-icon-green";
      this.isShowToast = true;
    },

    /**
     * Xử lý sự kiện nhấn nút
     * CreateBy: NMHUNG (26/12/2022)
     */
    keyDown(event) {
      switch (event.keyCode) {
        case this.enum.KEY_CODE.ENTER:
          // eslint-disable-next-line no-case-declarations
          this.searchClick();
          break;
      }
    },

    /**
     * Tìm kiếm mỗi khi nhấn một chữ nào đó
       CreateBy: NMHUNG (26/12/2022)
     */
    onSearch() {
      // var debounce_fun = _.debounce(this.searchClick, 2000);
      // debounce_fun();
      clearTimeout(this.typingTimer);
      this.typingTimer = setTimeout(this.searchClick, 1000);
    },

    /**
     * Xóa nhiều
       CreateBy: NMHUNG (26/12/2022)
     */
    deleteMany() {
      this.checkSelectAll.forEach((item) => {
        const deleleItem = methods.delete(
          employeesApi.getEmployee(),
          employeesApi.filterById(item)
        );
        deleleItem.then(() => {
          this.checkSelectAll = [];
          this.toastText = this.toastMessage.delete;
          this.toastLabel = resource.VI.MSG.SUCCESS;
          this.toastClass = "m-toast-icon-green";
          this.showDialogDelete = false;
          this.reRender();
          this.isShowToast = true;
          this.$emit("notification", this.deleleItem, "xóa");
        });
      });
    },
  },
  watch: {
    /**
     * Theo dõi sự thay đổi của trang hiện tại để kiểm tra checkbox all
     */
    employees: function () {
      if (this.employees.length) {
        this.checkAll = true;
        this.employees.forEach((employee) => {
          if (!this.checkSelectAll.includes(employee.EmployeeId)) {
            this.checkAll = false;
          }
        });
      }
    },

    /**
     * Theo dõi sự thay đổi của mảng phần tử đã được chọn hiện tại để kiểm tra checkbox all
     */
    checkSelectAll: function () {
      if (this.checkSelectAll.length) {
        this.checkAll = true;
        this.employees.forEach((employee) => {
          if (!this.checkSelectAll.includes(employee.EmployeeId)) {
            this.checkAll = false;
          }
        });
      }
    },
    showData() {
      this.showDetail(this.showData);
    },
    totalPage: function () {
      this.range = commonJS.pagingRange(this.totalPage, this.currentPage);
    },
    perPage: function () {
      localStorage.setItem("perPage", this.perPage);
      this.handlePaging(1);
    },
    showLoading: function () {
      if (!this.showLoading) {
        if (this.isShowToast) {
          this.showToast = true;
          setTimeout(() => {
            this.showToast = false;
          }, 2000);
          this.isShowToast = false;
        }
      }
    },
  },
  created() {
    //
    if (!localStorage.getItem("perPage")) {
      localStorage.setItem("perPage", this.perPage);
    } else {
      this.perPage = localStorage.getItem("perPage");
    }
    // lấy dữ liệu
    this.getData();
  },
  data() {
    return {
      typingTimer: null,
      isReLoad: false,
      showNotFound: false,
      showDialog: false,
      showDialogDelete: false,
      employees: {},
      showLoading: true,
      checked: false,
      checkAll: false,
      checkSelectAll: [],
      code: null,
      employeeDetail: {},
      search: "",
      searchReal: "",
      // perEmployee: {},
      totalPage: null,
      pagesize: null,
      perPage: 20,
      currentPage: 1,
      fakeCurrentPage: 1,
      range: [],
      deleleItem: {},
      // ẩn hiện toast
      showToast: false,
      // thông tin toast
      toastText: "",
      // Mô tả toast
      toastLabel: "",
      // Class của toast
      toastClass: "",
      toastMessage: {
        add: resource.VI.MSG.ADD_SUCCESS,
        edit: resource.VI.MSG.EDIT_SUCCESS,
        delete: resource.VI.MSG.DELETE_SUCCESS,
        clone: resource.VI.MSG.CLONE_SUCCESS,
      },
      isShowToast: false,
    };
  },
};
</script>
<style scoped>
@import url(../../../components/checkbox/checkbox.css);
</style>
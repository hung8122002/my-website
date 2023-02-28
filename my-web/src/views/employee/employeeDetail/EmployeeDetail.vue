<template>
  <div
    @click="optionCLoseAll"
    @keydown="keyDown"
    @keydown.esc="btnCloseOnClick"
  >
    <!-- dialog -->
    <MDialogChange
      style="z-index: 5"
      v-show="dialogChangeShow"
      @close="dialogChangeShow = false"
      @accept="(dialogChangeShow = false), submit()"
      @closeAll="(dialogChangeShow = false), (changeConfirm = true)"
    ></MDialogChange>
    <div class="m-dialog-box">
      <div class="m-dialog-info-item">
        <div class="m-dialog-info-btn">
          <MIconButton
            style="position: unset; margin: 0"
            title="Câu hỏi"
            label="fa-regular fa-circle-question"
          ></MIconButton>
          <MIconButton
            title="Đóng(Esc)"
            style="position: unset; margin: 0"
            label="fa-solid fa-xmark"
            @click.stop="btnCloseOnClick"
          ></MIconButton>
        </div>
        <div class="m-dialog-info-header">
          <div class="text">Thông tin nhân viên</div>
          <div class="option">
            <label class="slider">
              <input type="checkbox" />
              <div class="checked"></div>
            </label>
            Là khách hàng
          </div>
          <div class="option">
            <label class="slider">
              <input type="checkbox" />
              <div class="checked"></div>
            </label>
            Là nhà cung cấp
          </div>
        </div>
        <div class="m-dialog-ifo-body">
          <div class="m-body-top">
            <div class="row">
              <div class="row-left">
                <div class="half-width">
                  <label for="">Mã <i class="red">*</i></label>
                  <MInput
                    @focusLastButton="focusLastButton"
                    ref="input1"
                    tabIndex="1"
                    :isFocused="isFocused"
                    :showMess="codeError.status"
                    :errorMess="codeError.mess"
                    :addClass="
                      codeError.status
                        ? 'width-full m-input-error'
                        : 'width-full'
                    "
                    class="width-full"
                    v-model="newData.EmployeeCode"
                  ></MInput>
                </div>
                <div class="half-width">
                  <label for="">Tên <i class="red">*</i></label>
                  <MInput
                    ref="name"
                    tabIndex="2"
                    :showMess="nameError.status"
                    :errorMess="nameError.mess"
                    :addClass="
                      nameError.status
                        ? 'width-full m-input-error'
                        : 'width-full'
                    "
                    class="width-full"
                    v-model="newData.FullName"
                  ></MInput>
                </div>
              </div>
              <div class="row-right">
                <div class="half-width DOB">
                  <label for="">Ngày sinh</label>
                  <MDatePicker
                    :showMess="dateError.status"
                    :errorMess="dateError.mess"
                    addClass="m-input-error"
                    tabIndex="5"
                    class="width-full"
                    v-model="newData.DateOfBirth"
                  ></MDatePicker>
                </div>
                <div class="half-width gender">
                  <label for="">Giới tính</label>
                  <div
                    class="width-full"
                    style="padding: 9px 0; display: flex; align-items: center"
                  >
                    <input
                      tabindex="6"
                      type="radio"
                      name="check"
                      :value="0"
                      v-model="newData.Gender"
                    />Nam
                    <input
                      tabindex="6"
                      type="radio"
                      name="check"
                      :value="1"
                      v-model="newData.Gender"
                    />Nữ
                    <input
                      tabindex="6"
                      type="radio"
                      name="check"
                      :value="2"
                      v-model="newData.Gender"
                    />Khác
                  </div>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="row-left">
                <div class="width-full">
                  <label for="">Đơn vị <i class="red">*</i></label>
                  <MCombobox
                    tabIndex="3"
                    ref="comboboxDepart"
                    @closeOthers="closeOthers('comboboxDepart')"
                    :showMess="departmentError.status"
                    :errorMess="departmentError.mess"
                    :addClass="
                      departmentError.status
                        ? 'width-full m-input-error'
                        : 'width-full'
                    "
                    :api="departmentApi"
                    propName="DepartmentName"
                    propValue="DepartmentId"
                    v-model="newData.DepartmentId"
                  ></MCombobox>
                </div>
              </div>
              <div class="row-right">
                <div class="half-width">
                  <label for="">Số CMND</label>
                  <MInput
                    tabIndex="7"
                    :showMess="identityNumbereError.status"
                    :errorMess="identityNumbereError.mess"
                    :addClass="
                      identityNumbereError.status
                        ? 'width-full m-input-error'
                        : 'width-full'
                    "
                    class="width-full"
                    title="Số chứng minh nhân dân"
                    v-model="newData.IdentityNumber"
                  ></MInput>
                </div>
                <div class="half-width">
                  <label for="">Ngày cấp</label>
                  <MDatePicker
                    tabIndex="8"
                    class="width-full"
                    v-model="newData.IdentityDate"
                  ></MDatePicker>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="row-left">
                <div class="width-full">
                  <label for="">Chức danh</label>
                  <MCombobox
                    tabIndex="4"
                    ref="comboboxPosition"
                    @closeOthers="closeOthers('comboboxPosition')"
                    :api="positionApi"
                    propName="PositionName"
                    propValue="PositionId"
                    addClass="width-full"
                    v-model="newData.PositionId"
                  ></MCombobox>
                </div>
              </div>
              <div class="row-right">
                <div class="width-full">
                  <label for="">Nơi cấp</label>
                  <MInput
                    tabIndex="9"
                    addClass="width-full"
                    class="width-full"
                    v-model="newData.IdentityPlace"
                  ></MInput>
                </div>
              </div>
            </div>
          </div>
          <div class="m-body-bottom">
            <div class="row">
              <div class="width-full">
                <label for="">Địa chỉ</label>
                <MInput
                  tabIndex="10"
                  addClass="width-full"
                  class="width-full"
                  v-model="newData.Address"
                ></MInput>
              </div>
            </div>
            <div class="row start">
              <div>
                <label for="">ĐT di động</label>
                <MInput
                  ref="phoneNumber"
                  tabIndex="11"
                  :showMess="phoneNumberError.status"
                  :errorMess="phoneNumberError.mess"
                  :addClass="
                    phoneNumberError.status
                      ? 'width-full m-input-error'
                      : 'width-full'
                  "
                  title="Điện thoại"
                  v-model="newData.PhoneNumber"
                ></MInput>
              </div>
              <div>
                <label for="">ĐT cố định</label>
                <MInput
                  tabIndex="12"
                  :showMess="phoneNumberError.status"
                  :errorMess="phoneNumberError.mess"
                  :addClass="
                    phoneNumberError.status
                      ? 'width-full m-input-error'
                      : 'width-full'
                  "
                  title="Điện thoại"
                  v-model="newData.PhoneNumber"
                ></MInput>
              </div>
              <div>
                <label for="">Email</label>
                <MInput
                  ref="email"
                  tabIndex="13"
                  :showMess="emailError.status"
                  :errorMess="emailError.mess"
                  :addClass="
                    emailError.status
                      ? 'width-full m-input-error'
                      : 'width-full'
                  "
                  v-model="newData.Email"
                ></MInput>
              </div>
            </div>
            <div class="row start">
              <div>
                <label for="">Tài khoản ngân hàng</label>
                <MInput
                  addClass="width-full"
                  tabIndex="14"
                  v-model="newData.BankAccount"
                ></MInput>
              </div>
              <div>
                <label for="">Tên ngân hàng</label>
                <MInput
                  addClass="width-full"
                  tabIndex="15"
                  v-model="newData.BankName"
                ></MInput>
              </div>
              <div>
                <label for="">Lương</label>
                <MInputMoney
                  tabIndex="16"
                  v-model="newData.Salary"
                  addClass="width-full"
                ></MInputMoney>
              </div>
            </div>
          </div>
        </div>
        <div class="m-dialog-info-footer">
          <div class="footer-left">
            <MButton
              label="Hủy"
              title="Đóng(Esc)"
              class="bg-clean"
              @click="btnCloseOnClick"
              tabIndex="17"
            ></MButton>
          </div>
          <div class="footer-right">
            <MButton
              label="Cất"
              title="Cất(Ctrl-S)"
              @click="submit"
              class="bg-clean"
              tabIndex="18"
            ></MButton>

            <MButton
              ref="input2"
              label="Cất và thêm"
              title="Cất và thêm(Ctrl-Shift-S)"
              @click="save"
              tabIndex="19"
              @focusFirstInput="focusFirstInput()"
            ></MButton>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import MButton from "@/components/button/MButton.vue";
import MInput from "@/components/input/MInput.vue";
import MIconButton from "@/components/iconBtn/MIconButton.vue";
import commonJS from "@/js/common";
import resource from "@/js/resource";
import _ from "lodash";
import methods from "@/js/method";
import employeeApi from "@/js/employeeApi";
import positionApi from "@/js/positionApi";
import departmentApi from "@/js/departmentApi";
import MCombobox from "@/components/combobox/MCombobox.vue";
import MDialogChange from "@/components/dialog/MDialogChange.vue";
import MDatePicker from "@/components/datePicker/MDatePicker.vue";
export default {
  props: ["employeeDetail"],
  name: "EmployeeDetail",
  components: {
    MButton,
    MInput,
    MIconButton,
    MCombobox,
    MDialogChange,
    MDatePicker,
  },
  methods: {
    /**
     * Xử lý các sự kiện ấn nút
     * @param {*} event sự kiện
     */
    keyDown(event) {
      switch (event.keyCode) {
        case this.enum.KEY_CODE.S_BTN:
          event.preventDefault();
          if (event.ctrlKey) {
            this.submit();
          }
          if (event.shiftKey && event.ctrlKey) {
            this.save();
          }
          break;
      }
    },

    /**
     * Đóng form EmployeeDetail
     * CreateBy: NMHUNG (26/12/2022)
     */
    btnCloseOnClick() {
      if (this.isChange) {
        this.dialogChangeShow = true;
      } else {
        this.$emit("close");
      }
    },

    /**
     * focus vào ô input đầu
     */
    focusFirstInput() {
      this.$refs.input1.$refs.input.focus();
    },

    /**
     * focus vào ô input cuối
     */
    focusLastButton() {
      this.$refs.input2.$refs.input.focus();
    },

    /**
     * Đóng form EmployeeDetail
     * CreateBy: NMHUNG (26/12/2022)
     */
    closeOthers(text) {
      if (text == "comboboxDepart") {
        this.$refs.comboboxPosition.closeContent();
      } else {
        this.$refs.comboboxDepart.closeContent();
      }
    },

    /**
     * Đóng form EmployeeDetail và mở form thêm mới
     * CreateBy: NMHUNG (26/12/2022)
     */
    save() {
      this.submit("openNew");
    },

    /**
     * Thêm mới hoặc sửa nhân viên
     * @param {*} text: chuỗi
     * CreateBy: NMHUNG (26/12/2022)
     */
    submit(text) {
      try {
        // kiểm tra xem có trống không
        this.codeError.status = commonJS.isNull(this.newData.EmployeeCode);
        this.codeError.mess =
          resource.VI.ATT.CODE +
          resource.VI.FIELD.EMPLOYEE +
          resource.VI.ERROR.EMPTY;
        this.nameError.status = commonJS.isNull(this.newData.FullName);
        this.nameError.mess =
          resource.VI.ATT.NAME +
          resource.VI.FIELD.EMPLOYEE +
          resource.VI.ERROR.EMPTY;
        this.departmentError.status = commonJS.isNull(
          this.newData.DepartmentId
        );
        this.departmentError.mess =
          resource.VI.ATT.DEPARTMENT +
          resource.VI.FIELD.EMPLOYEE +
          resource.VI.ERROR.EMPTY;
        if (!this.codeError.status) {
          if (!commonJS.regexCode(this.newData.EmployeeCode)) {
            this.codeError.status = !commonJS.regexCode(
              this.newData.EmployeeCode
            );
            this.codeError.mess =
              resource.VI.ATT.CODE +
              resource.VI.FIELD.EMPLOYEE +
              resource.VI.ERROR.INVALID;
          }
        }
        if (!this.nameError.status) {
          this.nameError.status = commonJS.regexName(this.newData.FullName);
          this.nameError.mess =
            resource.VI.ATT.NAME +
            resource.VI.FIELD.EMPLOYEE +
            resource.VI.ERROR.INVALID;
        }

        // kiểm tra tính hợp lệ của số điện thoại
        if (this.newData.PhoneNumber) {
          this.phoneNumberError.status = commonJS.regexNumber(
            this.newData.PhoneNumber
          );
          this.phoneNumberError.mess =
            resource.VI.ATT.NUMBER +
            resource.VI.FIELD.EMPLOYEE +
            resource.VI.ERROR.INVALID;
        }

        // kiểm tra tính hợp lệ của email
        if (this.newData.Email) {
          this.emailError.status = commonJS.regexEmail(this.newData.Email);
          this.emailError.mess =
            resource.VI.ATT.EMAIL +
            resource.VI.FIELD.EMPLOYEE +
            resource.VI.ERROR.INVALID;
        }
        if (!this.codeError.status) {
          const data = methods.get(
            employeeApi.getEmployee(),
            this.newData.EmployeeCode
          );
          data.then((data) => {
            if (data && this.newData.EmployeeId == null) {
              this.codeError.status = !this.codeError.status;
              this.codeError.mess =
                resource.VI.ATT.CODE +
                resource.VI.FIELD.EMPLOYEE +
                resource.VI.ERROR.EXIST;
            } else if (
              data &&
              this.newData.EmployeeId != null &&
              this.newData.EmployeeCode !== this.fakeCode
            ) {
              this.codeError.status = !this.codeError.status;
              this.codeError.mess =
                resource.VI.ATT.CODE +
                resource.VI.FIELD.EMPLOYEE +
                resource.VI.ERROR.EXIST;
            } else {
              if (
                !this.codeError.status &&
                !this.nameError.status &&
                !this.departmentError.status &&
                !this.phoneNumberError.status &&
                !this.emailError.status
              )
                if (this.newData.EmployeeId) {
                  const edit = methods.put(
                    employeeApi.getEmployee(),
                    employeeApi.filterById(this.newData.EmployeeId),
                    this.newData
                  );
                  edit.catch((error) => {
                    this.$emit("error", error.response.data.userMsg);
                    this.$emit("close");
                  });
                  edit.then(() => {
                    this.$emit("close");
                    this.$emit("edit", this.newData);
                    if (text === "openNew") {
                      this.$emit(text);
                    }
                  });
                } else {
                  const add = methods.post(
                    employeeApi.getEmployee(),
                    this.newData
                  );
                  add.catch((error) => {
                    this.$emit("error", error.response.data.userMsg);
                    this.$emit("close");
                  });
                  add.then(() => {
                    this.$emit("close");
                    this.$emit("add", this.newData);
                    if (text === "openNew") {
                      this.$emit(text);
                    }
                  });
                }
            }
          });
        }
        if (this.emailError.status) {
          this.$refs.email.$refs.input.focus();
        }
        if (this.phoneNumberError.status) {
          this.$refs.phoneNumber.$refs.input.focus();
        }
        if (this.departmentError.status) {
          this.$refs.comboboxDepart.$refs.input.focus();
        }
        if (this.nameError.status) {
          this.$refs.name.$refs.input.focus();
        }
        if (this.codeError.status) {
          this.focusFirstInput();
        }
      } catch (error) {
        error;
      }
    },

    /**
     * Khi click vào thẻ cha thì đóng thẻ con
     * CreateBy: NMHUNG (26/12/2022)
     */
    optionCLoseAll() {
      try {
        this.$refs.comboboxDepart.closeContent();
        this.$refs.comboboxPosition.closeContent();
      } catch (error) {
        error;
      }
    },
  },
  watch: {
    changeConfirm: function () {
      this.$emit("close");
      this.changeConfirm = false;
    },

    /**
     * Theo dõi sự thay đổi của newData
     * CreateBy: NMHUNG (26/12/2022)
     */
    newData: {
      handler: function (newValue) {
        this.isChange = !commonJS.deepCompare(this.cloneNewData, newValue);
      },
      deep: true,
    },
  },
  data() {
    return {
      newData: {},
      // Xem dữ liệu có bị thay đổi hay không
      cloneNewData: {},
      // tự độnh focused vào cái đầu
      isFocused: true,
      // mã nhân viên để edit
      fakeCode: "",
      isChange: false,
      dialogChangeShow: false,
      changeConfirm: false,
      departmentApi: departmentApi.getDepartment(), // Lấy api của departent
      positionApi: positionApi.getPosition(), // Lấy api của position
      codeError: {
        mess: "",
        status: false,
      },
      nameError: {
        mess: "",
        status: false,
      },
      departmentError: {
        mess: "",
        status: false,
      },
      identityNumbereError: {
        mess: "",
        status: false,
      },
      phoneNumberError: {
        mess: "",
        status: false,
      },
      emailError: {
        mess: "",
        status: false,
      },
      dateError: {
        mess: "",
        status: false,
      },
    };
  },
  created() {
    // nhân bản employeeDetail
    if (this.employeeDetail) {
      this.newData = _.cloneDeep(this.employeeDetail);
      this.newData.DateOfBirth = commonJS.formatDateTime(
        this.newData.DateOfBirth
      );
      this.newData.IdentityDate = commonJS.formatDateTime(
        this.newData.IdentityDate
      );
    }
  },
  mounted() {
    this.cloneNewData = _.cloneDeep(this.newData);
    this.fakeCode = this.newData.EmployeeCode;
  },
};
</script>
<style scoped>
@import url(./employee-detail.css);
</style>
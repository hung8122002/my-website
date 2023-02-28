<template>
  <div style="position: relative">
    <input
      type="text"
      class="m-Input"
      :class="addClass"
      :placeholder="label"
      :title="title"
      v-model="show"
      @input="onSearch"
      :tabindex="tabIndex"
    />
    <label for="" v-show="showMess" class="mess">{{ errorMess }}</label>
  </div>
</template>
    <script>
import commonJS from "@/js/common";
export default {
  name: "mInput",
  props: [
    "label",
    "title",
    "modelValue",
    "addClass",
    "errorMess",
    "showMess",
    "isReLoad",
    "tabIndex",
  ],
  created() {
    /**
     * xử lý định dạng dữ liệu nếu có
     */
    this.value = this.modelValue;
    this.show = this.modelValue;
    if (this.show) {
      this.show = commonJS.formatmoney(this.value);
    }
    if (this.isReLoad) {
      this.value = "";
    }
  },
  methods: {
    /**
     * Xử lý dữ liệu khi đang nhập
     */
    onSearch() {
      if (isNaN(parseInt(this.show))) {
        this.show = "";
        return;
      }
      this.value = parseInt(this.show.replaceAll(".", ""));
      this.show = commonJS.formatmoney(this.value);
    },
  },
  watch: {
    /**
     * theo dõi sự thay đổi của dữ liệu
     * @param {*} newValue giá trị mới
     */
    value: function (newValue) {
      this.$emit("update:modelValue", newValue);
    },
  },
  data() {
    return {
      /**
       * giá trị để xử lý
       */
      value: null,

      /**
       * giá trị hiện ra
       */
      show: null,
    };
  },
};
</script>
  <style scoped>
@import url(../input/input.css);
</style>
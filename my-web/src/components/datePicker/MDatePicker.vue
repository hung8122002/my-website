<template>
  <div style="position: relative">
    <input
      type="date"
      class="m-Input width-full"
      :class="{ uppercase: !isValid, addClass: showMess }"
      :placeholder="label"
      :title="title"
      v-model="value"
      :tabindex="tabIndex"
      @input="check"
    />
    <label for="" v-show="showMess" class="mess">{{ errorMess }}</label>
  </div>
</template>
  <script>
export default {
  name: "mInput",
  props: [
    "type",
    "label",
    "title",
    "modelValue",
    "errorMess",
    "showMess",
    "isReLoad",
    "tabIndex",
    "isFocused",
    "addClass",
  ],
  methods: {
    /**
     * Kiểm tra xem giá trị nhập vào có đúng là dạng ngày tháng năm không
     */
    check() {
      this.isValid = false;
      if (this.value) {
        this.isValid = true;
      }
    },
  },
  created() {
    /**
     * Kiểm tra 
     */
    this.value = this.modelValue;
    this.check();
  },
  watch: {
    value: function (newValue) {
      this.$emit("update:modelValue", newValue);
    },
  },
  data() {
    return {
      /**
       * lưu giá trị
       */
      value: null,

      /**
       * kiểm tra giá trị có hợp lệ hay không
       */
      isValid: false,
    };
  },
};
</script>
<style scoped>
@import url(../input/input.css);
</style>
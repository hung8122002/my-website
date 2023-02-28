<template>
  <div class="m-fb-box" style="position: relative" @click="closeContent">
    Số bản ghi/trang: 
    <input
      class="m-fb-header"
      readonly
      v-model="value"
      @click.stop="showContent"
    />
    <div class="m-fb-content" v-show="show">
      <ul
        class="m-fb-content-list"
        v-for="(item, index) in option"
        :key="index"
      >
        <li @click="optionSelect(item)">{{ item }}</li>
      </ul>
    </div>
  </div>
</template>
  <script>
export default {
  name: "mCombobox",
  props: ["modelValue", "addClass", "addStyle"],
  methods: {
    /**
     * hiện nội dung
     */
    showContent() {
      this.show = !this.show;
    },

    /**
     * đóng nội dung
     */
    closeContent() {
      this.show = false;
    },

    /**
     * lựa chọn nội dung
     * @param {*} item giá trị đã chọn
     */
    optionSelect(item) {
      this.value = item;
    },
  },
  created() {
    this.value = this.modelValue;
  },
  watch: {
    /**
     * cập nhật giá trị ra ngoài khi thay đổi
     * @param {*} newValue giá trị mới
     */
    value: function (newValue) {
      this.$emit("update:modelValue", newValue);
    },
  },
  data() {
    return {
      /**
       * biến dùng để ẩn hiện menu
       */
      show: false,

      /**
       * mảng các giá trị page size
       */
      option: ["10", "20", "30", "50", "100"],

      /**
       * page size đã lựa chọn, mặc định là 10
       */
      value: null,
    };
  },
};
</script>
  <style scoped>
@import url(./paging.css);
</style>
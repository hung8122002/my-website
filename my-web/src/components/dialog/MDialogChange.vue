<template>
  <div class="m-dialog-box">
    <div class="m-dialog-item">
      <MIconButton
        style="margin: 4px; top: 0"
        label="fa-solid fa-xmark"
        @click="close"
      ></MIconButton>
      <div class="m-dialog-header">Dữ liệu đã thay đổi</div>
      <div class="m-dialog-body">Lưu lại những thay đổi ?</div>
      <div class="m-dialog-footer">
        <button class="m-Btn white" @click="close">Hủy</button>
        <button class="m-Btn white" @click="closeAll">Không</button>
        <button class="m-Btn" @click="accept">Có</button>
      </div>
    </div>
  </div>
</template>
    <script>
export default {
  name: "mDialog",
  methods: {
    /**
     * Đồng ý
     */
    accept() {
      this.$emit("accept");
    },

    /**
     * Đóng form
     */
    close() {
      this.$emit("close");
    },

    /**
     * Đóng tất cả
     */
    closeAll() {
      this.$emit("closeAll");
    },
  },
};
</script>
    <style scoped>
@import url(./dialog.css);
</style>
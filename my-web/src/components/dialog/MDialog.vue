<template>
  <div class="m-dialog-box">
    <div class="m-dialog-item">
      <MIconButton
        style="margin: 4px; top: 0"
        label="fa-solid fa-xmark"
        @click="close"
      ></MIconButton>
      <div class="m-dialog-header">Xóa {{ count }} tài liệu</div>
      <div class="m-dialog-body"> Bạn có thực sự muốn xóa {{ count }} nhân viên {{ text }} không ?</div>
      <div class="m-dialog-footer">
        <button class="m-Btn white" @click="close">Hủy Bỏ</button>
        <button class="m-Btn" @click="accept">Đồng ý</button>
      </div>
    </div>
  </div>
</template>
  <script>
export default {
  name: "mDialog",
  props: ["text", "count"],
  methods: {
    /**
     * Đồng ý
     */
    accept() {
      this.$emit("accept");
    },

    /**
     * Đóng
     */
    close() {
      this.$emit("close");
    },
  },
};
</script>
  <style scoped>
@import url(./dialog.css);
</style>
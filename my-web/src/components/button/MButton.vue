<template>
  <button
    class="m-Btn"
    :tabindex="tabIndex"
    @keydown.tab="focusFirstInput"
    ref="input"
    :title="title"
  >
    {{ label }}
  </button>
</template>
<script>
export default {
  name: "mButtons",
  props: ["label", "tabIndex","title"],
  methods: {
    /**
     * Khi tab đến ô input cuối cùng thì tự động focus vào ô input đầu
     * @param {*} event sự kiện tab
     */
    focusFirstInput(event) {
      if(this.tabIndex === '19' && !event.shiftKey) {
        event.preventDefault();
        this.$emit("focusFirstInput");
      }
    },
  },
};
</script>
<style>
@import url(./button.css);
</style>
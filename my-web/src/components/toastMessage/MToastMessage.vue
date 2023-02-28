<template>
  <div class="m-toast-item">
    <div class="m-toast-icon" :class="addClass">
      <i class="fas fa-check-circle" style="font-size: 20px;"></i>
      <b style="font-size: 13px; margin-left: 10px;">{{ text }}</b>
    </div>
    <div class="m-toast-text">{{ label }}</div>
    <MIconButton label="fas fa-times" @click="toastClose"></MIconButton>
  </div>
</template>
<script>
import MIconButton from "../iconBtn/MIconButton.vue";
export default {
  name: "toastMessage",
  props: ["label","addClass","text"],
  components: {
    MIconButton,
  },
  data() {
    return {
      /**
       * ẩn hiện 
       */
      show: true,
    };
  },
  methods: {
    /**
     * ẩn toastMessage
     */
    toastClose() {
      this.$emit('close');
    },
  },
};
</script>
<style>
@import url(./toast.css);
</style>
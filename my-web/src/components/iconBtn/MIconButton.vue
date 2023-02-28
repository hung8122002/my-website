<template>
  <button type="button" class="m-IconBtn" :title="title">
    <i :class="label" :style="addStyle"></i>
  </button>
</template>
  <script>
export default {
  props: ["label", "title", "addStyle"],
  name: "mIconBtn",
};
</script>
  <style>
@import url(./icon-btn.css);
</style>
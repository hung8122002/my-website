<template>
  <label class="slider">
    <input type="checkbox" :checked="checked"/>
    <div class="checked"></div>
  </label>
</template>
  <script>
export default {
  props: ['checked'],
  name: "mCheckbox",
};
</script>
  <style scoped>
  @import url(./checkbox.css);
</style>
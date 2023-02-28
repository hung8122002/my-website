<template>
  <div style="position: relative">
    <input
      :type="type"
      class="m-Input"
      :class="addClass"
      :placeholder="label"
      :title="title"
      v-model="value"
      :tabindex="tabIndex"
      @keydown.tab="focusLastButton"
      ref="input"
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
    "addClass",
    "errorMess",
    "showMess",
    "isReLoad",
    "tabIndex",
    "isFocused",
  ],
  created() {
    /**
     * focus nếu nó là input đầu
     */
    this.value = this.modelValue;
    this.focus = this.isFocused;
    if (this.isReLoad) {
      this.value = "";
    }
  },
  methods: {
    focusLastButton(event) {
      if(this.tabIndex == 1 && event.shiftKey) {
        event.preventDefault();
        this.$emit("focusLastButton");
      }
    }
  },
  mounted() {
    /**
     * focus nếu nó là input đầu
     */
    if (this.isFocused) {
      this.$refs.input.focus();
    }
  },
  watch: {
    /**
     * theo dõi sự thay đổi của giá trị
     */
    value: function (newValue) {
      this.$emit("update:modelValue", newValue);
    },
  },
  data() {
    return {
      value: null,
      focus: false,
      isFocus: false,
    };
  },
};
</script>
<style scoped>
@import url(./input.css);
</style>
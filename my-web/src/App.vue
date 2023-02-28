<template>
  <div id="container" @click="optionclose">
    <TheSidebar></TheSidebar>
    <TheHeader :data="data" :text="text" :count="count" ref="header" @showDetail="showDetail"></TheHeader>
    <TheMain @notification="notification" :showData="showData" ref="main"></TheMain>
  </div>
</template>

<script>
import TheHeader from "./layout/TheHeader.vue";
import TheSidebar from "./layout/TheSidebar.vue";
import TheMain from "./layout/TheMain.vue";
export default {
  name: "App",
  components: {
    TheHeader,
    TheSidebar,
    TheMain,
  },
  data() {
    return {
      data: null,
      text: "",
      count: 0,
      showData: null,
    };
  },
  methods: {
    /**
     * Lập trình sự kiện click vào thẻ main
     * CreateBy: NMHUNG (26/12/2022)
     */
    optionclose() {
      this.$refs.main.$el.click();
      this.$refs.header.$el.click();
    },
    notification(newData, text) {
      this.data = newData;
      this.data.ModifiedDate = new Date()
      this.text = text;
      this.count++;
    },
    showDetail(showData) {
      this.showData = showData;
    }
  },
};
</script>

<style>
@import url(./css/main.css);
</style>

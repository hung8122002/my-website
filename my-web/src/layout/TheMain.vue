<template>
  <div id="content" @click="optionClose">
    <employeeList
      :showData="showData"
      ref="employeeList"
      @notification="notification"
    ></employeeList>
  </div>
</template>
<script>
import employeeList from "../views/employee/employeeList/EmployeeList.vue";
export default {
  name: "TheMain",
  props: ["showData"],
  components: {
    employeeList,
  },
  data() {
    return {
      notificationItem: null,
    };
  },
  methods: {
    /**
     * Lập trình sự kiện click vào thẻ cha
     * CreateBy: NMHUNG (26/12/2022)
     */
    optionClose() {
      this.$refs.employeeList.$el.click();
    },
    notification(newData, text) {
      this.$emit("notification", newData, text);
    },
  },
};
</script>
<style scoped>
</style>
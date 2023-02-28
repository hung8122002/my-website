<template>
  <div id="header" @click="closeNoti">
    <div class="header-left">
      <MIconButton
        class="header-left-icon"
        style="position: unset"
        label="fas fa-bars"
      ></MIconButton>
      <div class="header-left-text">
        CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC
        <i class="fas fa-chevron-down"></i>
      </div>
    </div>
    <div class="header-right">
      <div style="position: relative">
        <div class="m-noti-box" v-show="show">
          <div class="m-noti-item">
            <a style="color: #000">{{
              notificationList.length ? null : "Không có thông báo nào"
            }}</a>
            <a
              @click="notiClick(item)"
              :style="item.status ? 'background-color: #CCE4FF;' : ''"
              class="m-noti-text"
              v-for="(item, index) in notificationList"
              :key="index"
              >Đã {{ item.text }} nhân viên với mã
              {{ item.data.EmployeeCode }} vào lúc
              {{ formatDate(item.data.ModifiedDate) }}</a
            >
          </div>
          <div class="m-noti-arrow"></div>
        </div>
        <MIconButton
          class="header-right-icon"
          style="position: unset; color: #000"
          label="fas fa-bell"
          addStyle="color: #000"
          @click.stop="showNotification"
        >
        </MIconButton>
        <div class="numberNoti" v-show="numberNoti">{{ numberNoti }}</div>
      </div>
      <div class="header-right-text">
        <i class="fas fa-user-circle fs-24"></i>
        Nguyễn Văn Mạnh
        <i class="fas fa-chevron-down"></i>
      </div>
    </div>
  </div>
</template>
<script>
import _ from "lodash";
export default {
  name: "TheHeader",
  props: ["data", "text", "count"],
  watch: {
    count() {
      this.notification.text = this.text;
      this.notification.data = this.data;
      this.notificationList.unshift(_.cloneDeep(this.notification));
      this.numberNoti = this.notificationList.filter(
        (item) => item.status
      ).length;
    },
  },

  methods: {
    showNotification() {
      this.show = !this.show;
    },
    notiClick(item) {
      item.status = false;
      this.numberNoti > 0 ? this.numberNoti-- : 0;
      if (item.text !== "xóa") {
        this.$emit("showDetail", item.data);
      }
    },
    closeNoti() {
      this.show = false;
    },

    /**
     * định dạng thời gian
     * @returns trả về giờ: phút, ngày tháng năm
     * CreateBy: HungNM
     */
    formatDate(datetime) {
      try {
        if (datetime != null && datetime != undefined) {
          datetime = new Date(datetime);
          let date = datetime.getDate();
          date = date < 10 ? `0${date}` : date;
          let month = datetime.getMonth() + 1;
          month = month < 10 ? `0${month}` : month;
          let year = datetime.getFullYear();
          let hours = datetime.getHours();
          let minutes = datetime.getMinutes();
          return `${hours}:${minutes} ${date}/${month}/${year}`;
        } else {
          return "";
        }
      } catch (error) {
        return "";
      }
    },
  },
  data() {
    return {
      isUpdate: false,
      show: false,
      numberNoti: null,
      notification: {
        text: null,
        data: {},
        status: true,
      },
      notificationList: [],
    };
  },
};
</script>
<style scoped>
</style>
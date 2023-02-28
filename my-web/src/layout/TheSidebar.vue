<template>
  <div>
    <div id="menu" v-show="showMenu">
      <div class="menu-top">
        <div class="menu-top-icon">
          <i class="fas fa-th"></i>
        </div>
        <div class="menu-top-text m-Icon-logo"></div>
      </div>
      <div class="menu-bottom">
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fas fa-chart-pie"></i>
          </div>
          Tổng quan
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-sack-dollar"></i>
          </div>
          Tiền mặt
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-building-columns"></i>
          </div>
          Tổng tiền gửi
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-bag-shopping"></i>
          </div>
          Mua hàng
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-cart-shopping"></i>
          </div>
          Bán hàng
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-file-lines"></i>
          </div>
          Quản lý hóa đơn
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-warehouse"></i>
          </div>
          Kho
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-screwdriver-wrench"></i>
          </div>
          Công cụ dụng cụ
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-car"></i>
          </div>
          Tài sản cố định
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-landmark"></i>
          </div>
          Thuế
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-tag"></i>
          </div>
          Giá thành
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-book"></i>
          </div>
          Tổng hợp
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-dollar-sign"></i>
          </div>
          Ngân sách
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-chart-column"></i>
          </div>
          Báo cáo
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-chart-line"></i>
          </div>
          Phân tích tài chính
        </div>
      </div>
      <div style="padding: 0 12px; border-top: 1px solid #ddd">
        <div class="menu-bottom-text" @click="showMenuClick">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-chevron-left"></i>
          </div>
          Thu gọn
        </div>
      </div>
    </div>

    <!-- menu small -->
    <div id="small-menu" v-show="showSmallMenu">
      <div class="menu-top">
        <div
          class="menu-top-text m-Icon-logo"
          style="background-position: 3px"
        ></div>
      </div>
      <div class="menu-bottom">
        <div class="menu-bottom-item" style="position: relative">
          <div class="small menu-bottom-item-icon">
            <i class="fas fa-chart-pie"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-sack-dollar"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-building-columns"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-bag-shopping"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-cart-shopping"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-file-lines"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-warehouse"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-screwdriver-wrench"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-car"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-landmark"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-tag"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-book"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-dollar-sign"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-chart-column"></i>
          </div>
        </div>
        <div class="menu-bottom-item">
          <div class="small menu-bottom-item-icon">
            <i class="fa-solid fa-chart-line"></i>
          </div>
        </div>
      </div>
      <div style="padding: 0 12px; border-top: 1px solid #ddd">
        <div class="menu-bottom-text">
          <div class="small menu-bottom-item-icon" @click="showMenuClick">
            <i class="fa-solid fa-chevron-right"></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "TheSidebar",
  methods: {
    showMenuClick() {
      this.showMenu = !this.showMenu;
      this.showSmallMenu = !this.showSmallMenu;
      if (this.showMenu) {
        document
          .querySelector(":root")
          .style.setProperty("--menu-width", "200px");
      } else {
        document
          .querySelector(":root")
          .style.setProperty("--menu-width", "73px");
      }
    },
  },
  data() {
    return {
      showMenu: true,
      showSmallMenu: false,
    };
  },
};
</script>
<style scoped>
</style>
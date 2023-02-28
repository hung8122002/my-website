<template>
  <div class="m-combobox" style="position: relative" @click="closeContent">
    <input
      ref="input"
      class="m-combobox-header"
      :class="addClass"
      @keydown="keyDown"
      v-model="value"
      @input="onSearch"
      :tabindex="tabIndex"
    />
    <label for="" v-show="showMess" class="mess">{{ errorMess }}</label>
    <MIconButton
      label="fa-solid fa-chevron-down"
      addStyle="font-size: 13px;"
      @click.stop="showContent"
      @keydown="keyDown"
    ></MIconButton>
    <div class="m-combobox-content" v-show="show">
      <a
        :value="item[propValue]"
        :class="{ itemSeleted: index == indexItem }"
        v-for="(item, index) in entitiesSearch"
        :key="index"
        @click="optionSelect(item, index)"
      >
        {{ item[propName] }}
      </a>
    </div>
  </div>
</template>
    <script>
import MIconButton from "../iconBtn/MIconButton.vue";
import axios from "axios";
export default {
  name: "mCombobox",
  props: [
    "modelValue",
    "addClass",
    "api",
    "propName",
    "propValue",
    "errorMess",
    "showMess",
    "tabIndex",
  ],
  components: {
    MIconButton,
  },
  methods: {
    /**
     * Ẩn hiện bảng chọn
     * CreateBy: NMHUNG (26/12/2022)
     */
    showContent() {
      this.indexItem = this.indexItemDefault;
      this.entitiesSearch = this.entities;
      this.show = !this.show;
      if (this.show) {
        this.$emit("closeOthers");
      }
    },

    /**
     * Đóng bảng chọn khi click vào thẻ cha
     * CreateBy: NMHUNG (26/12/2022)
     */
    closeContent() {
      this.show = false;
    },

    /**
     * Xử lí khi click vào mỗi sự lựa chọn
     * CreateBy: NMHUNG (26/12/2022)
     */
    optionSelect(item, index) {
      this.indexItemDefault = this.entities.findIndex(
        (find) => find[this.propValue] == item.PositionId
      );
      this.indexItem = index;
      this.value = item[this.propName];
      this.$emit("update:modelValue", item[this.propValue]);
      this.show = false;
    },

    /**
     * tìm item tương ứng với modelvalue
     * CreateBy: NMHUNG (26/12/2022)
     */
    setItemSelected() {
      let me = this;
      // tìm item tương ứng với modelvalue
      let entitySelected = this.entities.find(
        (item) => item[me.propValue] == me.modelValue
      );
      if (entitySelected) {
        this.value = entitySelected[this.propName];
      }
    },

    /**
     * tìm kiếm khi nhập chữ
     * CreateBy: NMHUNG (26/12/2022)
     */
    onSearch() {
      let me = this;
      this.indexItem = -1;
      this.count = 1;
      // tìm item tương ứng với modelvalue
      this.entitiesSearch = this.entities.filter((item) =>
        item[me.propName].toLowerCase().includes(me.value.toLowerCase())
      );
      if (this.entitiesSearch.length) {
        this.show = true;
      } else {
        this.show = false;
      }
    },

    /**
     * Xử lý khi nhấn nút xuống
     * CreateBy: NMHUNG (26/12/2022)
     */
    keyDown(event) {
      switch (event.keyCode) {
        case this.enum.KEY_CODE.ENTER:
          // eslint-disable-next-line no-case-declarations
          try {
            const item = this.entitiesSearch[this.indexItem];
            this.optionSelect(item, this.indexItem);
            this.entitiesSearch = this.entities;
            this.count = 0;
            this.indexItem = this.indexItemDefault;
          } catch (error) {
            error;
          }
          break;
        case this.enum.KEY_CODE.ROW_DOWN:
          this.show = true;
          if (this.count == 0) {
            this.count++;
            break;
          }
          if (this.indexItem < this.entitiesSearch.length - 1) {
            this.indexItem++;
          }
          break;
        case this.enum.KEY_CODE.ROW_UP:
          if (this.indexItem > 0) {
            this.indexItem--;
          }
          break;
      }
    },
  },
  created() {
    /**
     * Lấy dữ liệu khi khởi tạo
     */
    if (this.api) {
      axios
        .get(this.api)
        .then((data) => {
          this.entities = data.data.data;
          this.entitiesSearch = data.data.data;
          this.setItemSelected();
        })
        .catch((res) => {
          console.log(res);
        });
    }
  },
  watch: {
  },
  data() {
    return {
      /**
       * biến dùng để ẩn hiện menu
       */
      show: false,

      /**
       * lưu giá trị đã chọn
       */
      value: null,

      /**
       * mảng các giá trị hiện ra
       */
      entities: [],

      /**
       * mảng các giá trị dùng để tìm kiếm
       */
      entitiesSearch: [],

      /**
       * lưu vị trí item khi tìm kiếm
       */
      indexItem: -1,

      /**
       * lưu vị trí item mặc định
       */
      indexItemDefault: -1,

      count: 0,
    };
  },
};
</script>
    <style scoped>
@import url(./combobox.css);
</style>
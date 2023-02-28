const MISAEnum = {
  /**
   * định nghĩa các thao tác với bàn phím
   */
  KEY_CODE: {
    /**
     * nút enter
     */
    ENTER: 13,
    /**
     * nút lên
     */
    ROW_UP: 38,
    /**
     * nút xuống
     */
    ROW_DOWN: 40,
    /**
     * nút s
     */
    S_BTN: 83,
  },

  /**
   * định nghĩa các hành động của form
   */
  FORM_MODE: {
    /**
     * Thêm
     */
    ADD: 1,
    /**
     * sửa
     */
    UPDATE: 2,
    /**
     * Xem
     */
    VIEW: 3,
  },
  /**
   * định nghĩa giới tính
   */
  GENDER: {
    /**
     * name
     */
    MALE: 0,
    /**
     * nữ
     */
    FEMALE: 1,
    /**
     * khác
     */
    OTHER: 2,
  },
};

export default MISAEnum;

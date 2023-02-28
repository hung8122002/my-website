import base from "./baseServevice";
/**
 * api của position
 * CreateBy: NMHUNG (26/12/2022)
 */
class position extends base {
  /**
   * lấy toàn bộ vị trí
   * CreateBy: NMHUNG (26/12/2022)
   */
  getPosition() {
    return `${this.getBaseEndPoint()}Position/get-5-positions`;
  }
}

const positionApi = new position();
export default positionApi;

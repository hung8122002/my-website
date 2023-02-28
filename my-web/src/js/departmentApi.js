import base from "./baseServevice";
/**
 * Api lấy thông tin phòng ban
 */
class department extends base {
  /**
   * Api lấy thông tin phòng ban
   * @returns trả về 10 phòng ban đầu tiên
   */
  getDepartment() {
    return `${this.getBaseEndPoint()}Department/get-5-departments`;
  }
}

const departmentApi = new department();
export default departmentApi;

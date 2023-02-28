import base from "./baseServevice";
/**
 * Api của nhân viên
 * CreateBy: HungNM
 */
class employee extends base {

  /**
   * Api lấy chung của employee
   * @returns api url employee
   * CreateBy: HungNM
   */
  getEmployee() {
    return `${this.getBaseEndPoint()}Employees/`;
  }

  /**
   * Api lấy phân trang của employee
   * @returns api url employee
   * CreateBy: HungNM
   */
  getEmployeefilter() {
    return `${this.getEmployee()}filter`;
  }

  /**
   * Api lấy mã mới của employee
   * @returns api url employee
   * CreateBy: HungNM
   */
  getNewEmployeeCode() {
    return `${this.getEmployee()}new-code`;
  }

  /**
   * Api tạo query của employee
   * @returns query
   * CreateBy: HungNM
   */
  filterQuery(
    pageSize = "",
    pageNumber = "",
    employeeFilter = "",
    departmentId = "",
    positionId = ""
  ) {
    return `?keyWord=${employeeFilter}&departmentId=${departmentId}&positionId=${positionId}&limit=${pageSize}&offset=${pageNumber}`;
  }

  /**
   * Định dạng id để tìm kiếm
   * CreateBy: NMHUNG (26/12/2022)
   */
  filterById(id = "") {
    return id;
  }
}

const employeeApi = new employee();
export default employeeApi;

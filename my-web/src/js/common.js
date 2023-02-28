const commonJS = {
  /**
   * Định dạng ngày tháng để hiển thị mà không cần input
   * @param {*} datetime : ngày tháng
   * @returns trả về dạng dd/mm/yyyy
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
        return `${date}/${month}/${year}`;
      } else {
        return "";
      }
    } catch (error) {
      return "";
    }
  },

  /**
   * Định dạng ngày tháng để lưu vào input
   * @param {*} datetime : ngày tháng
   * @returns trả về dạng yyyy/mm/dd
   */
  formatDateTime(datetime) {
    try {
      if (datetime != null && datetime != undefined) {
        datetime = new Date(datetime);
        let date = datetime.getDate();
        date = date < 10 ? `0${date}` : date;
        let month = datetime.getMonth() + 1;
        month = month < 10 ? `0${month}` : month;
        let year = datetime.getFullYear();
        return `${year}-${month}-${date}`;
      } else {
        return "";
      }
    } catch (error) {
      return "";
    }
  },

  /**
   * Định dạng tiền
   * @param {*} salary : lương
   * @returns định dạng lại lương
   */
  formatmoney(salary) {
    try {
      return new Intl.NumberFormat("vi-VN", {
        currency: "VND",
      }).format(salary);
    } catch (error) {
      return "";
    }
  },

  /**
   * Định dạng giới tính
   * @param {*} gender : giới tính
   * @returns trả về "Nam" nếu là 0, "Nữ" nếu là 1 và 2 là "Khác"
   */
  formatGender(gender) {
    try {
      if (gender == 0) {
        return "Nam";
      } else if (gender == 1) {
        return "Nữ";
      } else {
        return "Khác";
      }
    } catch (error) {
      return "";
    }
  },

  /**
   * Kiểm ta khoảng trắng hoặc null
   * @param {*} text : chuỗi cần kiểm tra
   * @returns true nếu có khoảng trắng hoặc null
   */
  isNull(text) {
    if (text) {
      if (text.trim().length) {
        return false;
      }
    }
    return true;
  },

  /**
   * Kiểm ta mã nhân viên đã tồn tại hay chưa
   * @param {*} code : mã
   * @returns true nếu tên sai và false nếu tên đúng
   */
  isExist(code) {
    fetch(
      `https://cukcuk.manhnv.net/api/v1/Employees/filter?employeeFilter=${code}`
    ).then((res) => {
      if (res.status == 200) {
        return true;
      } else {
        return false;
      }
    });
  },

  /**
   * Kiểm ta định dạng mã
   * @param {*} name : mã
   * @returns true nếu mã đúng và false nếu mã sai
   */
  regexCode(code) {
    return /^([N,V]{2}-[0-9]{5})$/.test(code);
  },

  /**
   * Kiểm ta định dạng tên
   * @param {*} name : tên
   * @returns true nếu tên sai và false nếu tên đúng
   */
  regexName(name) {
    return /[\d!@#$%^&*]/g.test(name) || /\s\s+/g.test(name);
  },

  /**
   * Kiểm ta định dạng chuỗi số
   * @param {*} number : chuỗi số
   * @returns
   */
  regexNumber(number) {
    return /[a-zA-Z!@#$%^&*\\]/g.test(number);
  },

  /**
   * Kiểm ta định dạng email
   * @param {*} email : email
   * @returns
   */
  regexEmail(email) {
    return !/@[a-z]+/g.test(email) || /\s/g.test(email);
  },

  /**
   * Xử lý các trang sẽ hiện ra trên trình duyệt
   * @param {*} totalPage : Số trang
   * @param {*} currentPage : Trang hiện tại
   * @returns một mảng chứa các số trang sẽ hiện ra trên trình duyệt
   */
  pagingRange(totalPage, currentPage) {
    var startPage = currentPage - 2 <= 0 ? 1 : currentPage - 2;
    if (currentPage > totalPage - 3) {
      startPage = totalPage - 4;
    }
    var endPage = currentPage + 2 >= totalPage ? totalPage : currentPage + 2;
    if (currentPage <= 3) {
      endPage = 5;
    }
    if (totalPage < 5) {
      endPage = totalPage;
      startPage = 1;
    }
    var Range = [];
    for (var i = startPage; i <= endPage; i++) {
      Range.push(i);
    }
    return Range;
  },

  /**
   * Xuất ra file excel
   * @param {*} data dữ liệu đầu vào
   * CreatedBy: HungNM
   */
  exportExcel(data) {
    var newData = [];
    data.forEach((item) => {
      var fomatData = {
        Code: "",
        Name: "",
        Gender: null,
        DateOfBirth: null,
        Salary: null,
      };
      fomatData.Code = item.EmployeeCode;
      fomatData.Name = item.FullName;
      fomatData.DateOfBirth = item.DateOfBirth;
      fomatData.Salary = item.Salary;
      fomatData.Gender = this.formatGender(item.Gender);
      newData.push(fomatData);
    });
    const cell = { 
      v: 'Giá trị của ô',
      s: {
        border: {
          top: { style: 'thin', color: { rgb: '000000' } },
          bottom: { style: 'thin', color: { rgb: '000000' } },
          left: { style: 'thin', color: { rgb: '000000' } },
          right: { style: 'thin', color: { rgb: '000000' } }
        }
      }
    };
    const XLSX = require("xlsx");
    const wb = XLSX.utils.book_new();
    const ws = XLSX.utils.json_to_sheet(newData);
    XLSX.utils.sheet_add_cell(ws, cell);
    XLSX.utils.book_append_sheet(wb, ws, "DANH SÁCH NHÂN VIÊN");
    XLSX.writeFile(wb, "Danh_sach_nhan_vien.xlsx");
  },

  /**
   * so sánh sâu 2 phần tử
   * @param {*} obj1 phần tử 1
   * @param {*} obj2 phần tử 2
   * @returns
   */
  deepCompare(obj1, obj2) {
    // Lấy danh sách các thuộc tính của obj1 và obj2
    const keys1 = Object.keys(obj1);
    // So sánh từng cặp giá trị trong obj1 và obj2 bằng cách sử dụng đệ quy
    if (keys1.length > 9) {
      for (const key of keys1) {
        if (obj1[key] !== obj2[key] && obj2[key]) {
          return false;
        }
      }
      for (const key of keys1) {
        if (!obj1[key] && !obj2[key]) {
          return true;
        }
      }
    }
    // Nếu không có khác biệt nào giữa hai object, trả về true
    return true;
  },
};
export default commonJS;

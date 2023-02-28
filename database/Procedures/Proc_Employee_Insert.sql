DELIMITER $$

CREATE PROCEDURE Proc_Employee_Insert(IN p_EmployeeId char(36), IN p_EmployeeCode varchar(25), IN p_FullName varchar(255), IN p_Gender int, IN p_PositionId char(36), IN p_DepartmentId char(36), IN p_CreateDate datetime, IN p_CreateBy varchar(255), IN p_ModifiedDate timestamp, IN p_ModifiedBy varchar(255), IN p_DateOfBirth datetime, IN p_Email varchar(50), IN p_PhoneNumber varchar(255), IN p_Salary int, IN p_IdentityNumber varchar(25), IN p_IdentityDate datetime, IN p_IdentityPlace varchar(255), IN p_BankAccount varchar(25), IN p_BankName varchar(255), IN p_Address varchar(255))
  COMMENT 'Thêm mới'
BEGIN
  -- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Thêm mới nhân viên
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_Insert()
  INSERT INTO employee (EmployeeId,
  EmployeeCode,
  FullName,
  Gender,
  DepartmentId,
  PositionId,
  CreateDate,
  CreateBy,
  ModifiedDate,
  ModifiedBy,
  DateOfBirth,
  Email,
  PhoneNumber,
  Salary,
  IdentityNumber,
  IdentityDate,
  IdentityPlace,
  BankAccount,
  BankName,
  Address)
    VALUE (p_EmployeeId, p_EmployeeCode, p_FullName, p_Gender, p_DepartmentId, p_PositionId, p_CreateDate, p_CreateBy, p_ModifiedDate, p_ModifiedBy, p_DateOfBirth, p_Email, p_PhoneNumber, p_Salary, IdentityNumber, p_IdentityDate, p_IdentityPlace, p_BankAccount, p_BankName, p_Address);
END
$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE Proc_Employee_Update(IN p_EmployeeId char(36), IN p_EmployeeCode varchar(25), IN p_FullName varchar(255), IN p_Gender int, IN p_DepartmentId char(36), IN p_PositionId char(36), IN p_ModifiedDate timestamp, IN p_ModifiedBy varchar(255), IN p_DateOfBirth datetime, IN p_Email varchar(50), IN p_PhoneNumber varchar(255), IN p_Salary int, IN p_IdentityNumber varchar(25), IN p_IdentityDate datetime, IN p_IdentityPlace varchar(255), IN p_BankAccount varchar(25), IN p_BankName varchar(255), IN p_Address varchar(255))
  COMMENT 'Sửa theo Id'
BEGIN
  -- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Cập nhật nhân viên
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_Update()
  UPDATE employee e
  SET e.EmployeeCode = p_EmployeeCode,
      e.FullName = p_FullName,
      e.Gender = p_Gender,
      e.DepartmentId = p_DepartmentId,
      e.PositionId = p_PositionId,
      e.ModifiedDate = p_ModifiedDate,
      e.ModifiedBy = p_ModifiedBy,
      e.DateOfBirth = p_DateOfBirth,
      e.Email = p_Email,
      e.PhoneNumber = p_PhoneNumber,
      e.Salary = p_Salary,
      e.Address = p_Address,
      e.IdentityNumber = p_IdentityNumber,
      e.IdentityDate = p_IdentityDate,
      e.IdentityPlace = p_IdentityPlace,
      e.BankName = p_BankName,
      e.BankAccount = p_BankAccount
  WHERE e.EmployeeId = p_EmployeeId;
END
$$

DELIMITER ;
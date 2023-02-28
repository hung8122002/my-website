DELIMITER $$

CREATE PROCEDURE Proc_Employee_Delete(IN p_EmployeeId char(36))
  COMMENT 'Xóa theo Id'
BEGIN
-- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Xóa nhân viên theo ID
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_Delete('4ae92c30-1bd2-21bc-157f-9b9c7c262a46');
  DELETE
    FROM employee 
  WHERE EmployeeId = p_EmployeeId;
END
$$

DELIMITER ;
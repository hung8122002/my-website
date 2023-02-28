DELIMITER $$

CREATE PROCEDURE Proc_Employee_FindByCode(IN p_EmployeeCode varchar(25))
  COMMENT 'Tìm theo mã '
BEGIN
-- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Tìm nhân viên theo mã
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_Filter(NULL, 10, 0)
  SELECT
    *
  FROM employee e
  WHERE e.EmployeeCode = p_EmployeeCode;
END
$$

DELIMITER ;
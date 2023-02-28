DELIMITER $$

CREATE PROCEDURE Proc_Employee_GetMaxCode()
  COMMENT 'Lấy mã mới'
BEGIN
-- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Lấy mã nhân viên mới
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_GetMaxCode()
  SELECT
    CONCAT('NV-', (CONVERT(SUBSTRING(MAX(e.EmployeeCode), 4), UNSIGNED) + 1)) AS 'NewCode'
  FROM employee e;
END
$$

DELIMITER ;
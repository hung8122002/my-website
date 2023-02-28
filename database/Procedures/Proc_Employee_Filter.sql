DELIMITER $$

CREATE PROCEDURE Proc_Employee_Filter(IN p_Text varchar(255), IN p_Limit int, IN p_Offset int)
  COMMENT 'Tìm kiếm và phân trang'
BEGIN
-- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Phân trang và tìm kiếm nhân viên
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_FindByCode('NV-12345')
  SET p_Text = CONCAT('%', COALESCE(p_Text, ''), '%');
  SELECT
    *
  FROM employee e
    LEFT JOIN department d
      ON e.DepartmentId = d.DepartmentId
    LEFT JOIN positionat p
      ON e.PositionId = p.PositionId
  WHERE e.EmployeeCode LIKE p_Text
  OR e.FullName LIKE p_Text
  ORDER BY e.ModifiedDate DESC
  LIMIT p_Limit OFFSET p_Offset;

  SELECT
    COUNT(e.EmployeeId) AS 'TotalRecord',
    CEILING((COUNT(e.EmployeeId) / p_Limit)) AS 'TotalPage'
  FROM employee e
  WHERE e.EmployeeCode LIKE p_Text
  OR e.FullName LIKE p_Text;
END
$$

DELIMITER ;
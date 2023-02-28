DELIMITER $$

CREATE PROCEDURE Proc_Department_Filter(IN p_Offset int)
  COMMENT 'Tìm kiếm và phân trang'
BEGIN
-- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Phân trang phòng ban
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Department_Filter(0);
  SET @p_Limit = 5;
  SELECT
    *
  FROM department d
  LIMIT 10 OFFSET p_Offset;

  SELECT
    COUNT(d.DepartmentId) AS 'TotalRecord',
    CEILING((COUNT(d.DepartmentId) / @p_Limit)) AS 'TotalPage'
  FROM department d;
END
$$

DELIMITER ;
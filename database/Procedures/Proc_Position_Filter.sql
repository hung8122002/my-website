DELIMITER $$

CREATE PROCEDURE Proc_Position_Filter(IN p_Offset int)
  COMMENT 'Tìm kiếm và phân trang'
BEGIN
-- =============================================
  -- Author:        HungNM
  -- Created date:  13/01/2023
  -- Description:   Phân trang theo vị trí
  -- Modified by:   
  -- Code chạy thử: CALL Proc_Employee_Filter(0)
  SELECT
    *
  FROM positionat p LIMIT 10 OFFSET p_Offset;

  SELECT
    COUNT(p.PositionId) AS 'TotalRecord',
    CEILING((COUNT(p.PositionId) / 5)) AS 'TotalPage'
  FROM positionat p;
END
$$

DELIMITER ;
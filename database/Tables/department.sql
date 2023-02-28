CREATE TABLE department (
  DepartmentId CHAR(36) NOT NULL DEFAULT '' COMMENT 'Id phòng ban',
  DepartmentName VARCHAR(255) NOT NULL DEFAULT '',
  PRIMARY KEY (DepartmentId)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 1638,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Phòng ban',
ROW_FORMAT = DYNAMIC;
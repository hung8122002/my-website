CREATE TABLE employee (
  EmployeeId CHAR(36) NOT NULL DEFAULT '' COMMENT 'Id nhân viên',
  EmployeeCode VARCHAR(25) NOT NULL DEFAULT '' COMMENT 'Mã nhân viên',
  FullName VARCHAR(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '' COMMENT 'Tên nhân viên',
  Gender INT DEFAULT NULL COMMENT 'Giới tính (Nam = 0, Nữ = 1, Khác = 2)',
  DepartmentId CHAR(36) NOT NULL DEFAULT '' COMMENT 'Id phòng ban',
  PositionId CHAR(36) NOT NULL DEFAULT '' COMMENT 'Id vị trí',
  CreateDate DATETIME DEFAULT NULL COMMENT 'Ngày tạo',
  CreateBy VARCHAR(255) DEFAULT NULL COMMENT 'Người tạo',
  ModifiedDate TIMESTAMP NULL DEFAULT NULL COMMENT 'Ngày cập nhật',
  ModifiedBy VARCHAR(255) DEFAULT NULL COMMENT 'Người cập nhật',
  DateOfBirth DATETIME DEFAULT NULL COMMENT 'Ngày sinh',
  Email VARCHAR(50) DEFAULT NULL COMMENT 'Email',
  PhoneNumber VARCHAR(255) DEFAULT NULL COMMENT 'Sô điện thoại',
  Salary INT DEFAULT NULL,
  IdentityNumber VARCHAR(25) DEFAULT NULL COMMENT 'Số chứng minh nhân dân',
  IdentityDate DATETIME DEFAULT NULL,
  Address VARCHAR(255) DEFAULT NULL,
  BankAccount VARCHAR(25) DEFAULT NULL,
  BankName VARCHAR(255) DEFAULT NULL,
  IdentityPlace VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (EmployeeId)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 523,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
COMMENT = 'Bảng nhân viên',
ROW_FORMAT = DYNAMIC;

ALTER TABLE employee 
  ADD INDEX IDX_employee_FullName(FullName);

ALTER TABLE employee 
  ADD UNIQUE INDEX IX_employee_EmployeeCode(EmployeeCode);

ALTER TABLE employee 
  ADD UNIQUE INDEX iX_employee_EmployeeId(EmployeeId);

ALTER TABLE employee 
  ADD CONSTRAINT FK_employee_p_DepartmentId FOREIGN KEY (DepartmentId)
    REFERENCES department(DepartmentId);

ALTER TABLE employee 
  ADD CONSTRAINT FK_employee_p_PositionId FOREIGN KEY (PositionId)
    REFERENCES positionat(PositionId);
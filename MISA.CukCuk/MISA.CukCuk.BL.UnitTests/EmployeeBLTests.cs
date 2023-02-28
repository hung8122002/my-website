using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Resources;
using MISA.CukCuk.DL.EmployeeDL;
using NSubstitute;

namespace MISA.CukCuk.BL.UnitTests
{

    //TODO: abc
    public class EmployeeBLTests
    {
        static Employee employeeTest = new Employee
        {
            EmployeeCode = "NV-12345",
            FullName = "Nguyễn Văn A"
        };
        #region Field
        private IEmployeeBL _employeeBL;
        private IEmployeeDL _fakeEmployeeDL;
        #endregion

        [SetUp]
        public void SetUp()
        {
            _fakeEmployeeDL = Substitute.For<IEmployeeDL>();
            _employeeBL = new EmployeeBL(_fakeEmployeeDL);
        }

        [Test]
        public void InsertRecord_EmptyCode_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = "Nguyễn Văn A"
            };
            employee.EmployeeCode = "";
            List<ErrorResult> listError = new List<ErrorResult>();
            listError.Add(
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                    DevMsg = "EmployeeCode is empty",
                    UserMsg = "EmployeeCode is empty"
                }
                );
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
        }

        [Test]
        public void InsertRecord_EmptyName_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = "Nguyễn Văn A"
            };
            employee.FullName = "";
            List<ErrorResult> listError = new List<ErrorResult>();
            listError.Add(
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                    DevMsg = "FullName is empty",
                    UserMsg = "FullName is empty"
                }
                );
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
        }

        [Test]
        public void InsertRecord_MultiEmpty_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = "Nguyễn Văn A"
            };
            employee.FullName = "";
            employee.EmployeeCode = "";
            List<ErrorResult> listError = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                    DevMsg = "EmployeeCode is empty",
                    UserMsg = "EmployeeCode is empty"
                },
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                    DevMsg = "FullName is empty",
                    UserMsg = "FullName is empty"
                },
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg); 
            Assert.AreEqual(expectResult.listError[1].ErrorCode, actualResult.listError[1].ErrorCode);
            Assert.AreEqual(expectResult.listError[1].UserMsg, actualResult.listError[1].UserMsg);
            Assert.AreEqual(expectResult.listError[1].DevMsg, actualResult.listError[1].DevMsg);
        }

        [Test]
        public void InsertRecord_InvalidCode_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12",
                FullName = "Nguyễn Văn A"
            };
            List<ErrorResult> listError = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidCode,
                    DevMsg = Resource.DevMsg_InvalidCode,
                    UserMsg = Resource.UserMsg_InvalidCode,
                },
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            _fakeEmployeeDL.GetByCode(employee.EmployeeCode).Returns(1);
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
        }

        [Test]
        public void InsertRecord_DuplicateCode_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = "Nguyễn Văn A"
            };
            List<ErrorResult> listError = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.DuplicateCode,
                    DevMsg = Resource.UserMsg_DuplicateCode,
                    UserMsg = Resource.UserMsg_DuplicateCode,
                },
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            _fakeEmployeeDL.GetByCode(employee.EmployeeCode).Returns(1);
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
        }

        [TestCase("Nguyễn 123")]
        [TestCase("!@#$")]
        [Test]
        public void InsertRecord_InvalidName_ReturnsInvalid(string name)
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = name
            };
            List<ErrorResult> listError = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidName,
                    DevMsg = Resource.DevMsg_InvalidName,
                    UserMsg = Resource.UserMsg_InvalidName,
                },
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
        }

        [Test]
        public void InsertRecord_MultiError_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-123",
                FullName = "123"
            };
            List<ErrorResult> listError = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidCode,
                    DevMsg = Resource.DevMsg_InvalidCode,
                    UserMsg = Resource.UserMsg_InvalidCode,
                },
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidName,
                    DevMsg = Resource.DevMsg_InvalidName,
                    UserMsg = Resource.UserMsg_InvalidName,
                },
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
            Assert.AreEqual(expectResult.listError[1].ErrorCode, actualResult.listError[1].ErrorCode);
            Assert.AreEqual(expectResult.listError[1].UserMsg, actualResult.listError[1].UserMsg);
            Assert.AreEqual(expectResult.listError[1].DevMsg, actualResult.listError[1].DevMsg);
        }

        [Test]
        public void InsertRecord_ErrorAndEmpty_ReturnsInvalid()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "",
                FullName = "123"
            };
            List<ErrorResult> listError = new List<ErrorResult>
            {
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidInput,
                    DevMsg = "EmployeeCode is empty",
                    UserMsg = "EmployeeCode is empty",
                },
                new ErrorResult
                {
                    ErrorCode = Common.Enum.ErrorCode.InvalidName,
                    DevMsg = Resource.DevMsg_InvalidName,
                    UserMsg = Resource.UserMsg_InvalidName,
                },
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                listError = listError
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.listError[0].ErrorCode, actualResult.listError[0].ErrorCode);
            Assert.AreEqual(expectResult.listError[0].UserMsg, actualResult.listError[0].UserMsg);
            Assert.AreEqual(expectResult.listError[0].DevMsg, actualResult.listError[0].DevMsg);
            Assert.AreEqual(expectResult.listError[1].ErrorCode, actualResult.listError[1].ErrorCode);
            Assert.AreEqual(expectResult.listError[1].UserMsg, actualResult.listError[1].UserMsg);
            Assert.AreEqual(expectResult.listError[1].DevMsg, actualResult.listError[1].DevMsg);
        }

        [Test]
        public void InsertRecord_Faild_ReturnsFails()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = "Nguyễn Văn A"
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = false,
                Data = null
            };
            // Act
            _fakeEmployeeDL.GetByCode(employee.EmployeeCode).Returns(0);
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(0);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.Data, actualResult.Data);
        }

        [Test]
        public void InsertRecord_Success_ReturnsSuccess()
        {
            // Arrage
            var employee = new Employee
            {
                EmployeeCode = "NV-12345",
                FullName = "Nguyễn Văn A"
            };
            var expectResult = new ValidateResult
            {
                IsSuccess = true,
                Data = 0
            };
            // Act
            var actualResult = _employeeBL.InsertRecord(employee);
            _fakeEmployeeDL.InsertRecord(employee).Returns(1);

            // Assert
            Assert.AreEqual(expectResult.IsSuccess, actualResult.IsSuccess);
            Assert.AreEqual(expectResult.Data, actualResult.Data);
        }
    }
}

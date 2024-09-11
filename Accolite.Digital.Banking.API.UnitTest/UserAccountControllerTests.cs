namespace Accolite.Digital.Banking.API.UnitTest
{
    using System.Net;
    using Accolite.Digital.Banking.API.Controllers;
    using Accolite.Digital.Banking.Common.DTO;
    using Accolite.Digital.Banking.Common.Services.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class UserAccountControllerTests
    {
        private Mock<IAccountService> _mockAccountService;
        private UserAccountController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockAccountService = new Mock<IAccountService>();
            _controller = new UserAccountController(_mockAccountService.Object);
        }

        [TestMethod]
        public void CreateAccounts_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var accountDto = new AccountDto();
            var responseDTO = new ResponseDTO();
            _mockAccountService.Setup(service => service.CreateAccount(accountDto)).Returns(responseDTO);

            // Act
            var result = _controller.CreateAccounts(accountDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(responseDTO, result.Value);
        }

        [TestMethod]
        public void GetAccountbyUser_ExistingUser_ReturnsOkResult()
        {
            // Arrange
            long userId = 1;
            var dto = new ResponseDTO();
            _mockAccountService.Setup(service => service.GetAllAccountsByUser(userId)).Returns(dto);

            // Act
            var result = _controller.GetAccountbyUser(userId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(dto, result.Value);
        }

        [TestMethod]
        public void DeleteAccount_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            string accountNumber = "123";
            long userId = 1;
            var responseDTO = new ResponseDTO();
            _mockAccountService.Setup(service => service.DeleteAccount(accountNumber, userId)).Returns(responseDTO);

            // Act
            var result = _controller.DeleteAccount(accountNumber, userId) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(responseDTO, result.Value);
        }

        [TestMethod]
        public void WithdrawMoney_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var withdrawRequestDto = new WithDrawRequestDto();
            var responseDTO = new ResponseDTO();
            _mockAccountService.Setup(service => service.WithdrawMoney(withdrawRequestDto)).Returns(responseDTO);

            // Act
            var result = _controller.WithdrawMoney(withdrawRequestDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(responseDTO, result.Value);
        }

        [TestMethod]
        public void DepositMoney_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var depositRequestDto = new DepositRequestDto();
            var responseDTO = new ResponseDTO();
            _mockAccountService.Setup(service => service.DepositMoney(depositRequestDto)).Returns(responseDTO);

            // Act
            var result = _controller.DepositMoney(depositRequestDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(responseDTO, result.Value);
        }
    }

}
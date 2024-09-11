using System.Collections.Generic;
using System.Linq;
using Accolite.Digital.Banking.Common.Data;
using Accolite.Digital.Banking.Common.DTO;
using Accolite.Digital.Banking.Common.Entities;
using Accolite.Digital.Banking.Common.Services;
using Accolite.Digital.Banking.Common.Services.Interface;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace Accolite.Digital.Banking.Common.UnitTest
{
   
        [TestClass]
        public class AccountServiceTests
        {
            private Mock<IDataService> _mockDataService;
            private Mock<IMapper> _mockMapper;
            private AccountService _accountService;

            [TestInitialize]
            public void Setup()
            {
                _mockDataService = new Mock<IDataService>();
                _mockMapper = new Mock<IMapper>();
                _accountService = new AccountService(_mockDataService.Object, _mockMapper.Object);
            }

            [TestMethod]
            public void CreateAccount_ValidDto_Success()
            {
                // Arrange
                var accountDto = new AccountDto { /* initialize with valid data */ };
                var account = new Account(); // Initialize as needed

                _mockMapper.Setup(m => m.Map<Account>(accountDto)).Returns(account);
                _mockDataService.Setup(ds => ds.SaveAccount(account));

                // Act
                var result = _accountService.CreateAccount(accountDto);

                // Assert
                Assert.IsTrue(result.IsSuccess);
                Assert.AreEqual("Success", result.Message);
            }

            [TestMethod]
            public void GetAllAccountsByUser_ExistingUser_ReturnsAccounts()
            {
                // Arrange
                long userId = 1;
                var accounts = new List<Account> { new Account { /* initialize as needed */ } };
                var responseDTO = new ResponseDTO { IsSuccess = true, Message = "Success", Result = accounts };

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(userId)).Returns(accounts);

                // Act
                var result = _accountService.GetAllAccountsByUser(userId);

                // Assert
                Assert.IsTrue(result.IsSuccess);
                Assert.AreEqual("Success", result.Message);
                Assert.IsNotNull(result.Result);
                Assert.IsInstanceOfType(result.Result, typeof(List<Account>));
            }

            [TestMethod]
            public void DeleteAccount_AccountExists_DeletesSuccessfully()
            {
                // Arrange
                string accountNumber = "123";
                long userId = 1;
                var account = new Account { AccountNumber = accountNumber, AccountStatus = true };

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(userId)).Returns(new List<Account> { account });

                // Act
                var result = _accountService.DeleteAccount(accountNumber, userId);

                // Assert
                Assert.IsTrue(result.IsSuccess);
                Assert.AreEqual("Delete Success", result.Message);
                Assert.IsFalse(account.AccountStatus); // Check if status is updated
            }

            [TestMethod]
            public void WithdrawMoney_ValidRequest_Success()
            {
                // Arrange
                var withdrawRequestDto = new WithDrawRequestDto { AccountNumber = "123", userid = 1, Amount = 50 };
                var account = new Account { AccountNumber = "123", CurrentBalance = 100 };
                var eligibleWithdrawAmount = account.CurrentBalance * 0.9;

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(withdrawRequestDto.userid)).Returns(new List<Account> { account });

                // Act
                var result = _accountService.WithdrawMoney(withdrawRequestDto);

                // Assert
                Assert.IsTrue(result.IsSuccess);
                Assert.AreEqual("WithDraw success", result.Message);
                Assert.AreEqual(account.CurrentBalance - withdrawRequestDto.Amount, (result.Result as Account).CurrentBalance);
            }

            [TestMethod]
            public void DepositMoney_ValidRequest_Success()
            {
                // Arrange
                var depositRequestDto = new DepositRequestDto { AccountNumber = "123", userid = 1, Amount = 5000 };
                var account = new Account { AccountNumber = "123", CurrentBalance = 5000 };

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(depositRequestDto.userid)).Returns(new List<Account> { account });

                // Act
                var result = _accountService.DepositMoney(depositRequestDto);

                // Assert
                Assert.IsTrue(result.IsSuccess);
                Assert.AreEqual("Deposit success", result.Message);
                Assert.AreEqual(account.CurrentBalance + depositRequestDto.Amount, (result.Result as Account).CurrentBalance);
            }

            [TestMethod]
            public void WithdrawMoney_AmountExceedsLimit_Failure()
            {
                // Arrange
                var withdrawRequestDto = new WithDrawRequestDto { AccountNumber = "123", userid = 1, Amount = 100 };
                var account = new Account { AccountNumber = "123", CurrentBalance = 100 };

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(withdrawRequestDto.userid)).Returns(new List<Account> { account });

                // Act
                var result = _accountService.WithdrawMoney(withdrawRequestDto);

                // Assert
                Assert.IsFalse(result.IsSuccess);
                Assert.AreEqual("WithDraw Amount greater than 90% account Balance", result.Message);
            }

            [TestMethod]
            public void DepositMoney_AmountExceedsLimit_Failure()
            {
                // Arrange
                var depositRequestDto = new DepositRequestDto { AccountNumber = "123", userid = 1, Amount = 15000 };
                var account = new Account { AccountNumber = "123", CurrentBalance = 5000 };

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(depositRequestDto.userid)).Returns(new List<Account> { account });

                // Act
                var result = _accountService.DepositMoney(depositRequestDto);

                // Assert
                Assert.IsFalse(result.IsSuccess);
                Assert.AreEqual("A user cannot deposit more than $10,000 in a single transaction", result.Message);
            }

            [TestMethod]
            public void GetAllAccountsByUser_NoAccounts_ReturnsNotFound()
            {
                // Arrange
                long userId = 1;
                var accounts = new List<Account>();

                _mockDataService.Setup(ds => ds.GetAllAccountsByUser(userId)).Returns(accounts);

                // Act
                var result = _accountService.GetAllAccountsByUser(userId);

                // Assert
                Assert.IsFalse(result.IsSuccess);
                Assert.AreEqual("Not Found", result.Message);
            }
        }

}
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
	internal class PaymentServiceTests
	{

		private readonly Mock<IAccountDataStoreFactory> accountDataStoreFactMock= new Mock<IAccountDataStoreFactory>();
		private readonly Mock<IAccountDataStore> accountDataStoreMock = new Mock<IAccountDataStore>();

		private readonly Account ValidAccount = new Account();
		private readonly Account InvalidAccount = new Account();

		[SetUp]
		public void Setup()
		{
			ValidAccount.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
			ValidAccount.AllowedPaymentSchemes |= AllowedPaymentSchemes.FasterPayments;
			ValidAccount.AllowedPaymentSchemes |= AllowedPaymentSchemes.Bacs;
			ValidAccount.Balance = 1000;

			InvalidAccount.Balance = 1;
		}

		[Test]
		public void Payment_service_returns_true()
		{
			accountDataStoreMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(ValidAccount);

			accountDataStoreFactMock.Setup(x => x.GetDataStore()).Returns(accountDataStoreMock.Object);

			var service = new PaymentService(accountDataStoreFactMock.Object);

			var result = service.MakePayment(new MakePaymentRequest { PaymentScheme = PaymentScheme.Chaps, Amount = 250 });

			Assert.NotNull(result);
			Assert.IsTrue(result.Success);
		}

		[Test]
		public void Payment_service_returns_false()
		{
			accountDataStoreMock.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(InvalidAccount);

			accountDataStoreFactMock.Setup(x => x.GetDataStore()).Returns(accountDataStoreMock.Object);

			var service = new PaymentService(accountDataStoreFactMock.Object);

			var result = service.MakePayment(new MakePaymentRequest { PaymentScheme = PaymentScheme.Chaps, Amount = 250 });

			Assert.NotNull(result);
			Assert.IsFalse(result.Success);
		}
	}
}

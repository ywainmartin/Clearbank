using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
	public class PaymentSchemeValidatorTests
	{

		private Mock<IValidator> validatorMock;

		[SetUp]
		public void Setup()
		{
			validatorMock = new Mock<IValidator>();
		}

		[Test]
		public void Validator_Throws_On_Null_Account()
		{
			var paymentValidator = new PaymentSchemeValidator(null);

			Assert.Throws<ArgumentNullException>(()=> paymentValidator.ValidateAccount(null));
		}


		[Test]
		public void ValidatorThrows_KeyNot_found_On_Unsupported_Payment_type()
		{
			var paymentRequest = new MakePaymentRequest
			{
				PaymentScheme = PaymentScheme.Other
			};

			var paymentValidator = new PaymentSchemeValidator(paymentRequest);
			var account = new Account();

			Assert.Throws<KeyNotFoundException>(() => paymentValidator.ValidateAccount(account));
		}

	}
}

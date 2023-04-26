using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Rules;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
	internal class RulesTest
	{

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void FasterPaymentsRule_Returns_True_Adequate_Funds()
		{
			var request = new MakePaymentRequest();
			request.Amount = 50;
			var rule = new FasterPaymentsRule(request);
			var acc = new Account();
			acc.Balance = 100;
			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;

			var result = rule.IsAccountValid(acc);

			Assert.IsTrue(result);

		}

		[Test]
		public void FasterPaymentsRule_Returns_False_InAdequate_Funds()
		{
			var request = new MakePaymentRequest();
			request.Amount = 100;
			var rule = new FasterPaymentsRule(request);
			var acc = new Account();
			acc.Balance = 50;
			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;

			var result = rule.IsAccountValid(acc);

			Assert.IsFalse(result);

		}


		[Test]
		public void FasterPaymentsRule_Returns_false_On__Invalid_PaymentScheme()
		{
			var request = new MakePaymentRequest();

			var rule = new FasterPaymentsRule(request);
			var acc = new Account();

			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;

			var result = rule.IsAccountValid(acc);

			Assert.IsFalse(result);

		}

		[Test]
		public void FasterPaymentsRule_Returns_false_On_Null_Account()
		{
			var request = new MakePaymentRequest();

			var rule = new FasterPaymentsRule(request);

			var result = rule.IsAccountValid(null);

			Assert.IsFalse(result);

		}


		[Test]
		public void ChapsRule_Returns_true_On_Chaps_payment_type_account_live()
		{
			var rule = new ChapsRule();

			var acc = new Types.Account();

			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
			acc.Status = AccountStatus.Live;

			var result = rule.IsAccountValid(acc);

			Assert.IsTrue(result);

		}

		[Test]
		public void ChapsRule_Returns_false_On_Account_Disabled()
		{
			var rule = new ChapsRule();

			var acc = new Types.Account();

			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
			acc.Status = AccountStatus.Disabled;

			var result = rule.IsAccountValid(acc);

			Assert.IsFalse(result);

		}

		[Test]
		public void ChapsRule_Returns_false_On_Non_Chaps_Flag()
		{
			var rule = new ChapsRule();

			var acc = new Types.Account();

			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
			acc.Status = AccountStatus.Live;

			var result = rule.IsAccountValid(null);

			Assert.IsFalse(result);

		}


		[Test]
		public void ChapsRule_Returns_false_On_Null_Account()
		{
			var rule = new ChapsRule();

			var result = rule.IsAccountValid(null);

			Assert.IsFalse(result);

		}


		[Test]
		public void BacsRule_Returns_false_On_Null_Account()
		{
			var rule = new BacsRule();

			var result = rule.IsAccountValid(null);

			Assert.IsFalse(result);

		}

		[Test]
		public void BacsRule_Returns_false_On_Non_Bacs_Flag()
		{
			var rule = new BacsRule();

			var acc = new Types.Account();

			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
			acc.AllowedPaymentSchemes |= AllowedPaymentSchemes.FasterPayments;

			var result = rule.IsAccountValid(acc);

			Assert.IsFalse(result);
		}

		[Test]
		public void BacsRule_Returns_True_On_Bacs_Flag()
		{
			var rule = new BacsRule();

			var acc = new Types.Account();

			acc.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
			acc.AllowedPaymentSchemes |= AllowedPaymentSchemes.Bacs;

			var result = rule.IsAccountValid(acc);

			Assert.IsTrue(result);
		}
	}
}

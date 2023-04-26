using System;
using System.Collections.Generic;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Rules;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators
{
	public class PaymentSchemeValidator : IValidator
	{
		private readonly MakePaymentRequest _makePaymentRequest;

		private readonly Dictionary<PaymentScheme, IRule> _rules= new Dictionary<PaymentScheme, IRule>();
		public PaymentSchemeValidator(MakePaymentRequest makePaymentRequest) {
			_makePaymentRequest = makePaymentRequest;

			_rules.Add(PaymentScheme.Bacs, new BacsRule());
			_rules.Add(PaymentScheme.FasterPayments, new FasterPaymentsRule(_makePaymentRequest));
			_rules.Add(PaymentScheme.Chaps, new ChapsRule());
		}
		public bool ValidateAccount(Account account)
		{
			if(account == null)
				throw new ArgumentNullException("account is null");


			if (!_rules.ContainsKey(_makePaymentRequest.PaymentScheme))
				throw new KeyNotFoundException($"PaymentScheme key not found:{_makePaymentRequest.PaymentScheme}");


			return _rules[_makePaymentRequest.PaymentScheme].IsAccountValid(account);
		}
	}
}

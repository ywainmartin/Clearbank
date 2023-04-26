using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{


	public class FasterPaymentsRule : RuleBase
	{
		private readonly MakePaymentRequest _makePaymentRequest;

		public FasterPaymentsRule(MakePaymentRequest makePaymentRequest)
		{
			_makePaymentRequest = makePaymentRequest;
		}


		public override bool IsAccountValid(Account account)
		{
			var result = true;

			if (account == null)
			{
				result = false;
			}
			else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
			{
				result = false;
			}
			else if (account.Balance < _makePaymentRequest.Amount)
			{
				result = false;
			}

			return result;
		}
	}
}

using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
	internal class ChapsRule : RuleBase
	{
		public override bool IsAccountValid(Account account)
		{
			var result = true;

			if (account == null)
			{
				result = false;
			}
			else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
			{
				result = false;
			}
			else if (account.Status != AccountStatus.Live)
			{
				result = false;
			}

			return result;
		}
	}
}

using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
	public class BacsRule : RuleBase
	{
		public override bool IsAccountValid(Account account)
		{
			var result = true;

			if (account == null)
			{
				result= false;
			}
			else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
			{
				result= false;
			}

			return result;
		}
	}
}

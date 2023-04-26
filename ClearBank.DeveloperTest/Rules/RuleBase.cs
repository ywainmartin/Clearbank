using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Rules
{
	public abstract class RuleBase : IRule
	{
		public abstract bool IsAccountValid(Account account);
	}
}

using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
	public interface IRule
	{
		bool IsAccountValid(Account account);
	}
}

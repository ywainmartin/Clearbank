using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
	public interface IAccountDataStore
	{
		Account GetAccount(string debtorAccountNumber);

		void UpdateAccount(Account account);
	}
}

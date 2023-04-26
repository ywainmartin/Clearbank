using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interfaces
{
	public interface IDataStore
	{
		Account GetAccount(string debtorAccountNumber);

		void UpdateAccount(Account account);
	}
}

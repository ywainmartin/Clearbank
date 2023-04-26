using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
	public abstract class AccountDataStoreBase : IAccountDataStore
	{
		protected IDataStore _dataStore;

		public AccountDataStoreBase(IDataStore dataStore)
		{
			_dataStore = dataStore;
		}

		public virtual Account GetAccount(string debtorAccountNumber)
		{
			return _dataStore.GetAccount(debtorAccountNumber);
		}
		public virtual void UpdateAccount(Account account)
		{
			_dataStore.UpdateAccount(account);
		}
	}
}

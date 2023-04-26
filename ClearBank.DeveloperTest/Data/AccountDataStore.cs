using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
	public class AccountDataStore : AccountDataStoreBase
	{
		public AccountDataStore(IDataStore dataStore) : base(dataStore)
		{
		}

		public override Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public override void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}

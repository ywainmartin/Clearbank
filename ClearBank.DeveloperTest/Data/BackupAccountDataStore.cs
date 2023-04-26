using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
	public class BackupAccountDataStore : AccountDataStoreBase
	{
		public BackupAccountDataStore(IDataStore dataStore) : base(dataStore)
		{
		}

		public override Account GetAccount(string accountNumber)
        {
            // Access backup data base to retrieve account, code removed for brevity 
            return new Account();
        }

        public override void UpdateAccount(Account account)
        {
            // Update account in backup database, code removed for brevity
        }
    }
}

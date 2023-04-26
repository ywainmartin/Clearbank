using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest.Services
{
	public class AccountDataStoreFactory : IAccountDataStoreFactory
	{
		private readonly IConfigurationManager _configurationManager;
		private readonly IDataStore _dataStore;

		public AccountDataStoreFactory(IConfigurationManager configurationManager, IDataStore dataStore)
		{
			_configurationManager = configurationManager;
			_dataStore = dataStore;
		}

		public IAccountDataStore GetDataStore()
		{
			var dataStoreType = _configurationManager.AppSettings["DataStoreType"];

			if (dataStoreType == "Backup")
			{
				return new BackupAccountDataStore(_dataStore);
			}
			else
			{
				return new AccountDataStore(_dataStore);
			}
		}
	}
}

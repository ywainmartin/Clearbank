using ClearBank.DeveloperTest.Interfaces;

namespace ClearBank.DeveloperTest.Services
{
	public interface IAccountDataStoreFactory
	{
		IAccountDataStore GetDataStore();
	}
}

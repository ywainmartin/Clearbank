using System.Collections.Specialized;

namespace ClearBank.DeveloperTest.Interfaces
{
	public interface IConfigurationManager
	{
		NameValueCollection AppSettings { get; }
	}
}

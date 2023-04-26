using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interfaces;
using ClearBank.DeveloperTest.Rules;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
	public class AccountDataStoreFactoryTests
	{

		private Mock<IConfigurationManager> configManagerMock;
		private Mock<IDataStore> dataStoreMock;

		[SetUp]
		public void Setup()
		{
			configManagerMock = new Mock<IConfigurationManager>();
			dataStoreMock = new Mock<IDataStore>();
		}

		[Test]
		public void AccountDataStoreFactory_Returns_BackUpDataStore_Type()
		{
			var appSettings = new NameValueCollection
			{
				{ "DataStoreType", "Backup" }
			};

			configManagerMock.Setup(x => x.AppSettings).Returns(appSettings);
			var fac = new AccountDataStoreFactory(configManagerMock.Object, dataStoreMock.Object);

			var result = fac.GetDataStore();

			Assert.That(result.GetType(), Is.EqualTo(typeof(BackupAccountDataStore)));
		}


		[Test]
		public void AccountDataStoreFactory_Returns_AccountDataStore_Type()
		{
			var appSettings = new NameValueCollection
			{
				{ "DataStoreType", "other" }
			};

			configManagerMock.Setup(x => x.AppSettings).Returns(appSettings);
			var fac = new AccountDataStoreFactory(configManagerMock.Object, dataStoreMock.Object);

			var result = fac.GetDataStore();

			Assert.That(result.GetType(), Is.EqualTo(typeof(AccountDataStore)));
		}
	}
}

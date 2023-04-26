using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Services
{
	public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStoreFactory _accountDataStoreFactory;

		public PaymentService(IAccountDataStoreFactory accountDataStoreFactory)
        {
			_accountDataStoreFactory = accountDataStoreFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
		{
			var account = GetAccount(request.DebtorAccountNumber);
			var result = ValidateAccount(request, account);

			if (result.Success)
			{
				account.Balance -= request.Amount;

				var accountDataStore = _accountDataStoreFactory.GetDataStore();

				accountDataStore.UpdateAccount(account);
			}

			return result;
		}

		internal MakePaymentResult ValidateAccount(MakePaymentRequest request, Account account)
		{
			var result = new MakePaymentResult();
			var validator = new PaymentSchemeValidator(request);

			result.Success = validator.ValidateAccount(account);

			return  result;
		}

		internal Account GetAccount(string debtorAccountNumber)
		{
			Account account;

			var accountDataStore = _accountDataStoreFactory.GetDataStore();

			account = accountDataStore.GetAccount(debtorAccountNumber);

			return account;
		}
	}
}

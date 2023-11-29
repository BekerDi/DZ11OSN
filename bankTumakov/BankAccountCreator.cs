using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankTumakov
{
    internal class BankAccountCreator
    {
        private Dictionary<int, BankAccount> accountDictionary;

        private Hashtable _hashtable;
        public int CreateAccount()
        {

            BankAccount account = new BankAccount();
            _hashtable.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }
        public void DeleteAccount(int accountNumber)
        {
            _hashtable.Remove(accountNumber);
        }
        public BankAccountCreator(Hashtable hashtable)
        {
            this._hashtable = hashtable;
        }
        public int CreateAccount(string accountType)
        {
            BankAccount account = new BankAccount(accountType);
            accountDictionary.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }

        public int CreateAccount(decimal balance)
        {
            BankAccount account = new BankAccount(balance);
            accountDictionary.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }

        public int CreateAccount(string accountType, decimal balance)
        {
            BankAccount account = new BankAccount(accountType, balance);
            accountDictionary.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }

    }
}

using FinalLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLab.Entities;

namespace FinalLab.Managers
{
    public class AccountManager : IAccountManager
    {
        public Account GetAccountByUsername(string username)
        {
            using (CatalogContext context=new CatalogContext())
            {
                var accounts = from account in context.Accounts
                               where account.Username.Equals(username)
                               select account;
                return accounts.FirstOrDefault();
            }
        }

        public bool IsAccountFoundByUsername(string username)
        {
            return GetAccountByUsername(username) != null;
        }

        public void RegisterAccount(Account account)
        {
            using (CatalogContext context = new CatalogContext())
            {
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }
    }
}

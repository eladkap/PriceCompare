using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalLab.Entities;

namespace FinalLab.Interfaces
{
    interface IAccountManager
    {
        Account GetAccountByUsername(string username);

        bool IsAccountFoundByUsername(string username);

        void RegisterAccount(Account account);
    }
}

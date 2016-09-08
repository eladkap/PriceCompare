using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLab.Interfaces
{
    interface IValidationManager
    {
        bool IsValidUsername(string username);

        bool IsValidPassword(string password);

        bool ArePasswordsEqual(string password1, string password2);
    }
}

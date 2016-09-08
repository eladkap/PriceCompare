using FinalLab.Interfaces;
using System.Linq;

namespace FinalLab.Managers
{
    public class ValidationManager : IValidationManager
    {
        public bool IsValidUsername(string username)
        {
            return username != null && username.Count() > 0;
        }

        public bool IsValidPassword(string password)
        {
            return password != null && password.Count() > 0;
        }

        public bool ArePasswordsEqual(string password1, string password2)
        {
            return password1.Equals(password2);
        }
    }
}

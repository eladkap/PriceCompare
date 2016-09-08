using FinalLab.Entities;
using FinalLab.Interfaces;
using FinalLab.Managers;
using System;
using System.Windows.Forms;

namespace FinalLab.Forms
{
    public partial class RegisterForm : Form
    {
        AccountManager _accountManager;
        ValidationManager _validationManager;

        public RegisterForm()
        {
            InitializeComponent();
        }

        internal void SetAccountManager(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        internal void SetValidationManager(ValidationManager validationManager)
        {
            _validationManager = validationManager;
        }

        private bool IsAccountFound()
        {
            return _accountManager.IsAccountFoundByUsername(txt_username.Text);
        }

        private bool ArePasswordsEqual()
        {
            return _validationManager.ArePasswordsEqual(txt_password.Text, txt_retypePassword.Text);
        }

        private bool ValidateUsername()
        {
            if (!IsValidUsername())
            {
                MessageBox.Show("Please enter username.");
                return false;
            }
            return true;
        }

        private bool IsValidPassword()
        {
            return _validationManager.IsValidPassword(txt_password.Text);
        }

        private bool IsValidUsername()
        {
            return _validationManager.IsValidUsername(txt_username.Text);
        }

        private bool ValidatePassword()
        {
            if (!IsValidPassword())
            {
                MessageBox.Show("Please enter password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void ValidateInputs()
        {
            if (!ValidateUsername())
            {
                return;
            }
            if (!ValidatePassword())
            {
                return;
            }
        }

        private bool ValidateParametersAreCorrect()
        {
            ValidateInputs();
            if (IsAccountFound())
            {
                MessageBox.Show("Account already exist.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ArePasswordsEqual())
            {
                MessageBox.Show("Passwords are not equal.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void RegisterSuccess()
        {
            MessageBox.Show("You are registered. Now you can login.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
        }

        private void Register()
        {
            if (!ValidateParametersAreCorrect())
            {
                return;
            }
            Account account = new Account(txt_username.Text, txt_password.Text, txt_username.Text, "client");
            _accountManager.RegisterAccount(account);
            RegisterSuccess();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Register();
        }
    }
}

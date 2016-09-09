using FinalLab.Entities;
using FinalLab.Interfaces;
using FinalLab.Managers;
using System;
using System.Windows.Forms;

namespace FinalLab.Forms
{
    public partial class LoginForm : Form
    {
        private MainForm _mainForm;
        private AccountManager _accountManager;
        private ValidationManager _validationManager;
        private Account _account;

        public LoginForm()
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

        internal void SetAccount(Account account)
        {
            _account = account;
        }

        internal void SetMainForm(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        private bool IsValidUsername()
        {
            return _validationManager.IsValidUsername(txt_username.Text);
        }

        private bool IsValidPassword()
        {
            return _validationManager.IsValidPassword(txt_password.Text);
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

        private bool IsAccountFound()
        {
            return _accountManager.IsAccountFoundByUsername(txt_username.Text);
        }

        private bool IsPasswordCorrect()
        {
            Account account = _accountManager.GetAccountByUsername(txt_username.Text);
            return account.Password.Equals(txt_password.Text);
        }

        private bool ValidateParametersAreCorrect()
        {
            ValidateInputs();
            if (!IsAccountFound())
            {
                MessageBox.Show("Account not found.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!IsPasswordCorrect())
            {
                MessageBox.Show("Password is incorrect.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _account = _accountManager.GetAccountByUsername(txt_username.Text);
            return true;
        }

        private void UpdateMainFormAfterLogin()
        {
            _mainForm.GetLabelUsername().Text = _account.Username;
            _mainForm.SetAccountUsername(_account.Username);
            _mainForm.SetAccountLogin(true);
            _mainForm.GetLogoutMenuItem().Visible = true;
            _mainForm.GetLoginMenuItem().Visible = false;
        }

        private void LoginSuccess()
        {
            _account.SetLogin();
            if (_account.Nickname.Equals("Admin"))
            {
                _account.Permission = "Admin";
                _mainForm.SetAccountPermission("admin");
                MessageBox.Show($"{_account.Username}, You are login as admin.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _account.Permission = "client";
                _mainForm.SetAccountPermission("client");
                MessageBox.Show($"{_account.Username}, You are login as client. Now you can create cart with items and compare prices.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateMainFormAfterLogin();
            Dispose();
        }

        public void Login()
        {
            if (!ValidateParametersAreCorrect())
            {
                return;
            }
            LoginSuccess();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}

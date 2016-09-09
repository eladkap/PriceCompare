using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalLab.Entities
{
    [Table("accounts")]
    public class Account
    {
        public Account(string username, string password, string nickname, string permission)
        {
            Username = username;
            Password = password;
            Permission = permission;
            Nickname = nickname;
            IsLogin = false;
        }

        public Account() : this("Username", "password", "Guest", "client")
        {
        }

        [Key, Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// Permission can be: admin/client
        /// </summary>
        [Column("permission")]
        public string Permission { get; set; }

        public override bool Equals(object obj)
        {
            Account accountObj = (Account)obj;
            return Username.Equals(accountObj.Username);
        }

        public void SetLogin()
        {
            IsLogin = true;
            Nickname = Capitalize(Nickname);
        }

        public void SetLogout()
        {
            IsLogin = false;
            Nickname = "Guest";
        }

        [NotMapped]
        public bool IsLogin { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return str.First().ToString().ToUpper() + str.Substring(1);
        }
    }
}

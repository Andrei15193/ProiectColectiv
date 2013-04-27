using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MemberViewModel
/// </summary>
namespace UserInterface.ViewModels
{
    public class MemberViewModel
    {
        public MemberViewModel()
        {
            this.IsAuthenticated = false;
            this.Username = "Guest123";
            this.Password = string.Empty;
        }

        public void LogOut()
        {
            if (this.IsAuthenticated)
            {
                this.IsAuthenticated = false;
                this.Username = "Guest123";
                this.Password = string.Empty;
            }
        }

        public bool TryAuthenticate(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.IsAuthenticated = true;
            return true;
        }

        public bool IsAuthenticated { get; private set; }

        public string Username { get; private set; }

        private string Password { get; set; }
    }
}
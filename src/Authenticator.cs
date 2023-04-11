using System;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using LottoWForms.Entities;
using Microsoft.EntityFrameworkCore;

namespace LottoWForms
{
    public class Authenticator
    {
        private int _authUserId = -999;
        private string _authUserLogin;
        
        private int _keySize = 32;
        private int _interations = 350000;

        private DBManager _db;
        
        public int AuthUserId => this._authUserId;
        public string AuthUserLogin => this._authUserLogin;

        public Authenticator()
        {
            this._db = new DBManager();
        }

        public Authenticator(DBManager dbManager)
        {
            this._db = dbManager;
        }

        public void LoginIn(string login, string password)
        {
            var user = this._db.Users.First(u => u.Login == login);
            this.IsPasswordValid(password, user.Password);

            this._authUserId = user.Id;
            this._authUserLogin = user.Login;
        }
        
        public void SigneIn(string login, string password)
        {
            _db.Users.Add(new User() { Login = login, Password = this.HashPassword(password) });
            _db.SaveChanges();
            
            //TODO: Refactor SigneIn function
            //It shouldn't be here... Use observer pattern
            BalanceManager bm = new BalanceManager();
            User newUser = this._db.Users.First(u => u.Login == login);
            bm.CreateNewBalance(newUser.Id);
        }

        private string HashPassword(string password)
        {   
            var rfc = new Rfc2898DeriveBytes(password, new byte[this._keySize], this._interations);
            byte[] hash= rfc.GetBytes(this._keySize);
            return Convert.ToHexString(hash);
        }

        private bool IsPasswordValid(string password, string hash)
        {
            return this.HashPassword(password) == hash;
        }

    }
}
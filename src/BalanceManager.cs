using System.Linq;
using LottoWForms.Entities;

namespace LottoWForms
{
    public class BalanceManager
    {
        private int _startingBalance = 50;
        
        private DBManager _db;

        public BalanceManager()
        {
            this._db = new DBManager();
        }

        public void CreateNewBalance(int userId)
        {
            this._db.Balances.Add(new Balance() { UserId = userId, UserBalance = this._startingBalance });
            this._db.SaveChanges();
        }

        public void AddToBalance(int userId, int value)
        {
            Balance userBalance = this._db.Balances.First(b => b.UserId == userId);
            userBalance.UserBalance += value;
            this._db.SaveChanges();
        }

        public void DecreaseBalance(int userId, int value)
        {
            Balance userBalance = this._db.Balances.First(b => b.UserId == userId);
            userBalance.UserBalance -= value;
            this._db.SaveChanges(); 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using LottoWForms.Entities;

namespace LottoWForms
{
    public class TicketManager
    {
        private int _dayLimit = 8;
        private int _ticketCost = 10;
        private DBManager _db;

        public TicketManager()
        {
            this._db = new DBManager();
        }
        
        public void BuyTicket(int userId, List<int> userNumbers)
        {
            if (this.HasLimitBeenReached(userId)) throw new Exception("Ticket limit has been reached!");
            if (!this.HasUserEnoughBalance(userId)) throw new Exception("User have not enough money!");

            //TODO: Refactor BuyTicket function
            //Use observer pattern...
            BalanceManager bm = new BalanceManager();
            bm.DecreaseBalance(userId, this._ticketCost);

            this._db.Tickets.Add(new Ticket() { Date = DateTime.Today, UserId = userId, GuessedNumbers = string.Join(";", userNumbers) });

            _db.SaveChanges();
        }

        private bool HasUserEnoughBalance(int userId)
        {
            Balance userBalance = this._db.Balances.First(b => b.UserId == userId);
            if (userBalance.UserBalance >= this._ticketCost) return true;
            return false;
        }

        private bool HasLimitBeenReached(int userId)
        {
            var tickets = _db.Tickets.Where(t => t.UserId == userId && t.Date.Date == DateTime.Today.Date).ToList();
            
            if (tickets.Count >= this._dayLimit) { return true; }

            return false;
        }
    }
}
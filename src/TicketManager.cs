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

        public List<List<int>> GetTicketNumbers(int userId)
        {
            List<List<int>> ticketNumbers = new List<List<int>>();
            var res = this._db.Tickets.Where(ticket => ticket.UserId == userId && ticket.Date == DateTime.Now.Date).ToList();

            foreach (var ticket in res)
            {
                ticketNumbers.Add(ticket.GuessedNumbers.Split(";").Select(Int32.Parse).ToList());
            }

            return ticketNumbers;
        }

        public int GetTicketAvailable(int userId)
        {
            this._db = new DBManager();

            List<Ticket> tickets = _db.Tickets.Where(t => t.UserId == userId && t.Date.Date == DateTime.Today.Date).ToList();

            if (!this.HasUserEnoughBalance(userId) || this.HasLimitBeenReached(userId) || this.HasCheckedNumbers(userId)) return 0;

            return this._dayLimit - tickets.Count;
        }

        public bool HasUserEnoughBalance(int userId)
        {
            this._db = new DBManager();

            Balance userBalance = this._db.Balances.First(b => b.UserId == userId);
            if (userBalance.UserBalance >= this._ticketCost) return true;
            return false;
        }

        public bool HasLimitBeenReached(int userId)
        {
            this._db = new DBManager();

            var tickets = _db.Tickets.Where(t => t.UserId == userId && t.Date.Date == DateTime.Today.Date).ToList();
            
            if (tickets.Count >= this._dayLimit) { return true; }

            return false;
        }

        public bool HasCheckedNumbers(int userId)
        {
            this._db = new DBManager();

            try
            {
                return this._db.Tickets.Where(t => t.UserId == userId).OrderBy(t => t.Date).Last().IsResultChecked;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LottoWForms.Entities;

namespace LottoWForms
{
    public class GameManager
    {

        private DBManager _db;
        public Game _game;

        public GameManager()
        {
            this._db = new DBManager();
            this.InitGame();
            
        }

        public void CheckPlayersNumbers(int userId)
        {
            List<Ticket> tickets = this._db.Tickets.Where(t => t.UserId == userId && t.Date.Date == DateTime.Today.Date).ToList();
            foreach (Ticket ticket in tickets)
            {
                List<int> playerNumbers = ticket.GuessedNumbers.Split(";").Select(Int32.Parse).ToList();
                Dictionary<int, bool> result = this._game.CheckPlayersNumbers(playerNumbers);

                ticket.GuessedResult = string.Join(";", result);
                _db.SaveChanges();
            }
        }
        
        private bool ShouldCreateNewGame()
        {
            try
            {
                DateTime lastDate = _db.Prizes.OrderBy(p => p.PrizeDate).First().PrizeDate;
                if (!DateValidator.IsDateToday(lastDate)) return true;
                return false;
            }
            catch (InvalidOperationException error)
            {
                return true;
            }
        }

        private void InitGame()
        {
            if (this.ShouldCreateNewGame())
            {
                this._game = new Game();
            }
            else
            {
                Prize lastPrize = _db.Prizes.OrderBy(p => p.PrizeDate).First();
                List<int> lastWinningNumber = lastPrize.WinningNumbers.Split(";").Select(Int32.Parse).ToList();
                this._game = new Game(lastPrize.PrizeValue, lastWinningNumber);
            }
        }
    }
}
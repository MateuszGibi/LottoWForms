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

        public List<int> GetNumberOfGuessed(int userId)
        {
            this._db = new DBManager();
            List<Ticket> tickets = this._db.Tickets.Where(t => t.UserId == userId && t.Date.Date == DateTime.Now.Date).OrderBy(t => t.Id).ToList();
            if (tickets.Count == 0) return new List<int> {};
            List<int> numberOfGuessed = new List<int>();
            foreach (var ticket in tickets)
            {
                if(ticket.GuessedResult == null)
                {
                    numberOfGuessed.Add(0);
                    continue;
                        
                }
                List<string> guessed = ticket.GuessedResult.Split(";").ToList();
                int noOfGuessed = 0;

                foreach (var guess in guessed)
                {
                    if (bool.Parse(guess))
                    {
                        noOfGuessed++;
                    }
                }

                numberOfGuessed.Add(noOfGuessed);
            }

            return numberOfGuessed;
        }

        public void CheckPlayersNumbers(int userId)
        {
            List<Ticket> tickets = this._db.Tickets.Where(t => t.UserId == userId && t.Date.Date == DateTime.Today.Date).ToList();
            foreach (Ticket ticket in tickets)
            {
                List<int> playerNumbers = ticket.GuessedNumbers.Split(";").Select(Int32.Parse).ToList();
                List<bool> result = this._game.CheckPlayersNumbers(playerNumbers);

                ticket.GuessedResult = string.Join(";", result);
                ticket.IsResultChecked = true;
                _db.SaveChanges();
            }
        }
        
        private bool ShouldCreateNewGame()
        {
            try
            {
                DateTime lastDate = _db.Prizes.OrderBy(p => p.PrizeDate).Last().PrizeDate;
                if (DateValidator.IsDateToday(lastDate)) return false;
                return true;
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
                Prize lastPrize = _db.Prizes.OrderBy(p => p.PrizeDate).Last();
                List<int> lastWinningNumber = lastPrize.WinningNumbers.Split(";").Select(Int32.Parse).ToList();
                this._game = new Game(lastPrize.PrizeValue, lastWinningNumber);
            }
        }
    }
}
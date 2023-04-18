using System;
using System.Collections.Generic;
using System.Linq;
using LottoWForms.Entities;

namespace LottoWForms
{
    public class Game
    {
        private int _prize;
        private int _prizeMaxValue = 50;
        private int _numberOfRandomNumbers = 6;
        private int _numberOfPoolNumbers = 49;
        private List<int> _poolNumbers = new List<int>();
        private List<int> _randomNumbers = new List<int>();

        public int Prize { get => _prize; }
        public List<int> WinningNumbers { get => this._randomNumbers; }
        
        public Game()
        {
            this.GeneratePrizeValue();
            this.InitGameNumbersList();
            this.GenerateRandomNumbers();

            DBManager db = new DBManager();
            db.Prizes.Add(new Prize()
            {
                PrizeDate = DateTime.Now,
                PrizeValue = this._prize,
                WinningNumbers = string.Join(";", this._randomNumbers.Select(number => number.ToString()))
            });
            db.SaveChanges();

        }

        public Game(int prize, List<int> winningNumbers)
        {
            this._prize = prize;
            this._randomNumbers = winningNumbers;
        }

        public List<bool> CheckPlayersNumbers(List<int> playerNumbers){
            List<bool> result = new List<bool>();
        
            foreach(int playerNumber in playerNumbers)
            {
                result.Add(this._randomNumbers.Contains(playerNumber));
            }

            return result;
        }

        private void GeneratePrizeValue()
        {
            int randomNumber = new Random().Next(1, this._prizeMaxValue); 
            this._prize = randomNumber * 1000000;
        }
        
        private void GenerateRandomNumbers()
        {
            for (int i = 0; i < this._numberOfRandomNumbers; i++)
            {
                int randomNumber = new Random().Next(0, this._poolNumbers.Count);
                this._randomNumbers.Add(this._poolNumbers[randomNumber]); 
                this._poolNumbers.Remove(this._poolNumbers[randomNumber]);
            }
        }
    
        private void InitGameNumbersList()
        {
            for (int i = 0; i < this._numberOfPoolNumbers; i++)
            {
                this._poolNumbers.Add(i + 1);
            }
        } 
    }
}
using System;

namespace LottoWForms.Entities
{
    public class Prize
    {
        public int Id { get; set; }
        public int PrizeValue { get; set; }
        public DateTime PrizeDate { get; set; }
        
        public string WinningNumbers { get; set; }
    }
}
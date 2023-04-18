using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LottoWForms.Entities
{
    public class Ticket 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string GuessedNumbers { get; set; }
        public string GuessedResult { get; set; } 
        public bool IsResultChecked { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace BunusSystemWebApi.Models
{
    public partial class BonusCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Balance { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}

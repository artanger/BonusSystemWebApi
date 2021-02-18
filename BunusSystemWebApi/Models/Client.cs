using System;
using System.Collections.Generic;

#nullable disable

namespace BunusSystemWebApi.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public int? BonusCardId { get; set; }

        public virtual BonusCard BonusCard { get; set; }
    }
}

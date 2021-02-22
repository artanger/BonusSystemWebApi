namespace BunusSystemWebApi.Models
{
    public class BonusCardAdvanced : BonusCard
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int? BonusCardId { get; set; }
    }
}

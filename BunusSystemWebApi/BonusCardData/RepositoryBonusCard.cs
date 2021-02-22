using BunusSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunusSystemWebApi.BonusCardData
{
    public class RepositoryBonusCard : IBonusCardRepository
    {
        private BonusCardDBContext bonusCardDB;

        public RepositoryBonusCard(BonusCardDBContext bonusCardDB)
        {
            this.bonusCardDB = bonusCardDB;
        }

        public BonusCard AddToCardByNumber(string cardnumber, int value)
        {
            var bonusCard = bonusCardDB.BonusCards
                .Where(x => x.CardNumber.Equals(cardnumber)).FirstOrDefault();

            if(bonusCard != null)
            {
                if (bonusCard.Balance.HasValue)
                {
                    bonusCard.Balance = bonusCard.Balance + value;
                }
                else
                {
                    bonusCard.Balance = value;
                }

                bonusCardDB.SaveChanges();

                return bonusCard;
            }
            else
            {
                return null;
            }

            
        }

        public BonusCard RemoveFromCardByNumber(string cardnumber, int value)
        {
            var bonusCard = bonusCardDB.BonusCards
                .Where(x => x.CardNumber.Equals(cardnumber)).FirstOrDefault();

            if (bonusCard != null)
            {
                if (bonusCard.Balance.HasValue)
                {
                    bonusCard.Balance = bonusCard.Balance - value;
                }
                else
                {
                    bonusCard.Balance = value;
                }

                bonusCardDB.SaveChanges();

                return bonusCard;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<BonusCard> GetBonusCards()
        {
            if (bonusCardDB != null)
            {
                var bonusCards = bonusCardDB.BonusCards
                            .OrderBy(x => x.CardNumber).ToList();
                
                return bonusCards;
            }

            return null;
        }

        public BonusCard GetCardByNumber(string cardnumber)
        {
            if (bonusCardDB != null)
            {
                return bonusCardDB.BonusCards
                    .Where(x => x.CardNumber.Equals(cardnumber)).FirstOrDefault();
            }

            return null;
        }

        public BonusCardAdvanced GetCardByNumberAdvanced(string cardnumber)
        {
            if (bonusCardDB == null)
            {
                return null;
            }

            var bonusCardsAdvanced = GetAdvancedCardsJoin(bonusCardDB);

            return bonusCardsAdvanced.Where(x => x.CardNumber.Equals(cardnumber)).FirstOrDefault();
        }

        public IEnumerable<BonusCardAdvanced> GetCardByPhoneAdvanced(string phone)
        {
            if (bonusCardDB == null)
            {
                return null;
            }

            var bonusCardsAdvanced = GetAdvancedCardsJoin(bonusCardDB);

            return bonusCardsAdvanced.Where(x => x.PhoneNumber.Contains(phone)).ToList();

            //return bonusCardDB.BonusCards.Join(bonusCardDB.Clients, 
            //        bc => bc.Id, cl => cl.BonusCardId,
            //        (bc, cl) => FillBonusCard(bc, cl))
            //        .Where(x => x.PhoneNumber.Contains(phone)).ToList();
        }

        private static IQueryable<BonusCardAdvanced> GetAdvancedCardsJoin(BonusCardDBContext context)
        {
            return context.BonusCards.Join(context.Clients,
                bc => bc.Id, cl => cl.BonusCardId,
                (bc, cl) => new BonusCardAdvanced
                {
                    FirstName = cl.Firstname,
                    LastName = cl.Lastname,
                    PhoneNumber = cl.PhoneNumber,
                    CardNumber = bc.CardNumber,
                    Balance = bc.Balance,
                    ExpirationDate = bc.ExpirationDate

                }).AsQueryable();
        }

        public string CreateNewBonusCard(string phone, string expirationdate)
        {
            if (bonusCardDB == null)
            {
                return "DB Error";
            }

            DateTime dateExpValue;

            if (!DateTime.TryParse(expirationdate, out dateExpValue))
            {
                return "The 'Expiration Date' has incorrect format";
            }

            var client = bonusCardDB.Clients.FirstOrDefault(x => x.PhoneNumber.Contains(phone));
            if (client == null)
            {
                return "Couldn't find the 'Client'";
            }

            if (client.BonusCardId.HasValue)
            {
                var existingCard = bonusCardDB.BonusCards
                    .FirstOrDefault(x => x.Id == client.BonusCardId.Value);

                if(existingCard != null)
                {
                    return $"This 'Client' already has the 'Bonus Card' with Number: '{existingCard.CardNumber}' and Expiration Date: '{existingCard.ExpirationDate}'";
                }
            }

            var bonusCard = new BonusCard() { ExpirationDate = dateExpValue, Balance = 0 };

            bonusCardDB.BonusCards.Add(bonusCard); 

            bonusCardDB.SaveChanges();

            client.BonusCardId = bonusCard.Id;

            bonusCardDB.SaveChanges();

            return "Success";
        }

        //public List<BonusCard> GetCardNumber(string cardnumber)
        //{
        //    var bonuscards = bonusCardDB.BonusCards.Find(cardnumber);           
        //    return bonuscards;
        //}

        public IEnumerable<Client> GetClients()
        {
            if (bonusCardDB != null)
            {
                return bonusCardDB.Clients
                            .OrderBy(x => x.BonusCardId).ToList();
            }

            return null;
        }

        public string CreateNewClient(string firstName, string lastName, string phone)
        {
            if (bonusCardDB == null)
            {
                return "DB Error";
            }

            var alreadyExisting = bonusCardDB.Clients.Where(c => c.PhoneNumber.Equals(phone)).ToList();
            if (alreadyExisting.Any())
            {
                return "Client with the same Phone Number already exists. Please change the Phone Number.";
            }
            else
            {
                var newClient = new Client
                {
                    Firstname = firstName,
                    Lastname = lastName,
                    PhoneNumber = phone
                };

                bonusCardDB.Add(newClient);

                bonusCardDB.SaveChanges();

                return "Success";
            }
        }
    }
}

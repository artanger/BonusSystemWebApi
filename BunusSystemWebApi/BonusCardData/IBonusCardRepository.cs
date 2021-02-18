using BunusSystemWebApi.Models;
using System;
using System.Collections.Generic;

namespace BunusSystemWebApi.BonusCardData
{
    public interface IBonusCardRepository
    {
        List<BonusCard> GetBonusCards();
        
        BonusCard GetCardByNumber(string cardnumber);

        BonusCardAdvanced GetCardByNumberAdvanced(string cardnumber);

        IEnumerable<BonusCardAdvanced> GetCardByPhoneAdvanced(string phone);

        BonusCard AddToCardByNumber(string cardnumber, int value);

        BonusCard RemoveFromCardByNumber(string cardnumber, int value);

        string CreateNewBonusCard( string phone, string expirationdate);

    }
}

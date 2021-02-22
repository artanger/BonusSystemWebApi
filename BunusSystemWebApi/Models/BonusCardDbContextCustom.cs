using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BunusSystemWebApi.Models
{
    public partial class BonusCardDbContext : DbContext
    {
        //public  override int SaveChanges()
        //{
        //    this.ChangeTracker.DetectChanges();
        //    var added = this.ChangeTracker.Entries()
        //                .Where(t => t.State == EntityState.Added)
        //                .Select(t => t.Entity)
        //                .ToArray();

        //    foreach (var entity in added)
        //    {
        //        if (entity is BonusCard)
        //        {
        //            var card = entity as BonusCard;
        //            card.CreationDate = DateTime.Now;
        //        }
        //    }

        //    return base.SaveChanges();
        //}
    }
}

// using System.ComponentModel.DataAnnotations.Schema;

// using MegaApp.Domain.Common;

// namespace MegaApp.Domain.Entities;

// [Table("TenantHostelSubscriptions")]
// public class TenantHostelSubscription : AuditableEntity //<int>
// {
//     public DateTime SubscriptionStart { get; set; }
//     public DateOnly SubscriptionEnd { get; set; }

//     public DateOnly SubscriptionRenewal { get; set; }

//     public int GraceDays { get; set; }
//     public Decimal AmountPaid { get; set; }
//     public string Comments { get; set; }

//     public int HostelId { get; set; }
//     public TenantHostel TenantHostel { get; set; }

// }
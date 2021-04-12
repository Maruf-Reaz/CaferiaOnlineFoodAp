using CaferiaApp.Models.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ContactNo { get; set; }

        public string Latitiude { get; set; }
        public string Longitude { get; set; }


        public int PaymentStatus { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int DelivaryType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickUpDate { get; set; }
        public string PickUpTime { get; set; }
        public string OrderNumber { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int? DeliveryBoyId { get; set; }
        public DeliveryBoy DeliveryBoy { get; set; }

        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double NetPayable { get; set; }

        public int? CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public string Remarks { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }
}

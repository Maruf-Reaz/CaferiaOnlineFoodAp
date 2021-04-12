using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public bool Result { get; set; }

        public int CartTotalItem { get; set; }
        public double CartTotalAmount{ get; set; }
        public double WalletBalance{ get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


    }
}

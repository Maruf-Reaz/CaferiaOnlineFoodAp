using CaferiaApp.Models.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaferiaApp.Models
{
    public class WalletRequest
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Remarks { get; set; }
        public string TransactionId { get; set; }
        public double RequestAmount { get; set; }
        public double? ApprovedAmount { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int Status { get; set; }
    }
}

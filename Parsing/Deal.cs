using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    public class Deal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? SellerName { get; set; }

        public string? SellerInn { get; set; }

        public string? BuyerName { get; set; }

        public string? BuyerInn { get; set; }

        public double? WoodVolumeBuyer { get; set; }

        public double? WoodVolumeSeller { get; set; }

        public string? DealDate { get; set; }

        public string? DealNumber { get; set; }

        public string? Typename { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Receiver
{
    public record PurchaseOrder
    {
        public string Identification { get; init; }
            
        public string AffiliateName { get; init; }   

        public decimal TotalPrice { get; init; }
        public List <PurchaseOrderLine> Prices { get; init; } = [];
    }

    public record PurchaseOrderLine
    {
        public string LineReference { get; init; }
        public decimal LinePrice { get; init; }
        public bool TaxReturnApprived { get; init; }
    }
}

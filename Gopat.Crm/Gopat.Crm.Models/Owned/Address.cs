using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models.Owned
{
    [Owned]
    public class Price
    {
        public long CalloutFee { get; set; }
        public long ApplianceTestFee { get; set; }
    }
}

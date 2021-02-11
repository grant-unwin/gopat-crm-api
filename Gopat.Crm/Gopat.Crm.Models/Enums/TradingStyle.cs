using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gopat.Crm.Models.Enums
{
    public enum TradingStyle
    {
        [Display(Name="Private Ltd Company")]
        PrivateLimitedCompany,
        [Display(Name = "Private Unlimited Company")] 
        PrivateUnlimitedCompany,
        [Display(Name = "PLC")]
        PublicLimitedCompany,
        [Display(Name = "Partnership")]
        Partnership,
        [Display(Name = "Sole Trader")]
        SoleTrader,
        [Display(Name = "LLP")]
        LimitedLiabilityPartnership,
        [Display(Name = "Other")]
        Other
    }
}

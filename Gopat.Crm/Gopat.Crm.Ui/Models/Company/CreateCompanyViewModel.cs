using Gopat.Crm.Models;

namespace Gopat.Crm.Ui.Models.Company
{
    public class CreateCompanyViewModel
    {
        public Crm.Models.Company Company { get; set; }
        public Contact PrimaryContact { get; set; }

        public Site PrimarySite { get; set; }
    }
}

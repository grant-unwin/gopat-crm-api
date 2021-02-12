using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Gopat.Crm.Models;
using Gopat.Crm.Models.Enums;

namespace Gopat.Crm.Ui
{
    public class DummyData
    {
        public List<Company> Generate()
        {
            var testCompany = new Faker<Company>()
                .StrictMode(true)
                .RuleFor(c => c.CompanyName, (faker, company) => faker.Company.CompanyName())
                .RuleFor(c => c.TradingStyle, (faker, company) => faker.PickRandom<TradingStyle>());

            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using Gopat.Crm.Api.Models;

namespace Gopat.Crm.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, Gopat.Crm.Models.Company>().ReverseMap();
        }
    }
}
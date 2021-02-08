using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gopat.Crm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Api.Controllers
{
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private GopatContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(GopatContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("companies", Name = "GetAll")]
        public async Task<IEnumerable<Company>> GetAsync()
        {
            var accounts = await _context.Companies.ToListAsync();
            return accounts;
        }

        [HttpGet("companies/{id}", Name = "Get")]
        public async Task<Models.Company> GetAsync(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);
            return _mapper.Map<Models.Company>(company);

        }

        [HttpPost("companies", Name = "Create")]
        public async Task<Models.Company> PostAsync([FromBody]Models.Company company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            
            await _context.Companies.AddAsync(companyEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Models.Company>(companyEntity);
        }


    }
}

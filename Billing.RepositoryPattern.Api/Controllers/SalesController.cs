﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Billing.RepositoryPattern.Api.Services.SalesService;
using Billing.RepositoryPattern.Api.Dtos;
using System.Threading.Tasks;
using Billing.RepositoryPattern.Domain.DbEntities;

namespace Billing.RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<SalesDetailsEntity>> GetAll() =>
            await _salesService.GetAll();


        [HttpPost("AddSales")]
        public async Task AddSales([FromBody] SalesDto sales) =>
            await _salesService.AddSales(sales);

        //[HttpGet("Login")]
        //public async Task<UserEntity> Login(string userName, string password) =>
        //    await _userService.Login(userName, password);
    }
}
